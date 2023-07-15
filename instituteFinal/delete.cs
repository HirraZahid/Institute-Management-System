using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace instituteFinal
{
    public partial class delete : Form
    {
        string connectionString = "Data Source=DESKTOP-CPL34M1\\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True";

        public delete()
        {
            InitializeComponent();
        }

        private void delete_Load(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete student where studentid='" + textBox1.Text + "' ", con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter("select * from student ", con);
                DataTable tbl = new DataTable();
                sda.Fill(tbl);

                dataGridView1.DataSource = tbl;
                MessageBox.Show("deleted");
                con.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                
                SqlDataAdapter sda = new SqlDataAdapter("select * from student where studentid='"+textBox1.Text+"'", con);
                DataTable tbl = new DataTable();
                sda.Fill(tbl);
                dataGridView1.DataSource = tbl;
                byte[] img = (byte[])tbl.Rows[0][7];
                MemoryStream memory = new MemoryStream(img);
                pictureBox1.Image =Image.FromStream(memory);
                sda.Dispose();

            }
        }
    }
}
