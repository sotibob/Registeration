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
    public partial class AddSchedule : Form
    {
        Student s1;
        public AddSchedule()
        {
            InitializeComponent();
        }
        public AddSchedule(Student s)
        {
            InitializeComponent();
            s1 = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to close this window?";
            string title = "Close Window";

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
            string message = "Are you sure you want to add this class to your Schedule?";
            string title = "Add Class";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo; //Yes and No dialog buttons
            DialogResult result = MessageBox.Show(message, title, buttons); //Message box

            if (result == DialogResult.Yes) //Yes button
            {
                try
                {
                    int crn = int.Parse(textBox1.Text);
                    int ID = s1.ID;
                    Section sc1 = new Section();
                    sc1.SelectDB(crn);
                    if (sc1.CRN == crn)
                    {
                        s1.DBSetup();
                        s1.cmd = "INSERT into StudentSchedule values(" + ID + ", " + crn + ")";

                        s1.OleDbDataAdapter2.InsertCommand.CommandText = s1.cmd;
                        s1.OleDbDataAdapter2.InsertCommand.Connection = s1.OleDbConnection2;
                        Console.WriteLine(s1.cmd);
                        try
                        {
                            s1.OleDbConnection2.Open();
                            int n = s1.OleDbDataAdapter2.InsertCommand.ExecuteNonQuery();
                            if (n == 1)
                            {
                                Console.WriteLine("Data Inserted");
                                MessageBox.Show("Successfully added!");
                                s1.schedule.count = 0;
                                s1.SelectDB(ID);
                            }
                            else
                            {
                                Console.WriteLine("ERROR: Inserting Data");
                                MessageBox.Show("Adding Failed!");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        finally
                        {
                            s1.OleDbConnection2.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Input a valid CRN!");
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
    }
}
