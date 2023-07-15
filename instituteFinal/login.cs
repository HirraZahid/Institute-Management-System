using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace instituteFinal
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            String username = textBox1.Text;
            String password = textBox2.Text;
            if(username=="admin"&& password == "123")
            {
                form1.Show();
                this.Hide();
            }
        }
    }
}
