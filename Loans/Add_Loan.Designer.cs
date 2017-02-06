namespace Money_Management
{
    partial class Add_Loan
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Loan));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.CCI = new System.Windows.Forms.GroupBox();
            this.Loans = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.PhoneC = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.EmailC = new System.Windows.Forms.TextBox();
            this.Back_Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxLoan = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.RON = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CCI.SuspendLayout();
            this.groupBoxLoan.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Money: ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(51, 39);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(110, 20);
            this.textBox2.TabIndex = 2;
            // 
            // CCI
            // 
            this.CCI.Controls.Add(this.Loans);
            this.CCI.Controls.Add(this.label3);
            this.CCI.Controls.Add(this.label9);
            this.CCI.Controls.Add(this.PhoneC);
            this.CCI.Controls.Add(this.label8);
            this.CCI.Controls.Add(this.EmailC);
            this.CCI.Location = new System.Drawing.Point(226, 13);
            this.CCI.Name = "CCI";
            this.CCI.Size = new System.Drawing.Size(245, 99);
            this.CCI.TabIndex = 16;
            this.CCI.TabStop = false;
            this.CCI.Text = "Client Infromartions";
            // 
            // Loans
            // 
            this.Loans.Location = new System.Drawing.Point(78, 71);
            this.Loans.Name = "Loans";
            this.Loans.ReadOnly = true;
            this.Loans.Size = new System.Drawing.Size(155, 20);
            this.Loans.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total Loans:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Email: ";
            // 
            // PhoneC
            // 
            this.PhoneC.Location = new System.Drawing.Point(78, 45);
            this.PhoneC.Name = "PhoneC";
            this.PhoneC.ReadOnly = true;
            this.PhoneC.Size = new System.Drawing.Size(155, 20);
            this.PhoneC.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Phone:";
            // 
            // EmailC
            // 
            this.EmailC.Location = new System.Drawing.Point(78, 19);
            this.EmailC.Name = "EmailC";
            this.EmailC.ReadOnly = true;
            this.EmailC.Size = new System.Drawing.Size(155, 20);
            this.EmailC.TabIndex = 8;
            // 
            // Back_Button
            // 
            this.Back_Button.Location = new System.Drawing.Point(379, 119);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(92, 27);
            this.Back_Button.TabIndex = 18;
            this.Back_Button.Text = "Back";
            this.Back_Button.UseVisualStyleBackColor = true;
            this.Back_Button.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 27);
            this.button1.TabIndex = 19;
            this.button1.Text = "Add Loan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // groupBoxLoan
            // 
            this.groupBoxLoan.Controls.Add(this.button2);
            this.groupBoxLoan.Controls.Add(this.RON);
            this.groupBoxLoan.Controls.Add(this.label1);
            this.groupBoxLoan.Controls.Add(this.button1);
            this.groupBoxLoan.Controls.Add(this.textBox1);
            this.groupBoxLoan.Controls.Add(this.textBox2);
            this.groupBoxLoan.Controls.Add(this.label2);
            this.groupBoxLoan.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLoan.Name = "groupBoxLoan";
            this.groupBoxLoan.Size = new System.Drawing.Size(198, 100);
            this.groupBoxLoan.TabIndex = 10;
            this.groupBoxLoan.TabStop = false;
            this.groupBoxLoan.Text = "Add Loan";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(164, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 20);
            this.button2.TabIndex = 21;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RON
            // 
            this.RON.AutoSize = true;
            this.RON.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RON.Location = new System.Drawing.Point(161, 42);
            this.RON.Name = "RON";
            this.RON.Size = new System.Drawing.Size(34, 13);
            this.RON.TabIndex = 20;
            this.RON.Text = "RON";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Add_Loan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 158);
            this.Controls.Add(this.groupBoxLoan);
            this.Controls.Add(this.Back_Button);
            this.Controls.Add(this.CCI);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Add_Loan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_Loan";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Add_Loan_FormClosed);
            this.Load += new System.EventHandler(this.Add_Loan_Load);
            this.CCI.ResumeLayout(false);
            this.CCI.PerformLayout();
            this.groupBoxLoan.ResumeLayout(false);
            this.groupBoxLoan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox CCI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox PhoneC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox EmailC;
        private System.Windows.Forms.Button Back_Button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxLoan;
        private System.Windows.Forms.TextBox Loans;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label RON;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
    }
}