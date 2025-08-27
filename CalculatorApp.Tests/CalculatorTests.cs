using System.Data;
using CalculatorApp.Services;

namespace CalculatorApp.Tests
{
    /// <summary>
    ///     Testowanie kalkulatora.
    /// </summary>
    public class CalculatorTests
    {
        /// <summary>
        ///     Testowanie dodawania.
        /// </summary>
        [Fact]
        public void Addition_Works()
        {
            Assert.Equal("4", new CalculatorService().Calculate("2+2"));
        }

        /// <summary>
        ///     Testowanie odejmowania.
        /// </summary>
        [Fact]
        public void Substraction_Works()
        {
            Assert.Equal("0", new CalculatorService().Calculate("2-2"));
        }

        /// <summary>
        ///     Testowanie mnożenia.
        /// </summary>
        [Fact]
        public void Multiplication_Works()
        {
            Assert.Equal("4", new CalculatorService().Calculate("2*2"));
        }

        /// <summary>
        ///     Testowanie dzielenia.
        /// </summary>
        [Fact]
        public void Division_Works()
        {
            Assert.Equal("1", new CalculatorService().Calculate("2/2"));
        }

        /// <summary>
        ///     Testowanie modulo.
        /// </summary>
        [Fact]
        public void Modulo_Works()
        {
            Assert.Equal("0", new CalculatorService().Calculate("2%2"));
        }

        /// <summary>
        ///     Testowanie równa się.
        /// </summary>
        [Fact]
        public void Equals_Works()
        {
            Assert.Equal("True", new CalculatorService().Calculate("2=2"));
        }

        /// <summary>
        ///     Testowanie większy niż.
        /// </summary>
        [Fact]
        public void GreaterThan_Works()
        {
            Assert.Equal("True", new CalculatorService().Calculate("3>2"));
        }

        /// <summary>
        ///     Testowanie mniejszy niż.
        /// </summary>
        [Fact]
        public void SmallererThan_Works()
        {
            Assert.Equal("False", new CalculatorService().Calculate("3<2"));
        }

        /// <summary>
        ///     Czy zwróci null dla pustego wyrażenia.
        /// </summary>
        [Fact]
        public void Empty_IsNull()
        {
            Assert.Null(new CalculatorService().Calculate(string.Empty));
        }

        /// <summary>
        ///     Czy zwróci wyjątek dla nieprawidłowego wyrażenia.
        /// </summary>
        [Fact]
        public void IncorrectExpression_Error()
        {
            Assert.Throws<EvaluateException>(() => 
                new CalculatorService().Calculate("1*a"));
        }
    }
}