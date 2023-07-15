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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sTUDENTDETAILToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "contact")
                {
                    isopen = true;
                    f.BringToFront();
                    break;


                }

            }
            if (isopen == false)
            {
                contact RS = new contact();
                RS.Show();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "help")
                {
                    isopen = true;
                    f.BringToFront();
                    break;


                }

            }
            if (isopen == false)
            {
                help RS = new help();
                RS.Show();
            }
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void vIEWALLToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "student")
                {
                    isopen = true;
                    f.BringToFront();
                    break;


                }

            }
            if (isopen == false)
            {
                student RS = new student();
                RS.Show();
            }
        }

        private void searchStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "SEARCH")
                {
                    isopen = true;
                    f.BringToFront();
                    break;


                }

            }
            if (isopen == false)
            {
                SEARCH RS = new SEARCH();
                RS.Show();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aDMISSIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "admission")
                {
                    isopen = true;
                    f.BringToFront();
                    break;


                }

            }
            if (isopen == false)
            {
                admission RS = new admission();
                RS.Show();
            }
        }

        private void tEACHERDETAILToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "teacher")
                {
                    isopen = true;
                    f.BringToFront();
                    break;


                }

            }
            if (isopen == false)
            {
                teacher RS = new teacher();
                RS.Show();
            }
        }

        private void aTTENDENCEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "attendence")
                {
                    isopen = true;
                    f.BringToFront();
                    break;


                }

            }
            if (isopen == false)
            {
                attendence RS = new attendence();
                RS.Show();
            }
        }

        private void rEMOVESTUDENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "delete")
                {
                    isopen = true;
                    f.BringToFront();
                    break;


                }

            }
            if (isopen == false)
            {
                delete RS = new delete();
                RS.Show();
            }
        }

        private void aBOUTUSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
