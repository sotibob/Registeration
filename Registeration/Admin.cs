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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            label1.Text = "Add";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            label1.Text = "Add Student";
            label2.Text = "ID:";
            label3.Text = "First Name:";
            label4.Text = "Last Name:";
            label5.Text = "Street:";
            label6.Text = "City:";
            label7.Text = "State:";
            label8.Text = "ZIP:";
            label9.Text = "Email:";
            label10.Text = "GPA:";
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox9.Text = null;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            label1.Text = "Add Instructor";
            label2.Text = "ID:";
            label3.Text = "First Name:";
            label4.Text = "Last Name:";
            label5.Text = "Street:";
            label6.Text = "City:";
            label7.Text = "State:";
            label8.Text = "ZIP:";
            label9.Text = "Office:";
            label10.Text = "Email:";
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox9.Text = null;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = true;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            textBox5.Visible = true;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            label1.Text = "Add Section";
            label2.Text = "CRN:";
            label3.Text = "Course ID:";
            label4.Text = "TimeDays:";
            label5.Text = "RoomNo:";
            label6.Text = "Instructor ID:";
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            label1.Text = "Add Course";
            label2.Text = "Course ID:";
            label3.Text = "Course Name:";
            label4.Text = "Description:";
            label5.Text = "Credit Hours:";
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
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

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            label1.Text = "Add";
            label2.Text = "ID:";
            label3.Text = "First Name:";
            label4.Text = "Last Name:";
            label5.Text = "Street:";
            label6.Text = "City:";
            label7.Text = "State:";
            label8.Text = "ZIP:";
            label9.Text = "Email:";
            label10.Text = "GPA:";
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox9.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string message = "Are you sure you want to add this Student?";
                string title = "Add Student";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo; //Yes and No dialog buttons
                DialogResult result = MessageBox.Show(message, title, buttons); //Message box

                if (result == DialogResult.Yes) //Yes button
                {
                    try
                    {
                        int ID = int.Parse(textBox1.Text);
                        String Fn = textBox2.Text;
                        String Ln = textBox3.Text;
                        String Street = textBox4.Text;
                        String City = textBox5.Text;
                        String State = textBox6.Text;
                        int ZIP = int.Parse(textBox7.Text);
                        String Email = textBox8.Text;
                        double GPA = double.Parse(textBox9.Text);
                        Address ad1 = new Address(Street, City, State, ZIP);
                        Student s1 = new Student(ID, Fn, Ln, Email, ad1, GPA);
                        s1.InsertDB();
                        s1.SelectDB(ID);
                        if (s1.ID == ID)
                        {
                            MessageBox.Show("Insert Successful");
                        }
                        else
                        {
                            MessageBox.Show("Insert Failed");
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    // Do nothing 
                }
            }
            else if(radioButton2.Checked)
            {
                string message = "Are you sure you want to add this Instructor?";
                string title = "Add Instructor";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo; //Yes and No dialog buttons
                DialogResult result = MessageBox.Show(message, title, buttons); //Message box

                if (result == DialogResult.Yes) //Yes button
                {
                    try
                    {
                        int ID = int.Parse(textBox1.Text);
                        String Fn = textBox2.Text;
                        String Ln = textBox3.Text;
                        String Street = textBox4.Text;
                        String City = textBox5.Text;
                        String State = textBox6.Text;
                        int ZIP = int.Parse(textBox7.Text);
                        String Office = textBox8.Text;
                        String Email = textBox9.Text;
                        Address ad1 = new Address(Street, City, State, ZIP);
                        Instructor Ins1 = new Instructor(ID, Fn, Ln, Email, ad1, Office);
                        Ins1.InsertDB();
                        Ins1.SelectDB(ID);
                        if(Ins1.ID == ID)
                        {
                            MessageBox.Show("Insert Successful");
                        }
                        else
                        {
                            MessageBox.Show("Insert Failed");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    // Do nothing 
                }
            }
            else if(radioButton3.Checked)
            {
                string message = "Are you sure you want to add this Section?";
                string title = "Add Section";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo; //Yes and No dialog buttons
                DialogResult result = MessageBox.Show(message, title, buttons); //Message box

                if (result == DialogResult.Yes) //Yes button
                {
                    try
                    {
                        int crn = int.Parse(textBox1.Text);
                        String cID = textBox2.Text;
                        String TimeDays = textBox3.Text;
                        String roomNo = textBox4.Text;
                        int InstructorID = int.Parse(textBox5.Text);
                        Section sc1 = new Section(crn, cID, TimeDays, roomNo, InstructorID);
                        sc1.InsertDB();
                        sc1.SelectDB(crn);
                        if (sc1.CRN == crn)
                        {
                            MessageBox.Show("Insert Successful");
                        }
                        else
                        {
                            MessageBox.Show("Insert Failed");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    // Do nothing 
                }
            }
            else if(radioButton4.Checked)
            {
                string message = "Are you sure you want to add this Course?";
                string title = "Add Course";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo; //Yes and No dialog buttons
                DialogResult result = MessageBox.Show(message, title, buttons); //Message box

                if (result == DialogResult.Yes) //Yes button
                {
                    try
                    {
                        String cID = textBox1.Text;
                        String cName = textBox2.Text;
                        String desc = textBox3.Text;
                        int cH = int.Parse(textBox4.Text);
                        Course c1 = new Course(cID, cName, cH, desc);
                        c1.InsertDB();
                        c1.SelectDB(cID);
                        if (c1.CourseID == cID)
                        {
                            MessageBox.Show("Insert Successful");
                        }
                        else
                        {
                            MessageBox.Show("Insert Failed");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    // Do nothing 
                }
            }
            else
            {
                MessageBox.Show("Pick an Object to add!");
            }
        }
    }
}
