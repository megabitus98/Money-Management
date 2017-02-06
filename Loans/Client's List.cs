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
    public partial class Client_s_List : Form
    {
        private string user;
        private int admin;
        public Client_s_List(string username, int Admin)
        {
            InitializeComponent();
            user = username;
            admin = Admin;
        }

        private void Client_s_List_Load(object sender, EventArgs e)
        {
            using (MySqlConnection c = new MySqlConnection(Properties.Settings.Default.ProjectConnectionString))
            {
                try
                {
                    c.Open();
                    using (MySqlDataAdapter cmd = new MySqlDataAdapter("SELECT * FROM Clients", c))
                    {
                        DataTable table = new DataTable();
                        cmd.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }
                catch (Exception z)
                {
                    Useful.Error_Message(z, true);
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu m = new Main_Menu(user, admin);
            m.Show();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
