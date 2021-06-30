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
using System.Drawing.Printing;
using Semipro.Properties;
using System.Globalization;

namespace Semipro
{
    public partial class History : Form
    {
        private List<Class1> allhis = new List<Class1>();
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=e-sport shop;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public History()
        {
            InitializeComponent();
        }
        private void showhistory()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM history"; ;

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        public static void dt()
        {
            DateTime localDate = DateTime.Now;
            DateTime utcDate = DateTime.UtcNow;
            String[] cultureNames = { "en-US", "en-GB", "fr-FR",
                                "de-DE", "ru-RU" };

            foreach (var cultureName in cultureNames)
            {
                var culture = new CultureInfo(cultureName);
                Console.WriteLine("{0}:", culture.NativeName);
                Console.WriteLine("   Local date and time: {0}, {1:G}",
                                  localDate.ToString(culture), localDate.Kind);
                Console.WriteLine("   UTC date and time: {0}, {1:G}\n",
                                  utcDate.ToString(culture), utcDate.Kind);
            }
        }
       
        private void History_Load(object sender, EventArgs e)
        {
            showhistory();

        }
        private void dataseach()
        {
            if (checkBox2.Checked == true)
            {
                usersearch();
                if (checkBox1.Checked == true)
                {
                    usersearch();
                    teamsearch();
                    if (checkBox3.Checked == true)
                    {
                        usersearch();
                        teamsearch();
                        collectionsearch();
                        if (checkBox4.Checked == true)
                        {
                            usersearch();
                            teamsearch();
                            collectionsearch();
                            colorsearch();
                            if (checkBox5.Checked == true)
                            {
                                usersearch();
                                teamsearch();
                                collectionsearch();
                                colorsearch();
                                sizesearch();
                            }
                        }
                    }
                }
            }
            else if (checkBox2.Checked == false)
            {
                if (checkBox1.Checked == true)
                {
                    teamsearch();
                    if (checkBox3.Checked == true)
                    {
                        teamsearch();
                        collectionsearch();
                        if (checkBox4.Checked == true)
                        {
                            teamsearch();
                            collectionsearch();
                            colorsearch();
                            if (checkBox5.Checked == true)
                            {
                                teamsearch();
                                collectionsearch();
                                colorsearch();
                                sizesearch();
                            }
                        }
                    }
                }
            }
            else if (checkBox2.Checked == false)
            {
                if (checkBox1.Checked == false)
                {
                    if (checkBox3.Checked == true)
                    {
                        collectionsearch();
                        if (checkBox4.Checked == true)
                        {
                            collectionsearch();
                            colorsearch();
                            if (checkBox5.Checked == true)
                            {
                                collectionsearch();
                                colorsearch();
                                sizesearch();
                            }
                        }
                    }
                }
            }
            else if (checkBox2.Checked == false)
            {
                if (checkBox1.Checked == false)
                {
                    if (checkBox3.Checked == false)
                    {
                        if (checkBox4.Checked == true)
                        {
                            collectionsearch();
                            colorsearch();
                            if (checkBox5.Checked == true)
                            {
                                collectionsearch();
                                colorsearch();
                                sizesearch();
                            }
                        }
                    }
                }
            }
            else if (checkBox2.Checked == false)
            {
                if (checkBox1.Checked == false)
                {
                    if (checkBox3.Checked == false)
                    {
                        if (checkBox4.Checked == false)
                        {
                            if (checkBox5.Checked == true)
                            {
                                sizesearch();
                            }
                        }
                    }
                }
            }
        }
        private void teamsearch()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM history WHERE team LIKE '%" + textBox5.Text + "%'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        private void collectionsearch()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM history WHERE collection LIKE '%" + textBox4.Text + "%'"; ;

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        private void colorsearch()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM history WHERE color LIKE '%" + textBox3.Text + "%'"; ;

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        private void sizesearch()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM history WHERE size LIKE '%" + textBox2.Text + "%'"; ;

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
       private void usersearch()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM history WHERE username LIKE '%" + textBox1.Text + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void username_KeyPress(object sender, KeyPressEventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM history WHERE username LIKE '%" + textBox1.Text + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void collection_Selected(object sender, EventArgs e)
        {

        }

        private void color_Selected(object sender, EventArgs e)
        {

        }

        private void size_selected(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ADMIN ad = new ADMIN();
            ad.Show();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataseach();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showhistory();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            allhis.Clear();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image image = Resources.db;
            e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            e.Graphics.DrawString("Data: " + DateTime.Now.ToShortDateString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 160));
            e.Graphics.DrawString("ALL History ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 190));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 230));
            e.Graphics.DrawString("User", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 250));
            e.Graphics.DrawString("Collection", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(95, 250));
            e.Graphics.DrawString("Size", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(300, 250));
            e.Graphics.DrawString("Color", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(370, 250));
            e.Graphics.DrawString("Custom", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(440, 250));
            e.Graphics.DrawString("Price", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(530, 250));
            e.Graphics.DrawString("Amount", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(580, 250));
            e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(650, 250));
            e.Graphics.DrawString("Date Time", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(750, 250));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 265));
            int yPos = 290;
            //int index = dataGridView1.CurrentCell.RowIndex;
            //data.RemoveAt(index);
            //dataGridView1.DataSource = null;;
            loaddata();
            foreach (var i in allhis)
            {
                e.Graphics.DrawString(i.Username, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos));
                e.Graphics.DrawString(i.Collection, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(95, yPos));
                e.Graphics.DrawString(i.Size, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(300, yPos));
                e.Graphics.DrawString(i.Color, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(370, yPos));
                e.Graphics.DrawString(i.Custom, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(440, yPos));
                e.Graphics.DrawString(i.Price, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(530, yPos));
                e.Graphics.DrawString(i.Amount, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(580, yPos));
                e.Graphics.DrawString(i.Total, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(650, yPos));
                e.Graphics.DrawString(i.Datetime, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(750, yPos));

                yPos += 30;
            }
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, yPos));
            e.Graphics.DrawString("   Total Price:   " + textBox6.Text + " ฿", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, yPos + 30));
        }
        private void loaddata()
        {
            MySqlConnection conn = new MySqlConnection("host=127.0.0.1;username=root;password=;database=e-sport shop;");

            conn.Open();

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM history WHERE datetime between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "'", conn);
            MySqlDataReader adapter = cmd.ExecuteReader();

            while (adapter.Read())
            {
                Program.username = adapter.GetString("username");
                Program.collection = adapter.GetString("collection");
                Program.color = adapter.GetString("color");
                Program.size = adapter.GetString("size");
                Program.custom = adapter.GetString("custom");
                Program.price = adapter.GetString("price");
                Program.amount = adapter.GetString("amount");
                Program.total = adapter.GetString("total");
                Program.datetime = adapter.GetString("datetime");

                Class1 item = new Class1()
                {
                    Username = Program.username,
                    Collection = Program.collection,
                    Price = Program.price,
                    Size = Program.size,
                    Color = Program.color,
                    Custom = Program.custom,
                    Amount = Program.amount,
                    Total = Program.total,
                    Datetime = Program.datetime,
                };
                allhis.Add(item);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlDataAdapter sdt = new MySqlDataAdapter("SELECT * FROM history WHERE datetime between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "'", conn);
            DataTable dt = new DataTable();
            sdt.Fill(dt);
            dataGridView1.DataSource = dt;
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);

            }
            textBox6.Text = sum.ToString();

        }
    }
}
