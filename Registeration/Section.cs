///Name: Sotonte Bob-manuel
//Class: C# Programming CIST 2342_Lab05
//I wrote this code myself

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registeration
{
    public class Section
    {
        private int crn;
        private String courseID;
        private String timeDays;
        private String roomNo;
        private int instructorID;

        public Section() //Default Constructor
        {
            crn = 20180;
            courseID = "CIST 1001";
            timeDays = "Tuesdays|06:00pm - 07:55pm";
            roomNo = "MA-F 1149";
            instructorID = 14405;
        }

        public Section(int CRN, String CourseID, String TimeDays, String RoomNo, int InstructorID) // Constructor that passes variables
        {
            crn = CRN;
            courseID = CourseID;
            timeDays = TimeDays;
            roomNo = RoomNo;
            instructorID = InstructorID;
        }

        //Set anad get methods for the variables instantiated
        public int CRN
        {
            set { crn = value; }
            get { return crn; }
        }

        public String CourseID
        {
            set { courseID = value; }
            get { return courseID; }
        }

        public String TimeDays
        {
            set { timeDays = value; }
            get { return timeDays; }
        }

        public String RoomNo
        {
            set { roomNo = value; }
            get { return roomNo; }
        }

        public int InstructorID
        {
            set { instructorID = value; }
            get { return instructorID; }
        }

        public void Display() //Display method to display all the data received
        {
            Console.WriteLine("CRN: " + crn);
            Console.WriteLine("CourseID: " + courseID);
            Console.WriteLine("TimeDays: " + timeDays);
            Console.WriteLine("RoomNo: " + roomNo);
            Console.WriteLine("InstructorID: " + instructorID);
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


		public void SelectDB(int Crn)
		{ //++++++++++++++++++++++++++  SELECT +++++++++++++++++++++++++
			DBSetup();
			cmd = "Select * from Sections where CRN = " + Crn;
			OleDbDataAdapter2.SelectCommand.CommandText = cmd;
			OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
			Console.WriteLine(cmd);
			try
			{
				OleDbConnection2.Open();
				System.Data.OleDb.OleDbDataReader dr;
				dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();

				dr.Read();
				CRN = Int32.Parse(dr.GetValue(0) + "");
				CourseID = dr.GetValue(1) + "";
				TimeDays = dr.GetValue(2) + "";
				RoomNo = dr.GetValue(3) + "";
				InstructorID = Int32.Parse(dr.GetValue(4) + "");
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
			cmd = "INSERT into Sections values(" + CRN + ", '" +
									CourseID + "', '" + TimeDays + "', '" + 
									RoomNo + "', " + InstructorID + ")";

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

			cmd = "Update Sections set CourseID = '" + CourseID +
						 "', TimeDays = '" + TimeDays + "', RoomNo = '" + RoomNo +
						 "', Instructor = " + InstructorID + " where CRN = " + CRN;

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

			cmd = "Delete from Sections where CRN = " + CRN;
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
