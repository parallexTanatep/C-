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
using System.IO;
using Semipro.Properties;


namespace Semipro
{
    public partial class ADMIN : Form
    {
        public ADMIN()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=e-sport shop;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void showpro()
        {

            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM product"; ;

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        private void comboteam()
        {
            MySqlConnection conn1 = databaseConnection();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter("SELECT DISTINCT team FROM product", conn1);
            DataTable table = new DataTable();
            adapter2.Fill(table);
            conn1.Open();
            comboBox1.DataSource = table;
            comboBox1.ValueMember = "team";
            comboBox1.DisplayMember = "team";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            showpro();
            comboteam();
        }

        private void product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["color"].FormattedValue.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["collection"].FormattedValue.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["amount"].FormattedValue.ToString();
            MySqlConnection conn = databaseConnection();
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            int pic = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);
            String sql = "SELECT * FROM product WHERE id = '" + pic + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            conn.Open();
            byte[] img = (byte[])table.Rows[0][5];
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
            da.Dispose();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            int editid = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);
            MySqlConnection conn = databaseConnection();
            String sql = "UPDATE  product SET collection = '" + textBox4.Text + "', color = '" + textBox2.Text + "', price = '" + textBox7.Text + "', amount = '" + textBox1.Text + "', image = @image  WHERE id = '" + editid + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.Parameters.Add("@image", MySqlDbType.Blob);
            cmd.Parameters["@image"].Value = img;
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
            {
                MessageBox.Show("Repair Data Complete");
                showpro();
                comboteam();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();
            MySqlConnection conn = databaseConnection();
            String sql = "INSERT INTO product (team,collection,color,price,amount,image) VALUES('" + textBox3.Text + "' , '" + textBox4.Text + "', '" + textBox2.Text + "','" + textBox7.Text + "', '" + textBox1.Text + "',@image)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.Parameters.Add("@image", MySqlDbType.Blob);
            cmd.Parameters["@image"].Value = img;
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
            {
                MessageBox.Show("Add Product Complete");
                comboteam();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
            
        }

        private void team_select(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    MySqlConnection conn = databaseConnection();
                    DataSet ds = new DataSet();
                    conn.Open();

                    MySqlCommand cmd;
                    cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM product WHERE team LIKE '%" + comboBox1.Text + "%'"; ;

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(ds);

                    conn.Close();
                    dataGridView1.DataSource = ds.Tables[0].DefaultView; break;
                case 1:
                    MySqlConnection conn1 = databaseConnection();
                    DataSet ds1 = new DataSet();
                    conn1.Open();

                    MySqlCommand cmd1;
                    cmd1 = conn1.CreateCommand();
                    cmd1.CommandText = "SELECT * FROM product WHERE team LIKE '%" + comboBox1.Text + "%'"; ;

                    MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
                    adapter1.Fill(ds1);

                    conn1.Close();
                    dataGridView1.DataSource = ds1.Tables[0].DefaultView; break;
                case 2:
                    MySqlConnection conn2 = databaseConnection();
                    DataSet ds2 = new DataSet();
                    conn2.Open();

                    MySqlCommand cmd2;
                    cmd2 = conn2.CreateCommand();
                    cmd2.CommandText = "SELECT * FROM product WHERE team LIKE '%" + comboBox1.Text + "%'"; ;

                    MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd2);
                    adapter2.Fill(ds2);

                    conn2.Close();
                    dataGridView1.DataSource = ds2.Tables[0].DefaultView; break;
                case 3:
                    MySqlConnection conn3 = databaseConnection();
                    DataSet ds3 = new DataSet();
                    conn3.Open();

                    MySqlCommand cmd3;
                    cmd3 = conn3.CreateCommand();
                    cmd3.CommandText = "SELECT * FROM product WHERE team LIKE '%" + comboBox1.Text + "%'"; ;

                    MySqlDataAdapter adapter3 = new MySqlDataAdapter(cmd3);
                    adapter3.Fill(ds3);

                    conn3.Close();
                    dataGridView1.DataSource = ds3.Tables[0].DefaultView; break;
                case 4:
                    MySqlConnection conn4 = databaseConnection();
                    DataSet ds4 = new DataSet();
                    conn4.Open();

                    MySqlCommand cmd4;
                    cmd4 = conn4.CreateCommand();
                    cmd4.CommandText = "SELECT * FROM product WHERE team LIKE '%" + comboBox1.Text + "%'"; ;

                    MySqlDataAdapter adapter4 = new MySqlDataAdapter(cmd4);
                    adapter4.Fill(ds4);

                    conn4.Close();
                    dataGridView1.DataSource = ds4.Tables[0].DefaultView; break;
                case 5:
                    MySqlConnection conn5 = databaseConnection();
                    DataSet ds5 = new DataSet();
                    conn5.Open();

                    MySqlCommand cmd5;
                    cmd5 = conn5.CreateCommand();
                    cmd5.CommandText = "SELECT * FROM product WHERE team LIKE '%" + comboBox1.Text + "%'"; ;

                    MySqlDataAdapter adapter5 = new MySqlDataAdapter(cmd5);
                    adapter5.Fill(ds5);

                    conn5.Close();
                    dataGridView1.DataSource = ds5.Tables[0].DefaultView; break;
                case 6:
                    MySqlConnection conn6 = databaseConnection();
                    DataSet ds6 = new DataSet();
                    conn6.Open();

                    MySqlCommand cmd6;
                    cmd6 = conn6.CreateCommand();
                    cmd6.CommandText = "SELECT * FROM product WHERE team LIKE '%" + comboBox1.Text + "%'"; ;

                    MySqlDataAdapter adapter6 = new MySqlDataAdapter(cmd6);
                    adapter6.Fill(ds6);

                    conn6.Close();
                    dataGridView1.DataSource = ds6.Tables[0].DefaultView; break;

            };
        }

        private void ออกจากระบบToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout Complete");
            Login frm1 = new Login();
            frm1.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            History frm1 = new History();
            frm1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            int deleteid = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);
            MySqlConnection conn = databaseConnection();
            String sql = "DELETE FROM product WHERE id = '" + deleteid + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
            {
                MessageBox.Show("Remove Complete");
                showpro();
                comboteam();
            }
        }
        private void loaddata()
        {
            MySqlConnection conn = new MySqlConnection("host=127.0.0.1;username=root;password=;database=e-sport shop;");

            conn.Open();

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM product", conn);
            MySqlDataReader adapter = cmd.ExecuteReader();

            while (adapter.Read())
            {
                Program.team = adapter.GetString("team");
                Program.collection = adapter.GetString("collection");
                Program.color = adapter.GetString("color");
                Program.price = adapter.GetString("price");
                Program.amount = adapter.GetString("amount");
               

                Class1 item = new Class1()
                {
                    Team = Program.team,
                    Collection = Program.collection,
                    Price = Program.price,
                    Color = Program.color,
                    Amount = Program.amount,
                };
                allpro.Add(item);
            }
        }
        private void teamdata()
        {
          
            MySqlConnection conn = new MySqlConnection("host=127.0.0.1;username=root;password=;database=e-sport shop;");

            conn.Open();

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM product WHERE team LIKE '%" + comboBox1.Text + "%'", conn);
            MySqlDataReader adapter = cmd.ExecuteReader();

            while (adapter.Read())
            {
                Program.team = adapter.GetString("team");
                Program.collection = adapter.GetString("collection");
                Program.color = adapter.GetString("color");
                Program.price = adapter.GetString("price");
                Program.amount = adapter.GetString("amount");


                Class1 item = new Class1()
                {
                    Team = Program.team,
                    Collection = Program.collection,
                    Price = Program.price,
                    Color = Program.color,
                    Amount = Program.amount,
                };
                teampro.Add(item);
            }
        }
        private List<Class1> allpro = new List<Class1>();
        private List<Class1> teampro = new List<Class1>();
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image image = Resources.db;
            e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            e.Graphics.DrawString("Data: " + DateTime.Now.ToShortDateString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 160));
            e.Graphics.DrawString("ALL Product ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 190));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 230));
            e.Graphics.DrawString("Team", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 250));
            e.Graphics.DrawString("Collection", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(200, 250));
            e.Graphics.DrawString("Color", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(500, 250));
            e.Graphics.DrawString("Price", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, 250));
            e.Graphics.DrawString("Amount", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(750, 250));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 265));
            int yPos = 290;
            //int index = dataGridView1.CurrentCell.RowIndex;
            //data.RemoveAt(index);
            //dataGridView1.DataSource = null;;
            loaddata();
            foreach (var i in allpro)
            {
                e.Graphics.DrawString(i.Team, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos));
                e.Graphics.DrawString(i.Collection, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(200, yPos));
                e.Graphics.DrawString(i.Color, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(500, yPos));
                e.Graphics.DrawString(i.Price, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, yPos));
                e.Graphics.DrawString(i.Amount, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(750, yPos));

                yPos += 30;
            }
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, yPos));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image image = Resources.db;
            e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            e.Graphics.DrawString("Data: " + DateTime.Now.ToShortDateString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 160));
            e.Graphics.DrawString("ALL Product ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 190));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 230));
            e.Graphics.DrawString("Team", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 250));
            e.Graphics.DrawString("Collection", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(200, 250));
            e.Graphics.DrawString("Color", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(500, 250));
            e.Graphics.DrawString("Price", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, 250));
            e.Graphics.DrawString("Amount", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(750, 250));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 265));
            int yPos = 290;
            //int index = dataGridView1.CurrentCell.RowIndex;
            //data.RemoveAt(index);
            //dataGridView1.DataSource = null;;
            teamdata();
            foreach (var i in teampro)
            {
                e.Graphics.DrawString(i.Team, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos));
                e.Graphics.DrawString(i.Collection, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(200, yPos));
                e.Graphics.DrawString(i.Color, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(500, yPos));
                e.Graphics.DrawString(i.Price, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, yPos));
                e.Graphics.DrawString(i.Amount, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(750, yPos));

                yPos += 30;
            }
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, yPos));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            printPreviewDialog2.Document = printDocument2;
            printPreviewDialog2.ShowDialog();
            teampro.Clear();
        }
    }
}
