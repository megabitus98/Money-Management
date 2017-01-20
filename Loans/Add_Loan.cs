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

namespace Loans
{
    public partial class Add_Loan : Form
    {
        private string user;
        private int admin, money;
        List<string> names = new List<string>();
        Useful usefuel = new Useful();
        public Add_Loan(string username, int Admin)
        {
            InitializeComponent();
            user = username;
            admin = Admin;
        }

        private void Add_Loan_Load(object sender, EventArgs e)
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            GetData(DataCollection);
            textBox1.AutoCompleteCustomSource = DataCollection;
        }
        private void GetData(AutoCompleteStringCollection dataCollection)
        {
            DataSet ds = new DataSet();
            using (MySqlConnection c = new MySqlConnection(Properties.Settings.Default.ProjectConnectionString))
            {
                c.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT Name FROM Client", c))
                    adapter.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataCollection.Add(row[0].ToString());
                    names.Add(row[0].ToString());
                }
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            bool ok = false;
            foreach (var item in names)
            {
                if (item.Equals(textBox1.Text) == true)
                {
                    using (MySqlConnection conn = new MySqlConnection())
                    {
                        conn.ConnectionString = Properties.Settings.Default.ProjectConnectionString;
                        conn.Open();
                        using (MySqlCommand command = new MySqlCommand("SELECT Email, Phone, Total_Loans FROM Client WHERE Name = @N", conn))
                        {
                            command.Parameters.AddWithValue("@N", textBox1.Text);
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    EmailC.Text = reader["Email"].ToString();
                                    PhoneC.Text = reader["Phone"].ToString();
                                    money = Convert.ToInt32(reader["Total_Loans"]);
                                    Loans.Text = money.ToString();
                                }
                                ok = true;
                            }
                        }
                    }
                }
                else if (ok == false) usefuel.ClearThings(CCI);
            }
        }

        private void Add_Loan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            Main_Menu m = new Main_Menu(user, admin);
            m.Show();
            this.Hide();
        }
        bool Verificare_money()
        {
            foreach (char item in textBox2.Text)
                if (char.IsLetter(item) == true)
                    return false;
            return true;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            var confirmResult = DialogResult.No;
            bool OK = usefuel.CheckEmptySpaces(groupBoxLoan);
            if (OK == false)
            {
                confirmResult = MessageBox.Show("Are you sure you want to add a loan for: " + textBox1.Text + "?", "Confirm Add!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            }
            if (Verificare_money() == false) MessageBox.Show("There is text in the money box!", "Critical Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (confirmResult == DialogResult.Yes)
                if (OK == false)
                {
                    int id = 0, money2 = 0;
                    using (MySqlConnection conn = new MySqlConnection())
                    {
                        conn.ConnectionString = Properties.Settings.Default.ProjectConnectionString;
                        conn.Open();
                        using (MySqlCommand command = new MySqlCommand("SELECT clientId, Total_Loans FROM Client WHERE Name = @N", conn))
                        {
                            command.Parameters.AddWithValue("@N", textBox1.Text);
                            using (MySqlDataReader reader = command.ExecuteReader())
                                while (reader.Read())
                                {
                                    id = Convert.ToInt32(reader["clientId"]);
                                    money2 = Convert.ToInt32(reader["Total_Loans"]);
                                }
                        }
                        using (MySqlCommand cmd = new MySqlCommand("INSERT INTO LOAN (clientId, Money, Tranzaction_Date)" +
                                                                "values(@id, @money, @date)", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            DateTime rightnow = DateTime.Now;
                            cmd.Parameters.AddWithValue("@date", rightnow);
                            cmd.Parameters.AddWithValue("@money", textBox2.Text);
                            cmd.ExecuteNonQuery();
                        }
                        using (MySqlCommand cmd = new MySqlCommand("SELECT loanId FROM LOAN;", conn))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    id = Convert.ToInt32(reader["loanId"]);
                                }
                            }
                        }
                        using (MySqlCommand cmd = new MySqlCommand("UPDATE Client SET Last_Loan = @last, Total_Loans = @amount WHERE Name = @N", conn))
                        {
                            cmd.Parameters.AddWithValue("@N", textBox1.Text);
                            cmd.Parameters.AddWithValue("@last", id);
                            cmd.Parameters.AddWithValue("@amount", money2 + Convert.ToInt32(textBox2.Text));
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            usefuel.ClearThings(groupBoxLoan);
        }
    }
}
