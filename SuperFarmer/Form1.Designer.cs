namespace SuperFarmer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            listView1 = new ListView();
            listView2 = new ListView();
            listView3 = new ListView();
            listView4 = new ListView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            listView5 = new ListView();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(193, 62);
            button1.TabIndex = 0;
            button1.Text = "Wymiana";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(508, 288);
            button2.Name = "button2";
            button2.Size = new Size(425, 62);
            button2.TabIndex = 1;
            button2.Text = "Rzuć kośćmi";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1193, 578);
            button3.Name = "button3";
            button3.Size = new Size(195, 62);
            button3.TabIndex = 2;
            button3.Text = "Zakończ turę";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(24, 389);
            listView1.Name = "listView1";
            listView1.Size = new Size(142, 210);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            listView2.Location = new Point(247, 389);
            listView2.Name = "listView2";
            listView2.Size = new Size(142, 210);
            listView2.TabIndex = 4;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // listView3
            // 
            listView3.Location = new Point(469, 389);
            listView3.Name = "listView3";
            listView3.Size = new Size(142, 210);
            listView3.TabIndex = 5;
            listView3.UseCompatibleStateImageBehavior = false;
            // 
            // listView4
            // 
            listView4.Location = new Point(686, 389);
            listView4.Name = "listView4";
            listView4.Size = new Size(142, 210);
            listView4.TabIndex = 6;
            listView4.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AccessibleDescription = "";
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19F);
            label1.Location = new Point(42, 623);
            label1.Name = "label1";
            label1.Size = new Size(100, 36);
            label1.TabIndex = 7;
            label1.Text = "Gracz 1";
            // 
            // label2
            // 
            label2.AccessibleDescription = "";
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19F);
            label2.Location = new Point(267, 623);
            label2.Name = "label2";
            label2.Size = new Size(100, 36);
            label2.TabIndex = 8;
            label2.Text = "Gracz 2";
            // 
            // label3
            // 
            label3.AccessibleDescription = "";
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 19F);
            label3.Location = new Point(488, 623);
            label3.Name = "label3";
            label3.Size = new Size(100, 36);
            label3.TabIndex = 9;
            label3.Text = "Gracz 3";
            // 
            // label4
            // 
            label4.AccessibleDescription = "";
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 19F);
            label4.Location = new Point(707, 623);
            label4.Name = "label4";
            label4.Size = new Size(100, 36);
            label4.TabIndex = 10;
            label4.Text = "Gracz 4";
            // 
            // listView5
            // 
            listView5.Location = new Point(1218, 21);
            listView5.Name = "listView5";
            listView5.Size = new Size(142, 210);
            listView5.TabIndex = 11;
            listView5.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            label5.AccessibleDescription = "";
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(1202, 246);
            label5.Name = "label5";
            label5.Size = new Size(177, 25);
            label5.TabIndex = 12;
            label5.Text = "Pozostałe zwierzęta";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(508, 76);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(201, 155);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(737, 76);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(196, 155);
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1433, 682);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(listView5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listView4);
            Controls.Add(listView3);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private ListView listView1;
        private ListView listView2;
        private ListView listView3;
        private ListView listView4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListView listView5;
        private Label label5;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
