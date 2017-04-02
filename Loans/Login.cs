using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Money_Management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.Username;
            textBox2.Text = Properties.Settings.Default.Password;
            checkBox1.Checked = true;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection())
            {
                bool OK = false;
                try
                {
                    conn.ConnectionString = Properties.Settings.Default.ProjectConnectionString;
                    conn.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT Username, Password, Administrator FROM Users", conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (textBox1.Text == reader[0].ToString() && textBox2.Text == reader[1].ToString())
                                {
                                    if (checkBox1.Checked == true)
                                    {
                                        Properties.Settings.Default.Username = textBox1.Text;
                                        Properties.Settings.Default.Password = textBox2.Text;
                                        Properties.Settings.Default.Save();
                                    }
                                    Main_Menu m = new Main_Menu(reader[0].ToString(), Convert.ToInt32(reader[2]));
                                    m.Show();
                                    this.Hide();
                                    OK = true;
                                }
                            }
                        }
                    }
                }
                catch (Exception z)
                {
                    Useful.Error_Message(z, true);
                }
                if (OK == true)
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand("UPDATE Users SET Last_Login_Date = @da WHERE Username = @user", conn);
                        DateTime rightnow = DateTime.Now;
                        cmd.Parameters.AddWithValue("@da", rightnow);
                        cmd.Parameters.AddWithValue("@user", textBox1.Text);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception z)
                    {
                        Useful.Error_Message(z, true);
                    }
                }
                else Useful.Error_Message("Error, no account with these credetials!", false);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThreadStart connection = new ThreadStart(() => Useful.TryDatabaseConnection());
            Thread connectionTh = new Thread(connection);
            connectionTh.Start();         
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = Useful.changeText;
            button4.Enabled = Useful.buttons;
            if (Useful.buttons == true) timer1.Enabled = false;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
