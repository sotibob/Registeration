//Name: Sotonte Bob-manuel
//Professor: Ron Enz
//Class: C# Programming CIST 2342_Lab04
//Date: 8th of September,2021.

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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //The events executed when the Clear button is clicked
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox2.Visible = true;
            label2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e) //The events executed when the Login button is clicked
        {
            if(radioButton1.Checked)
            {
                try
                {
                    int Id = int.Parse(textBox1.Text);
                    Student s1 = new Student();
                    s1.SelectDB(Id);
                    if(s1.ID == Id)
                    {
                        StudentInfo sI1 = new StudentInfo(s1);
                        sI1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Student ID!");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if(radioButton2.Checked)
            {
                try
                {
                    String Id = textBox1.Text;
                    int password = int.Parse(textBox2.Text);
                    if (Id == "Admin" && password == 123)
                    {
                        Admin a1 = new Admin();
                        a1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Admin password or ID!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Pick a User!");
            }
        }

        private void button3_Click(object sender, EventArgs e) //The events executed when the Exit button is clicked
        {
            string message = "Are you sure you want to exit?";
            string title = "Exit";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo; //Yes and No dialog buttons
            DialogResult result = MessageBox.Show(message, title, buttons); //Message box

            if (result == DialogResult.Yes) //Yes button
            {
                this.Close(); //Close Applicatiion
            }
            else
            {
                // Do nothing 
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
            textBox2.Visible = false;
            textBox1.Text = null;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            textBox2.Visible = true;
            textBox1.Text = null;
            textBox2.Text = null;
        }
    }
}
