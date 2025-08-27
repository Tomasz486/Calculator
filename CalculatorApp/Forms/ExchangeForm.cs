using System;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Forms;
using CalculatorApp.Data;
using CalculatorApp.Services;

namespace CalculatorApp
{
    public partial class ExchangeForm : Form
    {
        public ExchangeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Akcja po klikni�ciu na przycisk pobierania kurs�w walut.
        /// </summary>
        /// <param name="sender">
        ///     Nadawca zdarzenia.
        /// </param>
        /// <param name="e">
        ///     Parametr zdarzenia. 
        /// </param>
        private async void buttonFetchRates_Click(object sender, EventArgs e)
        {
            string currency = textBoxCurrency.Text.ToUpper();
            DateTime start = dateTimePickerStart.Value;
            DateTime end = dateTimePickerEnd.Value;

            using (var db = new CalculatorDbContext())
            {
                var service = new CurrencyService(db);
                try
                {
                    await service.FetchAndSaveRatesAsync(currency, start, end);
                    MessageBox.Show("Dane kurs�w zostay pobrane.");
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Dane kurs�w NIE zostay pobrane. Problem z po��czeniem. {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Dane kurs�w NIE zostay pobrane. {ex.Message}");
                }
            }
        }

        /// <summary>
        ///     Akcja po klikni�ciu w przycisk wyboru najlepszego kursu waluty.
        /// </summary>
        /// <param name="sender">
        ///     Nadawca zdarzenia.
        /// </param>
        /// <param name="e">
        ///     Parametr zdarzenka. 
        /// </param>
        private void buttonBestDay_Click(object sender, EventArgs e)
        {
            string currency = textBoxCurrency.Text.ToUpper();
            decimal amount;
            
            if (! decimal.TryParse(textBoxAmount.Text, out amount))
            {
                MessageBox.Show($"Podano nieprawid�ow� kwot�: {textBoxAmount.Text}.");
                return;
            }

            DateTime start = dateTimePickerStart.Value;
            DateTime end = dateTimePickerEnd.Value;

            using (var db = new CalculatorDbContext())
            {
                var service = new CurrencyService(db);
                try
                {
                    var (bestDay, bestRate, convertedAmount) = service.FindBestConversionDay(currency, amount, start, end);
                    MessageBox.Show($"Najlepszy dzie: {bestDay:yyyy-MM-dd}\nKurs: {bestRate}\nKwota: {convertedAmount}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CodeslinkLabel_LinkClicked(object sender, EventArgs e)
        {
            const string url = "https://pl.wikipedia.org/wiki/ISO_4217#Kody_w_u%C5%BCyciu";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie uda�o si� otworzy� przegl�darki: {ex.Message}");
            }
        }
    }
}
