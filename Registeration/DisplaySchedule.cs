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
    public partial class DisplaySchedule : Form
    {
        Student s1;
        int tcount;
        int count = 0;
        public DisplaySchedule()
        {
            InitializeComponent();
        }
        public DisplaySchedule(Student s)
        {
            InitializeComponent();
            s1 = s;
            tcount = s1.schedule.count;
            label3.Text = s1.schedule.s1[count].CRN.ToString();
            label5.Text = s1.schedule.s1[count].CourseID;
            label7.Text = s1.schedule.s1[count].TimeDays;
            label9.Text = s1.schedule.s1[count].RoomNo;
            label11.Text = s1.schedule.s1[count].InstructorID.ToString();
            count++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to close Schedule?";
            string title = "Close Schedule";

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
            if(count == 0 && tcount > 1)
            {
                count++;
                label3.Text = s1.schedule.s1[count].CRN.ToString();
                label5.Text = s1.schedule.s1[count].CourseID;
                label7.Text = s1.schedule.s1[count].TimeDays;
                label9.Text = s1.schedule.s1[count].RoomNo;
                label11.Text = s1.schedule.s1[count].InstructorID.ToString();
            }
            else if (count < tcount)
            {
                label3.Text = s1.schedule.s1[count].CRN.ToString();
                label5.Text = s1.schedule.s1[count].CourseID;
                label7.Text = s1.schedule.s1[count].TimeDays;
                label9.Text = s1.schedule.s1[count].RoomNo;
                label11.Text = s1.schedule.s1[count].InstructorID.ToString();
                count++;
            }
            else
            {
                MessageBox.Show("There are no more classes on your Schedule!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(count == tcount && count > 1)
            {
                count = count - 2;
                label3.Text = s1.schedule.s1[count].CRN.ToString();
                label5.Text = s1.schedule.s1[count].CourseID;
                label7.Text = s1.schedule.s1[count].TimeDays;
                label9.Text = s1.schedule.s1[count].RoomNo;
                label11.Text = s1.schedule.s1[count].InstructorID.ToString();
            }
            else if(count > 0)
            {
                count--;
                label3.Text = s1.schedule.s1[count].CRN.ToString();
                label5.Text = s1.schedule.s1[count].CourseID;
                label7.Text = s1.schedule.s1[count].TimeDays;
                label9.Text = s1.schedule.s1[count].RoomNo;
                label11.Text = s1.schedule.s1[count].InstructorID.ToString();
            }
            else
            {

            }
        }
    }
}
