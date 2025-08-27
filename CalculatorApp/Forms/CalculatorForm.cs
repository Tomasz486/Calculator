using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CalculatorApp.Data;
using CalculatorApp.Models;
using CalculatorApp.Services;

namespace CalculatorApp
{
    /// <summary>
    ///     Formularz.
    /// </summary>
    public partial class CalculatorForm : Form
    {
        /// <summary>
        ///     Konstruktor.
        /// </summary>
        public CalculatorForm()
        {
            InitializeComponent();
            LoadHistory();
        }

        /// <summary>
        ///     Akcja po kliknięciu przycisku "Oblicz".
        /// </summary>
        /// <param name="sender">
        ///     Nadawca zdarzenia.
        /// </param>
        /// <param name="e">
        ///     Parametr. 
        /// </param>
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            string expression = textBoxExpression.Text;

            try
            {
                var result = new CalculatorService().Calculate(expression);

                if (result == null)
                {
                    throw new Exception();
                }

                using (var db = new CalculatorDbContext())
                {
                    db.Calculations.Add(new Calculation
                    {
                        Expression = expression,
                        Result = result,
                        CreatedAt = DateTime.Now
                    });
                    db.SaveChanges();
                }

                LoadHistory();
                textBoxExpression.Clear();
            }
            catch
            {
                MessageBox.Show("Nieprawidowe wyrażenie!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///     Laduje historie z bazy danych na formularz.
        /// </summary>
        private void LoadHistory()
        {
            listBoxHistory.Items.Clear();
            using (var db = new CalculatorDbContext())
            {
                var calculations = db.Calculations.OrderByDescending(c => c.CreatedAt).ToList();
                foreach (var calc in calculations)
                {
                    listBoxHistory.Items.Add($"{calc.CreatedAt} | {calc.Expression} = {calc.Result}");
                }
            }
        }

        /// <summary>
        ///     Akcja po wciśnięciu ENTER.
        /// </summary>
        /// <param name="sender">
        ///     Nadawca zdarzenia.
        /// </param>
        /// <param name="e">
        ///     Parametr. 
        /// </param>
        private void textBoxExpression_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonCalculate_Click(sender, e);
            }
        }
    }
}
