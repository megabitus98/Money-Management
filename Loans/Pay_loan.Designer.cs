﻿namespace Money_Management
{
    partial class Pay_loan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pay_loan));
            this.groupBoxLoan = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.RON = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CCI = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Tranzaction_Date = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Back_Button = new System.Windows.Forms.Button();
            this.groupBoxLoan.SuspendLayout();
            this.CCI.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBoxLoan.Size = new System.Drawing.Size(197, 100);
            this.groupBoxLoan.TabIndex = 11;
            this.groupBoxLoan.TabStop = false;
            this.groupBoxLoan.Text = "Pay Loan";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(157, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 20);
            this.button2.TabIndex = 21;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // RON
            // 
            this.RON.AutoSize = true;
            this.RON.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RON.Location = new System.Drawing.Point(154, 42);
            this.RON.Name = "RON";
            this.RON.Size = new System.Drawing.Size(34, 13);
            this.RON.TabIndex = 20;
            this.RON.Text = "RON";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loan number: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 27);
            this.button1.TabIndex = 19;
            this.button1.Text = "Pay Loan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(64, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(87, 39);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(64, 20);
            this.textBox2.TabIndex = 2;
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
            // CCI
            // 
            this.CCI.Controls.Add(this.label9);
            this.CCI.Controls.Add(this.Tranzaction_Date);
            this.CCI.Location = new System.Drawing.Point(215, 13);
            this.CCI.Name = "CCI";
            this.CCI.Size = new System.Drawing.Size(172, 99);
            this.CCI.TabIndex = 17;
            this.CCI.TabStop = false;
            this.CCI.Text = "Loan Infromartions";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Tranzaction Date";
            // 
            // Tranzaction_Date
            // 
            this.Tranzaction_Date.Location = new System.Drawing.Point(11, 41);
            this.Tranzaction_Date.Name = "Tranzaction_Date";
            this.Tranzaction_Date.ReadOnly = true;
            this.Tranzaction_Date.Size = new System.Drawing.Size(155, 20);
            this.Tranzaction_Date.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Location = new System.Drawing.Point(12, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 99);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Infromartions";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(53, 20);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(155, 20);
            this.textBox3.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Email: ";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(53, 46);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(155, 20);
            this.textBox4.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Phone:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(53, 74);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(155, 20);
            this.textBox5.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Back_Button
            // 
            this.Back_Button.Location = new System.Drawing.Point(295, 189);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(92, 28);
            this.Back_Button.TabIndex = 22;
            this.Back_Button.Text = "Back";
            this.Back_Button.UseVisualStyleBackColor = true;
            this.Back_Button.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // Pay_loan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 224);
            this.Controls.Add(this.Back_Button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CCI);
            this.Controls.Add(this.groupBoxLoan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pay_loan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pay_loan";
            this.groupBoxLoan.ResumeLayout(false);
            this.groupBoxLoan.PerformLayout();
            this.CCI.ResumeLayout(false);
            this.CCI.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLoan;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label RON;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox CCI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Tranzaction_Date;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Back_Button;
    }
}