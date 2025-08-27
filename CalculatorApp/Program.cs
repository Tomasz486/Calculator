using System;
using System.Windows.Forms;
using CalculatorApp.Forms;

namespace CalculatorApp
{
    /// <summary>
    ///     Punkt startowy programu.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///     Metoda startowa.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Tworzenie bazy danych jeśli nie istnieje
            using (var db = new Data.CalculatorDbContext())
            {
                db.Database.EnsureCreated();
            }
            
            Application.Run(new MainForm());
        }
    }
}
