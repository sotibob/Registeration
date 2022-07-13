//Name: Sotonte Bob-manuel
//Class: C# Programming CIST 2342_Lab05
//I wrote this code myself

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registeration
{
    class Course
    {
        private String courseID;
        private String courseName;
        private int creditHours;
        private String desc;

        public Course() // Default Constructor
        {
            courseID = "CIST 1001";
            courseName = "Computer Concepts";
            creditHours = 4;
            desc = "This course is about the introduction of the concepts of computer to a beginner";
        }

        public Course(String CourseID, String CourseName, int CreditHours, String Desc) // Constructor that passes variables
        {
            courseID = CourseID;
            courseName = CourseName;
            creditHours = CreditHours;
            desc = Desc;
        }

        //Set and get methods for the variables instantiated
        public String CourseID
        {
            set { courseID = value; }
            get { return courseID; }
        }

        public String CourseName
        {
            set { courseName = value; }
            get { return courseName; }
        }

        public int CreditHours
        {
            set { creditHours = value; }
            get { return creditHours; }
        }

        public String Desc
        {
            set { desc = value; }
            get { return desc; }
        }

        public void Display() // Display method to display all the data received
        {
            Console.WriteLine("CourseID: " + courseID);
            Console.WriteLine("CourseName: " + courseName);
            Console.WriteLine("CreditHours: " + creditHours);
            Console.WriteLine("Desc: " + desc);
            Console.WriteLine("=======================");
            Console.WriteLine("=======================");
        }

		//=============================  BEHAVIORS =========================
		//++++++++++++++++  DATABASE Data Elements +++++++++++++++++
		public System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter2;
		public System.Data.OleDb.OleDbCommand OleDbSelectCommand2;
		public System.Data.OleDb.OleDbCommand OleDbInsertCommand2;
		public System.Data.OleDb.OleDbCommand OleDbUpdateCommand2;
		public System.Data.OleDb.OleDbCommand OleDbDeleteCommand2;
		public System.Data.OleDb.OleDbConnection OleDbConnection2;
		public string cmd;

		public void DBSetup()
		{
			// +++++++++++++++++++++++++++  DBSetup function +++++++++++++++++++++++++++++++
			OleDbDataAdapter2 = new System.Data.OleDb.OleDbDataAdapter();
			OleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			OleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			OleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			OleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			OleDbConnection2 = new System.Data.OleDb.OleDbConnection();

			//OleDbDataAdapter1
			OleDbDataAdapter2.DeleteCommand = OleDbDeleteCommand2;
			OleDbDataAdapter2.InsertCommand = OleDbInsertCommand2;
			OleDbDataAdapter2.SelectCommand = OleDbSelectCommand2;
			OleDbDataAdapter2.UpdateCommand = OleDbUpdateCommand2;

			OleDbConnection2.ConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database L" +
			"ocking Mode=1;Data Source=c:\\Users\\Sotonte Bob-manuel\\OneDrive\\Documents\\Java DB\\RegistrationMDB.mdb;J" +
			"et OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System datab" +
			"ase=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=S" +
			"hare Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet " +
			"OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repai" +
			"r=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
		}  //end DBSetup()


		public void SelectDB(String id)
		{ //++++++++++++++++++++++++++  SELECT +++++++++++++++++++++++++
			DBSetup();
			cmd = "Select * from Courses where CourseID = '" + id + "'";
			OleDbDataAdapter2.SelectCommand.CommandText = cmd;
			OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
			Console.WriteLine(cmd);
			try
			{
				OleDbConnection2.Open();
				System.Data.OleDb.OleDbDataReader dr;
				dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();

				dr.Read();
				CourseID = dr.GetValue(0) + "";
				CourseName = dr.GetValue(1) + "";
				Desc = dr.GetValue(2) + "";
				CreditHours = Int32.Parse(dr.GetValue(3) + "");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			finally
			{
				OleDbConnection2.Close();
			}
		} //end SelectDB()



		public void InsertDB()
		{
			// +++++++++++++++++++++++++++  INSERT +++++++++++++++++++++++++++++++

			DBSetup();
			cmd = "INSERT into Courses values('" + CourseID + "', '" +
									CourseName + "', '" +
								Desc + "', " + CreditHours + ")";

			OleDbDataAdapter2.InsertCommand.CommandText = cmd;
			OleDbDataAdapter2.InsertCommand.Connection = OleDbConnection2;
			Console.WriteLine(cmd);
			try
			{
				OleDbConnection2.Open();
				int n = OleDbDataAdapter2.InsertCommand.ExecuteNonQuery();
				if (n == 1)
					Console.WriteLine("Data Inserted");
				else
					Console.WriteLine("ERROR: Inserting Data");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			finally
			{
				OleDbConnection2.Close();
			}
		} //end InsertDB()



		public void updateDB()
		{
			//++++++++++++++++++++++++++  UPDATE  +++++++++++++++++++++++++

			cmd = "Update Courses set CourseName = '" + CourseName +
						 "', Description = '" + Desc + "', CreditHours = " + CreditHours +
						 " where CourseID = '" + CourseID + "'";

			OleDbDataAdapter2.UpdateCommand.CommandText = cmd;
			OleDbDataAdapter2.UpdateCommand.Connection = OleDbConnection2;
			Console.WriteLine(cmd);
			try
			{
				OleDbConnection2.Open();
				int n = OleDbDataAdapter2.UpdateCommand.ExecuteNonQuery();
				if (n == 1)
					Console.WriteLine("Data Updated");
				else
					Console.WriteLine("ERROR: Updating Data");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			finally
			{
				OleDbConnection2.Close();
			}
		} //end UpdateDB()



		public void deleteDB()
		{
			//++++++++++++++++++++++++++  DELETE  +++++++++++++++++++++++++

			cmd = "Delete from Courses where CourseID = '" + CourseID + "'";
			OleDbDataAdapter2.DeleteCommand.CommandText = cmd;
			OleDbDataAdapter2.DeleteCommand.Connection = OleDbConnection2;
			Console.WriteLine(cmd);
			try
			{
				OleDbConnection2.Open();
				int n = OleDbDataAdapter2.DeleteCommand.ExecuteNonQuery();
				if (n == 1)
					Console.WriteLine("Data Deleted");
				else
					Console.WriteLine("ERROR: Deleting Data");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			finally
			{
				OleDbConnection2.Close();
			}
		} //end DelectDB()
	}
}
