using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Money_Management
{
    public partial class Pay_loan : Form
    {
        private static string user;
        private static int admin;
        List<string> Client = new List<string>();
        Useful useful = new Useful();
        public Pay_loan(string username, int Admin)
        {
            InitializeComponent();
            user = username;
            admin = Admin;
        }
        Database_Info_Selector l = new Database_Info_Selector();

        private void Fill_Values()
        {
            l.Tag = " ";
            l.Show();
            l.Command("SELECT Name, Amount, Tranzaction_Date, Total_Loans, Phone, Email, idLoan, Receive_Amount FROM Loans INNER JOIN Clients ON Loans.clientId=Clients.idClients WHERE Paid=0");
            timer1.Start();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Fill_Values();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if ((string)l.Tag == "Closed")
            {
                timer1.Stop();
                {
                    Client = l.results;
                    try
                    {
                        textBox1.Text = Client[6];
                        textBox2.Text = Client[7];
                        Tranzaction_Date.Text = Client[2];
                        textBox3.Text = Client[0];
                        textBox4.Text = Client[4];
                        textBox5.Text = Client[5];
                        textBox7.Text = Client[1];
                    }
                    catch (Exception z)
                    {
                        Useful.Error_Message(z, false);
                    }
                }
            }
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            Main_Menu m = new Main_Menu(user, admin);
            m.Show();
            Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (useful.CheckEmptySpaces(groupBoxLoan)==false)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to pay the loan for: " + textBox3.Text + "?", "Confirm Payment!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (confirmResult == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection())
                    {
                        conn.ConnectionString = Properties.Settings.Default.ProjectConnectionString;
                        try
                        {
                            conn.Open();
                            using (MySqlCommand cmd = new MySqlCommand("UPDATE Loans SET Paid=1 WHERE idLoan=@Loan", conn))
                            {
                                cmd.Parameters.AddWithValue("@Loan", textBox1.Text);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Paid " + "the loan for " + textBox3.Text, "Payment suceded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                useful.ClearThings(groupBoxLoan);
                                useful.ClearThings(groupBox1);
                                useful.ClearThings(CCI);
                            }
                        }
                        catch (Exception z)
                        {
                            Useful.Error_Message(z, true);
                        }
                    }
                }
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox6.Text = dateTimePicker1.Value.ToLongDateString();
        }

        private void Pay_loan_Load(object sender, EventArgs e)
        {
            textBox6.Text = dateTimePicker1.Value.ToLongDateString();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
           // Fill_Values();
        }
    }
}
