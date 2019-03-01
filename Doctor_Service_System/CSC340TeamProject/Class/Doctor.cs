using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC340TeamProject
{
    class DoctorClass
    {
		string connectionCLass = "server=csdatabase.eku.edu;port=3306;database=csc340_db;username=stu_csc340;password=Colonels18;SslMode=none";

		//our attributes of the Doctor class
		//renamed to DoctorClass as Doctor was reserved in a previous version
		string ID;
        string name;
        string phone;
        string street1;
        string street2;
        string city;
        string state;
        string country;
        string speciality;
        string hospital;
		static string userName; //used across other classes for validation purposes
        string email;


        public DoctorClass()
        {

        }

        //takes name of doctor and user and sets out variables uptop
        public DoctorClass(string nameOfDoctorOrUserName)
        {
			//build a connection
            string myConnection = connectionCLass;
            MySqlConnection myConn = new MySqlConnection(myConnection);

            //Console.WriteLine("Connecting to MySQL...");

			//build our query as well as bind the passed data of the constructor
            string query = "SET FOREIGN_KEY_CHECKS=0; SELECT * FROM wzb_doctor WHERE Name = @nameofDoctorORuserName or " +
				"user_name = @nameofDoctorORuserName or ID = @nameofDoctorORuserName;SET FOREIGN_KEY_CHECKS=1";
            MySqlCommand cmd = new MySqlCommand(query, myConn);
            MySqlDataReader myReader;
            cmd.Parameters.AddWithValue("@nameofDoctorORuserName", nameOfDoctorOrUserName);

			//try our to query the database
            try
            {
                myConn.Open();
                myReader = cmd.ExecuteReader();
				
				//check our data using the reader
                while (myReader.Read())
                {

                    //Console.WriteLine("info"+appoint[0]);
                    //Console.WriteLine("info2"+appoint[1]);
                    //Console.WriteLine("show me "+ myReader["ID"].ToString());

					//store our data from the database query
                    ID = myReader["ID"].ToString();
                    name = myReader["Name"].ToString();
                    phone = myReader["Phone"].ToString();
                    email = myReader["Email"].ToString();
                    street1 = myReader["Street_1"].ToString();
                    street2 = myReader["Street_2"].ToString();
                    city = myReader["City"].ToString();
                    state = myReader["State"].ToString();
                    country = myReader["Country"].ToString();
                    //acceptedDate = DateTime.ParseExact(myReader["Accepted_Date"].ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    speciality = myReader["Prescriptions"].ToString();
                    hospital = myReader["Allergies"].ToString();
                    userName = myReader["Special_or_Other"].ToString();


                    //Console.WriteLine("Table is ready.");


                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
				//close connection
                myConn.Close();
            }
        }
    
		//method to allow us to view the medical records
		//will first convert the static saved username to a doctor id
		//which will later be used in checking if the logged in doctor has permission to view the records
        public string[] viewMedicalRecord(string patID)
        {
			//used to check if the query was made, meaning correct/incorrect information was passed
			int checkedQuery = 0;

			//build connection
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);
			
			//get the doctor id using userName
			string testID = calculateID(userName);

			//build our query
			string query1 = "SET FOREIGN_KEY_CHECKS=0;SELECT * FROM wzb_patient WHERE ID = @patID;SET FOREIGN_KEY_CHECKS=1";
			MySqlCommand cmd1 = new MySqlCommand(query1, myConn);
			cmd1.Parameters.AddWithValue("@patID", patID);
			
			MySqlDataReader myReader;

			//initialize the array to store our data and return
			string[] medicalRecords = new string[4];

			try
			{
				//build reader after connection is opened
				myConn.Open();
				myReader = cmd1.ExecuteReader();

				//query
				while (myReader.Read())
				{
					//if this point is reached, the query found at least a single match
					checkedQuery = 1;

					//store data in temp variables
					string ID = myReader["ID"].ToString();
					string Name = myReader["Name"].ToString();
					string sickness = myReader["Sickness"].ToString();
					string allergies = myReader["Allergies"].ToString();
					string special = myReader["Special_or_Other"].ToString();

					//check if the doctor has permission to view medical records
					int check = checkFamily(testID, ID);

					//if check is 0, doctor does not have permission
					if(check == 0)
					{
						medicalRecords[0] = "Invalid";
						return medicalRecords;
					}
					//otherwise, check == 1, which means doctor has permission
					else
					{
						medicalRecords[0] = Name;
						medicalRecords[1] = sickness;
						medicalRecords[2] = allergies;
						medicalRecords[3] = special;
						return medicalRecords;
					}
				}

				//if the while loop never ran once, that means there were no matches
				//this means checked never changed its initial value
				//incorrect query
				if(checkedQuery == 0)
				{
					medicalRecords[0] = "Incorrect";
					return medicalRecords;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				//close connection
				myConn.Close();
			}

			return medicalRecords;
		}
		
		//method to check if doctor has permission to view patient records
		public int checkFamily(string docID, string patientID)
		{
			//connection string
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			//wuery
			string query = "SET FOREIGN_KEY_CHECKS=0;SELECT * FROM wzb_doctor_patient WHERE Patient_ID = @patientID AND Doctor_ID = @docID;SET FOREIGN_KEY_CHECKS=1";
			MySqlCommand cmd = new MySqlCommand(query, myConn);
			cmd.Parameters.AddWithValue("@patientID", patientID);
			cmd.Parameters.AddWithValue("@docID", docID);

			MySqlDataReader myReader;

			try
			{
				//open and build reader
				myConn.Open();
				myReader = cmd.ExecuteReader();


				while (myReader.Read())
				{
					//variable to store and check our boolean/tinyint value in our database
					string isFam = myReader["Family_doctor"].ToString();

					//if it is true, return 1 which will continue execution
					//if 0 or False, doctor does not have permission
					if(isFam == "True")
					{
						return 1;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				//close connection
				myConn.Close();
			}

			return 0;
		}

		//method to calculate doctor id based on username
		public string calculateID(string username)
		{
			//empty string in case query doesn't run
			string docID = "";

			//connect string
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			//query
			string query = "SET FOREIGN_KEY_CHECKS=0;SELECT * FROM wzb_doctor WHERE User_name = @userName;SET FOREIGN_KEY_CHECKS=1";
			MySqlCommand cmd = new MySqlCommand(query, myConn);
			cmd.Parameters.AddWithValue("@userName", username);

			MySqlDataReader myReader;

			try
			{
				myConn.Open();
				myReader = cmd.ExecuteReader();
				while (myReader.Read())
				{
					//store doctor id based on where username matches a cooresponding database value
					docID = myReader["ID"].ToString();
					return docID;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				myConn.Close();
			}

			//this will return blank
			//this is dependent on the entering of database values
			//as logins are assigned through database INSERT queries
			return docID;
		}

		//retrieve a list of doctors
		//this is used for drop down menus and such
        public List<string> getDoctor()
        {
			//list contructor
            var list = new List<string>();

			//check using connection
            using (var myConn = new MySqlConnection())
            {
                myConn.ConnectionString = connectionCLass;
				myConn.Open();

				//looped query to retrieve all doctor names
                using (var cmd = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0;Select Name from wzb_Doctor Order by Name Asc;SET FOREIGN_KEY_CHECKS=1", myConn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
							//add our doctor's name to the list
                            list.Add(Convert.ToString(reader["Name"]));
                        }
                    }
                    myConn.Close();
                }
            }

            return list;
        }


        //get methods
        public string getID()
        {
            return ID;
        }
        public string getName()
        {
            return name;
        }
        public string getPhone()
        {
            return phone;
        }
        public string getStreet1()
        {
            return street1;
        }
        public string getStreet2()
        {
            return street2;
        }
        public string getCity()
        {
            return city;
        }
        public string getState()
        {
            return state;
        }
        public string getCountry()
        {
            return country;
        }
        public string getSpeciality()
        {
            return speciality;
        }
        public string getHospital()
        {
            return hospital;
        }
		public string getUserName()
		{
			return userName;
		}

		//set methods
		public void setUserName(string username)
		{
			userName = username;
		}
    }
}
