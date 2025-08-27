using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorApp.Data;
using CalculatorApp.Models;
using Newtonsoft.Json.Linq;

namespace CalculatorApp.Services
{
    /// <summary>
    ///     Usługa walutowa.
    /// </summary>
    public class CurrencyService
    {
        /// <summary>
        ///     Kontekst bazy danych.
        /// </summary>
        private readonly CalculatorDbContext _db;

        /// <summary>
        ///     Konstruktor.
        /// </summary>
        /// <param name="db">
        ///     Kontekst bazy danych.
        /// </param>
        public CurrencyService(CalculatorDbContext db)
        {
            _db = db;
        }

        /// <summary>
        ///     Pobieranie kursów walut.
        /// </summary>
        /// <param name="currency">
        ///     Waluta.
        /// </param>
        /// <param name="start">
        ///     Data początkowa.
        /// </param>
        /// <param name="end">
        ///     Data końcowa
        /// </param>
        /// <returns></returns>
        public async Task FetchAndSaveRatesAsync(string currency, DateTime start, DateTime end)
        {
            string url = $"https://api.nbp.pl/api/exchangerates/rates/a/{currency}/{start:yyyy-MM-dd}/{end:yyyy-MM-dd}/?format=json";

            using (HttpClient client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                var data = JObject.Parse(json);
                var rates = data["rates"];

                foreach (var r in rates!)
                {
                    try
                    {
                        var date = DateTime.Parse(r["effectiveDate"].ToString());
                        var mid = double.Parse(r["mid"].ToString());

                        if (!_db.ExchangeRates.Any(x => x.Currency == currency && x.Date == date))
                        {
                            _db.ExchangeRates.Add(new ExchangeRate
                            {
                                Currency = currency,
                                Date = date,
                                Rate = mid
                            });
                        }

                        await _db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Problem z przetworzeniem danych. {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        ///     Znajdź najkorzystniejszy kurs waluty,
        /// </summary>
        /// <param name="currency">
        ///     Waluta.
        /// </param>
        /// <param name="amount">
        ///     Ilość.
        /// </param>
        /// <param name="start">
        ///     Data początkowa.
        /// </param>
        /// <param name="end">
        ///     Data końcowa.
        /// ></param>
        /// <returns>
        ///     Data najkorzystniejszego kursu, kurs i kwota po przewalutowaniu.
        /// </returns>
        public (DateTime bestDay, double bestRate, double convertedAmount) FindBestConversionDay(string currency, decimal amount, DateTime start, DateTime end)
        {
            // obcinamy godziny, tylko pełne dni
            start = start.Date.AddDays(1).AddDays(-1);
            end = end.Date.AddDays(1).AddTicks(-1);

            var best = _db.ExchangeRates
                           .Where(r => r.Currency == currency && r.Date >= start && r.Date <= end)
                           .AsEnumerable()
                           .OrderByDescending(r => r.Rate)
                           .FirstOrDefault();

            if (best == null)
            {
                throw new Exception("Brak danych dla podanego zakresu.");
            }

            return (best.Date, best.Rate, best.Rate * (double)amount);
        }
    }
}
