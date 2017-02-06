using System.Net.NetworkInformation;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Money_Management
{
    class Useful
    {
        #region checkEmptySpaces

        public bool CheckEmptySpaces(GroupBox con)
        {
            foreach (Control co in con.Controls)
                if (co is TextBox)
                    if (string.IsNullOrWhiteSpace(((TextBox)co).Text))
                    {
                        MessageBox.Show("You haven't filled all the values!", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }

            return false;
        }

        public bool CheckEmptySpaces(GroupBox con, params TextBox[] exclusion)
        {
            foreach (Control co in con.Controls)
                if (co is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(((TextBox)co).Text))
                    {
                        bool find = false;
                        foreach (TextBox text in exclusion)
                            if (text.Name == co.Name) find = true;
                        if (find == false)
                        {
                            MessageBox.Show("You haven't filled all the values!", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return true;
                        }
                    }
                }
            return false;
        }

        public bool CheckEmptySpaces(Form form)
        {
            foreach (Control co in form.Controls)
                if (co is TextBox)
                    if (string.IsNullOrWhiteSpace(((TextBox)co).Text))
                    {
                        MessageBox.Show("You haven't filled all the values!", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }

            return false;
        }

        #endregion

        #region clearThings

        public void ClearThings(GroupBox con)
        {
            foreach (Control co in con.Controls)
                if (co is TextBox)
                    ((TextBox)co).Clear();
        }

        public void ClearThings(Form form)
        {
            foreach (Control co in form.Controls)
                if (co is TextBox)
                    ((TextBox)co).Clear();
        }

        #endregion

        #region checkServerConnectionIp
        public static string changeText;
        public static bool buttons = false;
        private static bool PingHost(string ip)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(ip);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            { }
            return pingable;
        }

        private static bool DatabaseConnection(string ip, int port)
        {
            bool connectable = false;
            string connectionString = "SERVER=" + ip + "; " + "Port=" + port + Properties.Settings.Default.ProjectConnectionTemplate;
            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.ConnectionString = connectionString;
                try
                {
                    conn.Open();
                    connectable = true;
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server.  Contact administrator | " + ex.Message);
                            break;

                        case 1045:
                            MessageBox.Show("Invalid username/password, please try again " + ex.Message);
                            break;
                    }
                }
            }
            return connectable;
        }

        public static void TryDatabaseConnection()
        {
            bool OK = false;
            int[] ports = new int[] { 3306, 6999 };
            string[] ips = new string[] { "192.168.1.4", "86.34.214.136", "megabitus.tech" };
            foreach (int port in ports)
            {
                if (OK == true) break;
                foreach (string ip in ips)
                    if (ip != null)
                    {
                        changeText = "Server Status: Trying to contact server: " + ip + ":" + port;
                        if (PingHost(ip) == true && DatabaseConnection(ip, port) == true)
                        {
                            OK = true;
                            buttons = true;
                            changeText = "Server Status: Connected to server: " + ip + ":" + port;
                            Properties.Settings.Default.ProjectConnectionString = "SERVER=" + ip + "; " + "Port=" + port + Properties.Settings.Default.ProjectConnectionTemplate;
                            break;
                        }
                    }
            }
        }
        #endregion

        #region dataAdapterFill

        public void Fill()
        {
            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.ConnectionString = Properties.Settings.Default.ProjectConnectionTemplate;
                conn.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT Username, Last_Login_Date, Administrator FROM Utilizatori", conn))
                {
                    DataSet customers = new DataSet();
                    adapter.Fill(customers, "Username");
                }
            }
        }

        #endregion

        #region Useful Commands

        public static void Error_Message(Exception error, bool close)
        {
            MessageBox.Show("Error, " + error.Message, "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (close == true)
            {
                Application.Exit();
            }
        }

        public static void Error_Message(string error, bool close)
        {
            MessageBox.Show("Error, " + error, "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (close == true)
            {
                Application.Exit();
            }
        }

        #endregion
    }
}
