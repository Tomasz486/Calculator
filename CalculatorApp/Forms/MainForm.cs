using System;
using System.Windows.Forms;

namespace CalculatorApp.Forms
{
    /// <summary>
    ///     Główny formularz.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        ///     Konstruktor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Akcja po wybraniu modułu kalkulaora.
        /// </summary>
        /// <param name="sender">
        ///     Nadawca zdarzenia.
        /// </param>
        /// <param name="e">
        ///     Parametr zdarzenka. 
        /// </param>
        private void CalculatorButton_Click(object sender, EventArgs e)
        {
            new CalculatorForm().ShowDialog();
        }

        /// <summary>
        ///     Akcja po wybraniu modułu przelicznika walut.
        /// </summary>
        /// <param name="sender">
        ///     Nadawca zdarzenia.
        /// </param>
        /// <param name="e">
        ///     Parametr zdarzenka. 
        /// </param>
        private void ExhangeButton_Click(object sender, EventArgs e)
        {
            new ExchangeForm().ShowDialog();
        }
    }
}
