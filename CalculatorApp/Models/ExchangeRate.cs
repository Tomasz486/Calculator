using System;
using System.ComponentModel.DataAnnotations;

namespace CalculatorApp.Models
{
    /// <summary>
    ///     Tabela z kursem walut.
    /// </summary>
    public class ExchangeRate
    {
        /// <summary>
        ///     Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Waluta.
        /// </summary>
        public string Currency { get; set; } = string.Empty;

        /// <summary>
        ///     Data kursu.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Wartość kursu.
        /// </summary>
        public double Rate { get; set; }
    }
}
