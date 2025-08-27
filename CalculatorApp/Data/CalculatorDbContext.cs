using Microsoft.EntityFrameworkCore;
using CalculatorApp.Models;

namespace CalculatorApp.Data
{
    /// <summary>
    ///     Kontekst bazy danych.
    /// </summary>
    public class CalculatorDbContext : DbContext
    {
        /// <summary>
        ///     Rekordy tabeli Calculations.
        /// </summary>
        public DbSet<Calculation> Calculations { get; set; }

        /// <summary>
        ///     Rekordy kursów walut.
        /// </summary>
        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        /// <summary>
        ///     Konfiguracja bazy danych.
        /// </summary>
        /// <param name="optionsBuilder">
        ///     Opcje konfiguracji.
        /// </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=calculator.db");
        }

        /// <summary>
        ///     Konstruktor domyślny.
        /// </summary>
        public CalculatorDbContext() { }

        /// <summary>
        ///     Konstruktor sparametryzowany.
        /// </summary>
        /// <param name="options">
        ///     Opcje konfiguracji.
        /// </param>
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) : base(options) { }
    }
}
