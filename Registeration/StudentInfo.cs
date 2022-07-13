using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registeration
{
    public partial class StudentInfo : Form
    {
        Student s1;
        public StudentInfo()
        {
            InitializeComponent();
        }
        

        public StudentInfo(Student s)
        {
            
            InitializeComponent();
            s1 = s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to Logout?";
            string title = "Logout";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo; //Yes and No dialog buttons
            DialogResult result = MessageBox.Show(message, title, buttons); //Message box

            if (result == DialogResult.Yes) //Yes button
            {
                this.Close();
            }
            else
            {
                // Do nothing 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddSchedule as1 = new AddSchedule(s1);
            as1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplaySchedule ds1 = new DisplaySchedule(s1);
            ds1.Show();
        }

        private void StudentInfo_Load(object sender, EventArgs e)
        {
            label1.Text = "Student " + s1.ID;
            label3.Text = s1.FirstName;
            label5.Text = s1.LastName;
            label7.Text = s1.Email;
            label9.Text = s1.GPA.ToString();
        }
    }
}
