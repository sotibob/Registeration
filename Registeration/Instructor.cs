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
    public class Instructor : Person //Instructor inherits from the Person class
    {
        private int id;
        private String office;

        public Instructor() : base() //Default Constructor + Inherited Constructor
        {
            id = 34567;
            office = "M1490";
        }

        public Instructor(int ID, String FirstName, String LastName, String Email, Address Address, String Office) : base(FirstName, LastName, Email, Address) // Constructor that passes variables + Inherited Constructor
        {
            id = ID;
            office = Office;
        }

        //Set and get methods for the variables instantiated
        public int ID
        {
            set { id = value; }
            get { return id; }
        }

        public String Office
        {
            set { office = value; }
            get { return office; }
        }
        
        public void Display() // Display method to display all the data received
        {
            Console.WriteLine("Instructor ID: " + id);
            Console.WriteLine("Office: " + office);
            base.Display();
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


		public void SelectDB(int id)
		{ //++++++++++++++++++++++++++  SELECT +++++++++++++++++++++++++
			DBSetup();
			cmd = "Select * from Instructors where ID = " + id;
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
				Office = dr.GetValue(7) + "";
				Email = dr.GetValue(8) + "";

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
			cmd = "INSERT into Instructors values(" + ID + ", '" + FirstName + "', '" +
								LastName + "', '" + Address.Street + "', '" + Address.City + "', '" + 
								Address.State + "', " + Address.ZIP + ", '" + Office + "', '" + Email + "')";

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

			cmd = "Update Instructors set FirstName = '" + FirstName +
						 "', LastName = '" + LastName + "', Street = '" + Address.Street +
						 "', City = '" + Address.City + "', State = '" + Address.State +
						 "', Zip = " + Address.ZIP + ", Office = '" + Office +
						 "', EMail = '" + Email + "' where ID = " + ID;

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

			cmd = "Delete from Instructors where ID = " + ID;
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
