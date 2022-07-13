//Name: Sotonte Bob-manuel
//Class: C# Programming CIST 2342_Lab06
//I wrote this code myself

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registeration
{
    public class Student : Person //Student inherits from the Person class
    {
        private int id;
        private double gpa;
		public Schedule schedule = new Schedule();

        public Student() : base() //Default Constructor + Inherited Constructor
        {
            id = 45678;
            gpa = 3.5;
        }

        public Student(int ID, String FirstName, String LastName, String Email, Address Address, double GPA) : base(FirstName, LastName, Email, Address) // Constructor that passes variables + Inherited Constructor
        {
            id = ID;
            gpa = GPA;
        }

        //Set and get methods for the variables instantiated
        public int ID
        {
            set { id = value; }
            get { return id; }
        }

        public double GPA
        {
            set { gpa = value; }
            get { return gpa; }
        }

		public void getSchedule()
        {
			cmd = "Select CRN from StudentSchedule where StudentID = " + id;
			OleDbDataAdapter2.SelectCommand.CommandText = cmd;
			OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
			Console.WriteLine(cmd);
			try
			{
				OleDbConnection2.Open();
				System.Data.OleDb.OleDbDataReader dr;
				dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();
				int crn;
				Section s1;

				while (dr.Read())
                {
					s1 = new Section();
					crn = Int32.Parse(dr.GetValue(0) + "");
					s1.SelectDB(crn);
					schedule.addSection(s1);
                }
				
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			finally
			{
				OleDbConnection2.Close();
			}
		}

        public void Display() // Display method to display all the data received
        {
            Console.WriteLine("Student ID: " + id);
            Console.WriteLine("GPA: " + gpa);
            base.Display();
			schedule.Display();
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


		public void SelectDB(int Id)
		{ //++++++++++++++++++++++++++  SELECT +++++++++++++++++++++++++
			DBSetup();
			cmd = "Select * from Students where ID = " + Id;
			OleDbDataAdapter2.SelectCommand.CommandText = cmd;
			OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
			Console.WriteLine(cmd);
			try
			{
				OleDbConnection2.Open();
				System.Data.OleDb.OleDbDataReader dr;
				dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();

				dr.Read();
				ID = Int32.Parse(dr.GetValue(0) + "");
				FirstName = dr.GetValue(1) + "";
				LastName = dr.GetValue(2) + "";
				String Street = dr.GetValue(3) + "";
				String City = dr.GetValue(4) + "";
				String State = dr.GetValue(5) + "";
				int ZIP = Int32.Parse(dr.GetValue(6) + "");
				Address = new Address(Street, City, State, ZIP);
				Email = dr.GetValue(7) + "";
				GPA = Double.Parse(dr.GetValue(8) + "");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			finally
			{
				OleDbConnection2.Close();
			}
			getSchedule();
		} //end SelectDB()



		public void InsertDB()
		{
			// +++++++++++++++++++++++++++  INSERT +++++++++++++++++++++++++++++++

			DBSetup();
			cmd = "INSERT into Students values(" + ID + ", '" + FirstName + "', '" +
								LastName + "', '" + Address.Street + "', '" + Address.City + "', '" + 
								Address.State + "', " + Address.ZIP + ", '" + Email + "', " + GPA + ")";

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

			cmd = "Update Students set FirstName = '" + FirstName +
						 "', LastName = '" + LastName + "', Street = '" + Address.Street +
						 "', City = '" + Address.City + "', State = '" + Address.State +
						 "', Zip = " + Address.ZIP + ", EMail = '" + Email +
						 "', GPA = " + GPA + " where ID = " + ID ;

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

			cmd = "Delete from Students where ID = " + ID;
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
