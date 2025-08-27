using System;
using System.ComponentModel.DataAnnotations;

namespace CalculatorApp.Models
{
    /// <summary>
    ///     Tabela kalkulator.
    /// </summary>
    public class Calculation
    {
        /// <summary>
        ///     Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Wyrażenie.
        /// </summary>
        public required string Expression { get; set; }

        /// <summary>
        ///     Wynik.
        /// </summary>
        public required string Result { get; set; }

        /// <summary>
        ///     Data obliczeń.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
