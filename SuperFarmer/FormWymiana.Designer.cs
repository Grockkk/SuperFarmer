namespace SuperFarmer
{
    partial class FormWymiana
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
            BoxFrom = new ComboBox();
            BoxTo = new ComboBox();
            textAmount = new TextBox();
            Accept = new Button();
            Cancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            TabelaWymian = new ListView();
            comboTarget = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // BoxFrom
            // 
            BoxFrom.FormattingEnabled = true;
            BoxFrom.Location = new Point(41, 29);
            BoxFrom.Name = "BoxFrom";
            BoxFrom.Size = new Size(121, 23);
            BoxFrom.TabIndex = 0;
            // 
            // BoxTo
            // 
            BoxTo.FormattingEnabled = true;
            BoxTo.Location = new Point(200, 29);
            BoxTo.Name = "BoxTo";
            BoxTo.Size = new Size(137, 23);
            BoxTo.TabIndex = 1;
            // 
            // textAmount
            // 
            textAmount.Location = new Point(359, 29);
            textAmount.Name = "textAmount";
            textAmount.Size = new Size(112, 23);
            textAmount.TabIndex = 2;
            // 
            // Accept
            // 
            Accept.Location = new Point(282, 129);
            Accept.Name = "Accept";
            Accept.Size = new Size(177, 59);
            Accept.TabIndex = 3;
            Accept.Text = "Akceptuj";
            Accept.UseVisualStyleBackColor = true;
            Accept.Click += Accept_Click;
            // 
            // Cancel
            // 
            Cancel.Location = new Point(41, 129);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(177, 59);
            Cancel.TabIndex = 4;
            Cancel.Text = "Anuluj";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 11);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 5;
            label1.Text = "Twoje zwierzęta";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(200, 11);
            label2.Name = "label2";
            label2.Size = new Size(112, 15);
            label2.TabIndex = 6;
            label2.Text = "Zwierzę do kupienia";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(359, 11);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 7;
            label3.Text = "Ile kupić";
            // 
            // TabelaWymian
            // 
            TabelaWymian.Location = new Point(499, 29);
            TabelaWymian.Name = "TabelaWymian";
            TabelaWymian.Size = new Size(244, 159);
            TabelaWymian.TabIndex = 8;
            TabelaWymian.UseCompatibleStateImageBehavior = false;
            // 
            // comboTarget
            // 
            comboTarget.FormattingEnabled = true;
            comboTarget.Location = new Point(200, 76);
            comboTarget.Name = "comboTarget";
            comboTarget.Size = new Size(137, 23);
            comboTarget.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(200, 55);
            label4.Name = "label4";
            label4.Size = new Size(137, 15);
            label4.TabIndex = 10;
            label4.Text = "Z kim dokonać wymiany";
            label4.Click += label4_Click;
            // 
            // FormWymiana
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 217);
            Controls.Add(label4);
            Controls.Add(comboTarget);
            Controls.Add(TabelaWymian);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Cancel);
            Controls.Add(Accept);
            Controls.Add(textAmount);
            Controls.Add(BoxTo);
            Controls.Add(BoxFrom);
            Name = "FormWymiana";
            Text = "FormWymiana";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox BoxFrom;
        private ComboBox BoxTo;
        private TextBox textAmount;
        private Button Accept;
        private Button Cancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private ListView TabelaWymian;
        private ComboBox comboTarget;
        private Label label4;
    }
}