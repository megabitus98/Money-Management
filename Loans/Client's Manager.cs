﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Money_Management
{
    public partial class Add_Client : Form
    {
        Useful useful = new Useful();
        private string user;
        private int admin;
        public Add_Client(string username, int Admin)
        {
            InitializeComponent();
            user = username;
            admin = Admin;
        }

        private void Add_Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main_Menu m = new Main_Menu(user, admin);
            m.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (useful.CheckEmptySpaces(Add_Client_GroupBox, Surname, Email, Phone))
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Properties.Settings.Default.ProjectConnectionString;
                    try
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Clients (Name, Phone, Added_Time, Email)" +
                                                                "values(@Name, @Phone, @Time, @Email)", conn))
                        {
                            cmd.Parameters.AddWithValue("@Phone", Phone.Text);
                            DateTime rightnow = DateTime.Now;
                            cmd.Parameters.AddWithValue("@Time", rightnow);
                            cmd.Parameters.AddWithValue("@Email", Email.Text);
                            cmd.Parameters.AddWithValue("@Name", NameA.Text + " " + Surname.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception z)
                    {
                        Useful.Error_Message(z, true);
                    }
                }
                foreach (Control tb in Add_Client_GroupBox.Controls)
                {
                    if (tb is TextBox)
                    {
                        ((TextBox)tb).Clear();
                    }
                }
            }
            using (MySqlConnection c = new MySqlConnection(Properties.Settings.Default.ProjectConnectionString))
            {
                try
                {
                    c.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT Name FROM Clients", c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        Clients_List.ValueMember = "Name";
                        Clients_List.DisplayMember = "Name";
                        Clients_List.DataSource = dt;
                    }
                }
                catch (Exception z)
                {
                    Useful.Error_Message(z, true);
                }
            }
        }

        private void Add_Client_Load(object sender, EventArgs e)
        {
            using (MySqlConnection c = new MySqlConnection(Properties.Settings.Default.ProjectConnectionString))
            {
                try
                {
                    c.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT Name FROM Clients", c))
                    {
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        Clients_List.ValueMember = "Name";
                        Clients_List.DisplayMember = "Name";
                        Clients_List.DataSource = dt;
                    }
                }
                catch (Exception z)
                {
                    Useful.Error_Message(z, true);
                }
            }
            CCI.Enabled = false;
            DC.Enabled = false;
            Clients_List.Enabled = false;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            Main_Menu m = new Main_Menu(user, admin);
            m.Show();
            this.Hide();
        }
        private void Mod_client()
        {
            if (CCI.Enabled == false)
            {
                Add_Client_GroupBox.Enabled = false;
                CCI.Enabled = true;
                if (admin == 1)
                    DC.Enabled = true;
                Clients_List.Enabled = true;
                AddInfo();
            }
            else
            {
                Add_Client_GroupBox.Enabled = true;
                CCI.Enabled = false;
                DC.Enabled = false;
                Clients_List.Enabled = false;
                foreach (Control con in CCI.Controls)
                {
                    if (con is TextBox)
                    {
                        ((TextBox)con).Clear();
                    }
                }
            }
        }

        private void AddInfo()
        {
            if (Mod_Client_Info.Enabled == true)
            {
                Selected.Text = "Selected Client: " + Clients_List.Text;
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Properties.Settings.Default.ProjectConnectionString;
                    try
                    {
                        conn.Open();
                        using (MySqlCommand command = new MySqlCommand("SELECT Name, Email, Phone FROM Clients WHERE Name = @Name", conn))
                        {
                            command.Parameters.AddWithValue("@Name", Clients_List.Text);
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    NameC.Text = (string)reader["Name"];
                                    EmailC.Text = (string)reader["Email"];
                                    PhoneC.Text = (string)reader["Phone"];
                                }
                            }
                        }
                    }
                    catch (Exception z)
                    {
                        Useful.Error_Message(z, true);
                    }
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Mod_client();
        }

        private void Clients_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Add_Client_GroupBox.Enabled == false) AddInfo();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (Clients_List.Text != null)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete the folowing user: " + Clients_List.Text + "?", "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (confirmResult == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection())
                    {
                        conn.ConnectionString = Properties.Settings.Default.ProjectConnectionString;
                        try
                        {
                            conn.Open();
                            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Clients WHERE Name=@us", conn))
                            {
                                cmd.Parameters.AddWithValue("@us", Clients_List.Text);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception z)
                        {
                            Useful.Error_Message(z, true);
                        }
                    }
                    using (MySqlConnection c = new MySqlConnection(Properties.Settings.Default.ProjectConnectionString))
                    {
                        try
                        {
                            c.Open();
                            using (MySqlCommand cmd = new MySqlCommand("SELECT Name FROM Clients", c))
                            {
                                var dt = new DataTable();
                                dt.Load(cmd.ExecuteReader());
                                Clients_List.ValueMember = "Name";
                                Clients_List.DisplayMember = "Name";
                                Clients_List.DataSource = dt;
                            }
                        }
                        catch (Exception z)
                        {
                            Useful.Error_Message(z, true);
                        }
                    }
                }
            }
            else MessageBox.Show("Please select a valid user!", "No user selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (useful.CheckEmptySpaces(CCI, EmailC, PhoneC) == false)
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Properties.Settings.Default.ProjectConnectionString;
                    try
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand("UPDATE Clients SET Name=@Name, " +
                                                            "Email=@Email, Phone=@Phone WHERE Name = @FNO", conn))
                        {
                            cmd.Parameters.AddWithValue("@Name", NameC.Text);
                            cmd.Parameters.AddWithValue("@Phone", PhoneC.Text);
                            cmd.Parameters.AddWithValue("@Email", EmailC.Text);
                            cmd.Parameters.AddWithValue("@FNO", Clients_List.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Changed " + "values for " + NameC.Text, "Modify suceded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception z)
                    {
                        Useful.Error_Message(z, true);
                    }
                    using (MySqlConnection c = new MySqlConnection(Properties.Settings.Default.ProjectConnectionString))
                    {
                        try
                        {
                            c.Open();
                            using (MySqlCommand cmd = new MySqlCommand("SELECT Name FROM Clients", c))
                            {
                                var dt = new DataTable();
                                dt.Load(cmd.ExecuteReader());
                                Clients_List.ValueMember = "Name";
                                Clients_List.DisplayMember = "Name";
                                Clients_List.DataSource = dt;
                            }
                        }
                        catch (Exception z)
                        {
                            Useful.Error_Message(z, true);
                        }
                    }
                    Selected.Text = "Selected Client: " + Clients_List.Text;
                    Mod_client();
                }
            }
        }

    }
}