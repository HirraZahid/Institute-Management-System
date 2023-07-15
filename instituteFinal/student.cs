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

namespace instituteFinal
{
    public partial class student : Form
    {
        string connectionString = "Data Source=DESKTOP-CPL34M1\\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True";
        public student()
        {
            InitializeComponent();
        }

        private void student_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM student ", con);
                DataTable tbl = new DataTable();
                sda.Fill(tbl);

                dataGridView1.DataSource = tbl;


            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
