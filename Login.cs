using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Semipro
{
    public partial class Login : Form
    {
        string a;
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=e-sport shop;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register fm = new Register();
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand cmd;

                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM datauser WHERE username ='" + textBox1.Text + "'AND password ='" + textBox2.Text + "'";

                MySqlDataReader row = cmd.ExecuteReader();
                if (row.Read())
                {
                    MessageBox.Show("Login Complete");
                    a = textBox1.Text;
                    Shop frm = new Shop();
                    frm.ab(a.ToString());
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Username or Password incorrect");
                }
                conn.Close();
            }
            else if (radioButton2.Checked)
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand cmd;

                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM dataadmin WHERE id ='" + textBox1.Text + "'AND password ='" + textBox2.Text + "'";

                MySqlDataReader row = cmd.ExecuteReader();
                if (row.Read())
                {
                    MessageBox.Show("Login Complete");
                    a = textBox1.Text;
                    ADMIN frm = new ADMIN();
                    //frm.ab(a.ToString());
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Username or Password incorrect");
                }
            }

        }

        private void OnKeyDownHandler(object sender, KeyEventArgs kea)
        {
            if (kea.KeyCode.Equals(Keys.Return))
            {
                if (radioButton1.Checked)
                {
                    MySqlConnection conn = databaseConnection();
                    conn.Open();
                    MySqlCommand cmd;

                    cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM datauser WHERE username ='" + textBox1.Text + "'AND password ='" + textBox2.Text + "'";

                    MySqlDataReader row = cmd.ExecuteReader();
                    if (row.Read())
                    {
                        MessageBox.Show("Login Complete");
                        a = textBox1.Text;
                        Shop frm = new Shop();
                        frm.ab(a.ToString());
                        this.Hide();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username or Password incorrect");
                    }
                    conn.Close();
                }
                else if (radioButton2.Checked)
                {
                    MySqlConnection conn = databaseConnection();
                    conn.Open();
                    MySqlCommand cmd;

                    cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM dataadmin WHERE id ='" + textBox1.Text + "'AND password ='" + textBox2.Text + "'";

                    MySqlDataReader row = cmd.ExecuteReader();
                    if (row.Read())
                    {
                        MessageBox.Show("Login Complete");
                        a = textBox1.Text;
                        ADMIN frm = new ADMIN();
                        //frm.ab(a.ToString());
                        this.Hide();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username or Password incorrect");
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }
    }
}
