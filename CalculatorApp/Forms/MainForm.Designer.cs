namespace CalculatorApp.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CalculatorButton = new System.Windows.Forms.Button();
            ExhangeButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // CalculatorButton
            // 
            CalculatorButton.Location = new System.Drawing.Point(17, 40);
            CalculatorButton.Name = "CalculatorButton";
            CalculatorButton.Size = new System.Drawing.Size(222, 72);
            CalculatorButton.TabIndex = 0;
            CalculatorButton.Text = "Kalkulator";
            CalculatorButton.UseVisualStyleBackColor = true;
            CalculatorButton.Click += CalculatorButton_Click;
            // 
            // ExhangeButton
            // 
            ExhangeButton.Location = new System.Drawing.Point(17, 144);
            ExhangeButton.Name = "ExhangeButton";
            ExhangeButton.Size = new System.Drawing.Size(222, 72);
            ExhangeButton.TabIndex = 1;
            ExhangeButton.Text = "Przelicznik walut";
            ExhangeButton.UseVisualStyleBackColor = true;
            ExhangeButton.Click += ExhangeButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(258, 261);
            Controls.Add(ExhangeButton);
            Controls.Add(CalculatorButton);
            Name = "MainForm";
            Text = "Wybór modułu";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button CalculatorButton;
        private System.Windows.Forms.Button ExhangeButton;
    }
}