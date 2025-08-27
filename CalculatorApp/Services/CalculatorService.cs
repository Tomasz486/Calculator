using System.Data;

namespace CalculatorApp.Services
{
    /// <summary>
    ///     Usługa kalkulatora.
    /// </summary>
    public class CalculatorService
    {
        /// <summary>
        ///     Oblicza wyrażenie.
        /// </summary>
        /// <param name="expression">
        ///     Wyrażenie.
        /// </param>
        /// <returns>
        ///     Wynik wyrażenia.
        /// </returns>
        public string? Calculate(string expression)
        {
            if (expression == string.Empty)
            {
                return null;
            }

            return new DataTable().Compute(expression, null).ToString();
        }
    }
}
