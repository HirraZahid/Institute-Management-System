using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.Data.SqlClient;
using System.IO;

namespace instituteFinal
{
    public partial class admission : Form
    {
        string connectionString = "Data Source=DESKTOP-CPL34M1\\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True";
        bool stream;
        Capture capture;
        public admission()
        {
            InitializeComponent();
            pictureBox2.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void admission_Load(object sender, EventArgs e)
        {
            stream = false;
            capture = new Capture();
        }

        private void streaming(object sender, System.EventArgs e)
        {
            var img = capture.QueryFrame().ToImage<Bgr, Byte>();
            var bmp = img.Bitmap;
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!stream)
            {
                Application.Idle += streaming;
                button2.Text = @"Stop Streaming";
                button2.ForeColor = Color.White;
                button2.BackColor = Color.Red;
            }
            else
            {
                Application.Idle -= streaming;
                button2.Text = @"Start Streaming";
                button2.ForeColor = Color.Black;
                button2.BackColor = Color.Green;

            }
            stream = !stream;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string DOB = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            int Studentid = int.Parse(textBox1.Text);
            string Studentname = textBox2.Text;
            string classs = textBox3.Text;
            string section = textBox4.Text;
            string reg = textBox5.Text;
            string address = textBox6.Text;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Validate and convert DOB string to DateTime
                DateTime parsedDate;
                if (!DateTime.TryParse(DOB, out parsedDate))
                {
                    // Invalid date format, show an error message
                    MessageBox.Show("Invalid date of birth format. Please enter a valid date.");
                    return;
                }

                string query = "INSERT INTO student VALUES (@Studentid, @Studentname, @classs, @section, @DOB, @address, @reg, @pic)";
                SqlCommand cmd = new SqlCommand(query, con);

                // Set parameter values
                cmd.Parameters.AddWithValue("@Studentid", Studentid);
                cmd.Parameters.AddWithValue("@Studentname", Studentname);
                cmd.Parameters.AddWithValue("@classs", classs);
                cmd.Parameters.AddWithValue("@section", section);
                cmd.Parameters.AddWithValue("@DOB", parsedDate);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@reg", reg);

                MemoryStream stream = new MemoryStream();
                pictureBox2.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] pic = stream.ToArray();
                cmd.Parameters.AddWithValue("@pic", pic);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Added successfully");
            }





            /*
            String DOB = dateTimePicker1.Text;
            int Studentid =int.Parse( textBox1.Text);
            String Studentname = textBox2.Text;
            String classs = textBox3.Text;
            String section = textBox4.Text;
            String reg = textBox5.Text;
            String address = textBox6.Text;
            SqlConnection con = new SqlConnection(connectionString);
            // Validate and convert publication_date string to DateTime
            DateTime parsedDate;
            if (!DateTime.TryParse(DOB, out parsedDate))
            {
                // Invalid date format, show an error message
                MessageBox.Show("Invalid publication date format. Please enter a valid date.");
                return;
            }
            String query = "insert into student values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "',@DOB,'" + textBox6.Text + "','" + textBox5.Text + "',@pic)";
            SqlCommand cmd = new SqlCommand(query, con);
            MemoryStream stream = new MemoryStream();
            pictureBox2.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] pic = stream.ToArray();
            cmd.Parameters.AddWithValue("@pic", pic);
            cmd.Parameters.AddWithValue("@DOB", DOB);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("added");*/
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
