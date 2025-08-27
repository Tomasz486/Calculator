namespace CalculatorApp
{
    partial class CalculatorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxExpression;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.ListBox listBoxHistory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxExpression = new System.Windows.Forms.TextBox();
            buttonCalculate = new System.Windows.Forms.Button();
            listBoxHistory = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // textBoxExpression
            // 
            textBoxExpression.Font = new System.Drawing.Font("Segoe UI", 12F);
            textBoxExpression.Location = new System.Drawing.Point(5, 55);
            textBoxExpression.Name = "textBoxExpression";
            textBoxExpression.Size = new System.Drawing.Size(260, 29);
            textBoxExpression.TabIndex = 0;
            textBoxExpression.KeyDown += textBoxExpression_KeyDown;
            // 
            // buttonCalculate
            // 
            buttonCalculate.Font = new System.Drawing.Font("Segoe UI", 12F);
            buttonCalculate.Location = new System.Drawing.Point(5, 90);
            buttonCalculate.Name = "buttonCalculate";
            buttonCalculate.Size = new System.Drawing.Size(260, 35);
            buttonCalculate.TabIndex = 1;
            buttonCalculate.Text = "Oblicz";
            buttonCalculate.UseVisualStyleBackColor = true;
            buttonCalculate.Click += buttonCalculate_Click;
            // 
            // listBoxHistory
            // 
            listBoxHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            listBoxHistory.FormattingEnabled = true;
            listBoxHistory.ItemHeight = 17;
            listBoxHistory.Location = new System.Drawing.Point(9, 140);
            listBoxHistory.Name = "listBoxHistory";
            listBoxHistory.Size = new System.Drawing.Size(256, 191);
            listBoxHistory.TabIndex = 2;
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(5, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(260, 39);
            label1.TabIndex = 3;
            label1.Text = "Wpisz wyrażenie. Dopuszcalne operatory: +,-,*,/,% oraz =,<,>";
            // 
            // CalculatorForm
            // 
            ClientSize = new System.Drawing.Size(273, 343);
            Controls.Add(label1);
            Controls.Add(textBoxExpression);
            Controls.Add(buttonCalculate);
            Controls.Add(listBoxHistory);
            Name = "CalculatorForm";
            Text = "Kalkulator";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label1;
    }
}
