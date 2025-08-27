using CalculatorApp.Data;
using CalculatorApp.Models;
using CalculatorApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace CalculatorApp.Tests;

/// <summary>
///     Testowanie przelicznika walut.
/// </summary>
public class CurrencyServiceTests
{
    /// <summary>
    ///     Baza danych w pamiêci operacyjnej.
    /// </summary>
    /// <returns>
    ///     Kontekst bazy danych.
    /// </returns>
    private CalculatorDbContext GetInMemoryDb()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<CalculatorDbContext>()
            .UseSqlite(connection)
            .Options;

        var context = new CalculatorDbContext(options);

        // Tworzymy strukturê bazy
        context.Database.EnsureCreated();

        return context;
    }

    /// <summary>
    ///     Testowanie znajdywania najlepszego kursu waluty.
    /// </summary>
    [Fact]
    public void FindBestConversionDay_ReturnsHighestRate()
    {
        using (var db = GetInMemoryDb())
        {
            db.ExchangeRates.AddRange(
                new ExchangeRate { Currency = "USD", Date = new DateTime(2023,1,1), Rate = 4.0 },
                new ExchangeRate { Currency = "USD", Date = new DateTime(2023,1,2), Rate = 4.5 },
                new ExchangeRate { Currency = "USD", Date = new DateTime(2023,1,3), Rate = 4.3 }
            );
            db.SaveChanges();

            var service = new CurrencyService(db);
            var result = service.FindBestConversionDay("USD", 100, new DateTime(2023,1,1), new DateTime(2023,1,3));

            Assert.Equal(new DateTime(2023,1,2), result.bestDay);
            Assert.Equal(4.5, result.bestRate);
            Assert.Equal(450, result.convertedAmount);
        }
    }

    /// <summary>
    ///     Testowanie sytuacji, gdy nie ma kursu z danego dnia.
    /// </summary>
    [Fact]
    public void FindBestConversionDay_ThrowsIfNoRates()
    {
        using (var db = GetInMemoryDb())
        {
            var service = new CurrencyService(db);
            Assert.Throws<Exception>(() =>
                service.FindBestConversionDay("USD", 100, DateTime.Today, DateTime.Today)
            );
        }
    }
}
