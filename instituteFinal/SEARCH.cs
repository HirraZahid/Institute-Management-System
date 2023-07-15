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
    public partial class SEARCH : Form
    {
        string connectionString = "Data Source=DESKTOP-CPL34M1\\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True";
        public SEARCH()
        {
            InitializeComponent();

            // Assuming you have a DataGridView named dataGridView1

            // Set the AutoSizeColumnsMode property to AllCells
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Set the AutoSizeRowsMode property to AllCells
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            int regi = int.Parse(textBox1.Text);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM student WHERE Studentid = @Reg";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Reg", regi);

                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable tbl = new DataTable();
                sda.Fill(tbl);

                dataGridView1.DataSource = tbl;
                byte[] img = (byte[])tbl.Rows[0][7];
                MemoryStream memory = new MemoryStream(img);
                pictureBox2.Image = Image.FromStream(memory);
                sda.Dispose();
            }

            /*
            int regi = int.Parse(textBox1.Text);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                

                  
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM student WHERE reg=regi", con);
                DataTable tbl = new DataTable();
                sda.Fill(tbl);

                dataGridView1.DataSource = tbl;


            }
            */
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
