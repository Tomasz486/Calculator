using System.Windows.Forms;

namespace CalculatorApp
{
    partial class ExchangeForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxCurrency;
        private TextBox textBoxAmount;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private Button buttonFetchRates;
        private Button buttonBestDay;

        private void InitializeComponent()
        {
            textBoxCurrency = new TextBox();
            textBoxAmount = new TextBox();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            buttonFetchRates = new Button();
            buttonBestDay = new Button();
            labelCurrency = new Label();
            labelAmount = new Label();
            labelDteStart = new Label();
            labelEndDate = new Label();
            CodeslinkLabel = new LinkLabel();
            SuspendLayout();
            // 
            // textBoxCurrency
            // 
            textBoxCurrency.Location = new System.Drawing.Point(68, 12);
            textBoxCurrency.Name = "textBoxCurrency";
            textBoxCurrency.Size = new System.Drawing.Size(100, 23);
            textBoxCurrency.TabIndex = 0;
            textBoxCurrency.Text = "USD";
            // 
            // textBoxAmount
            // 
            textBoxAmount.Location = new System.Drawing.Point(68, 41);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new System.Drawing.Size(100, 23);
            textBoxAmount.TabIndex = 1;
            textBoxAmount.Text = "100";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new System.Drawing.Point(125, 90);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new System.Drawing.Size(200, 23);
            dateTimePickerStart.TabIndex = 2;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Location = new System.Drawing.Point(125, 134);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new System.Drawing.Size(200, 23);
            dateTimePickerEnd.TabIndex = 3;
            // 
            // buttonFetchRates
            // 
            buttonFetchRates.Location = new System.Drawing.Point(15, 193);
            buttonFetchRates.Name = "buttonFetchRates";
            buttonFetchRates.Size = new System.Drawing.Size(151, 43);
            buttonFetchRates.TabIndex = 4;
            buttonFetchRates.Text = "Pobierz kursy waluty";
            buttonFetchRates.Click += buttonFetchRates_Click;
            // 
            // buttonBestDay
            // 
            buttonBestDay.Location = new System.Drawing.Point(175, 193);
            buttonBestDay.Name = "buttonBestDay";
            buttonBestDay.Size = new System.Drawing.Size(153, 43);
            buttonBestDay.TabIndex = 5;
            buttonBestDay.Text = "Wybierz najlepszy kurs";
            buttonBestDay.Click += buttonBestDay_Click;
            // 
            // labelCurrency
            // 
            labelCurrency.AutoSize = true;
            labelCurrency.Location = new System.Drawing.Point(15, 15);
            labelCurrency.Name = "labelCurrency";
            labelCurrency.Size = new System.Drawing.Size(47, 15);
            labelCurrency.TabIndex = 6;
            labelCurrency.Text = "Waluta:";
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Location = new System.Drawing.Point(13, 44);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new System.Drawing.Size(43, 15);
            labelAmount.TabIndex = 7;
            labelAmount.Text = "Kwota:";
            // 
            // labelDteStart
            // 
            labelDteStart.AutoSize = true;
            labelDteStart.Location = new System.Drawing.Point(19, 96);
            labelDteStart.Name = "labelDteStart";
            labelDteStart.Size = new System.Drawing.Size(100, 15);
            labelDteStart.TabIndex = 8;
            labelDteStart.Text = "Data pocz¹tkowa:";
            // 
            // labelEndDate
            // 
            labelEndDate.AutoSize = true;
            labelEndDate.Location = new System.Drawing.Point(19, 140);
            labelEndDate.Name = "labelEndDate";
            labelEndDate.Size = new System.Drawing.Size(85, 15);
            labelEndDate.TabIndex = 9;
            labelEndDate.Text = "Data koñcowa:";
            // 
            // CodeslinkLabel
            // 
            CodeslinkLabel.AutoSize = true;
            CodeslinkLabel.Location = new System.Drawing.Point(186, 12);
            CodeslinkLabel.Name = "CodeslinkLabel";
            CodeslinkLabel.Size = new System.Drawing.Size(129, 15);
            CodeslinkLabel.TabIndex = 10;
            CodeslinkLabel.TabStop = true;
            CodeslinkLabel.Text = "Prawid³owe kody walut";
            CodeslinkLabel.LinkClicked += this.CodeslinkLabel_LinkClicked;
            // 
            // ExchangeForm
            // 
            ClientSize = new System.Drawing.Size(340, 265);
            Controls.Add(CodeslinkLabel);
            Controls.Add(labelEndDate);
            Controls.Add(labelDteStart);
            Controls.Add(labelAmount);
            Controls.Add(labelCurrency);
            Controls.Add(textBoxCurrency);
            Controls.Add(textBoxAmount);
            Controls.Add(dateTimePickerStart);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(buttonFetchRates);
            Controls.Add(buttonBestDay);
            Name = "ExchangeForm";
            Text = "Przelicznik walut";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label labelCurrency;
        private Label labelAmount;
        private Label labelDteStart;
        private Label labelEndDate;
        private LinkLabel CodeslinkLabel;
    }
}
