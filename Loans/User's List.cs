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
    public partial class User_s_List : Form
    {
        private string user;
        private int admin;
        public User_s_List(string username, int Admin)
        {
            InitializeComponent();
            user = username;
            admin = Admin;
        }

        private void User_s_List_Load(object sender, EventArgs e)
        {
            using (MySqlConnection c = new MySqlConnection(Properties.Settings.Default.ProjectConnectionString))
            {
                try
                {
                    c.Open();
                    using (MySqlDataAdapter cmd = new MySqlDataAdapter("SELECT Username, Last_Login_Date, Administrator FROM Users", c))
                    {
                        DataTable table = new DataTable();
                        cmd.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }
                catch (Exception z)
                {
                    MessageBox.Show("Error, " + z.Message, "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu m = new Main_Menu(user, admin);
            m.Show();
        }
    }
}
