using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace CSC340TeamProject
{
    public class Patient
    {
		string connectionCLass = "server=csdatabase.eku.edu;port=3306;database=csc340_db;username=stu_csc340;password=Colonels18;SslMode=none";

		public string ID;
        string name;
        string gender;
        string DOB;
        int age;
        string phone;
        string street1;
        string street2;
        string city;
        string state;
        string country;
        string acceptedDate;
        string sickness;
        int prescriptions;
        string allergies;
        string special_or_other;
        public static string userName;


        public Patient()
        {

        }

        public Patient(string nameOfPatientOrUserName)
        {
            string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

            Console.WriteLine("Connecting to MySQL...");

            string query = "SET FOREIGN_KEY_CHECKS=0;SELECT * FROM wzb_patient WHERE user_name = @userNameOrFullName or name=@userNameOrFullName;SET FOREIGN_KEY_CHECKS=1";
            MySqlCommand cmd = new MySqlCommand(query, myConn);
            MySqlDataReader myReader;
            cmd.Parameters.AddWithValue("@userNameOrFullName", nameOfPatientOrUserName);

            try
            {
                myConn.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read()) {
                    ID = myReader["ID"].ToString();
                    name = myReader["Name"].ToString();
                    gender = myReader["Gender"].ToString();
                    age = Int32.Parse(myReader["Age"].ToString());                    
                    phone = myReader["Phone"].ToString();
                    street1 = myReader["Street_1"].ToString();
                    street2 = myReader["Street_2"].ToString();
                    city = myReader["City"].ToString();
                    state = myReader["State"].ToString();
                    country = myReader["Country"].ToString();
                    //acceptedDate = DateTime.ParseExact(myReader["Accepted_Date"].ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    sickness = myReader["Sickness"].ToString();
                    prescriptions = Int32.Parse(myReader["Prescriptions"].ToString());
                    allergies = myReader["Allergies"].ToString();
                    special_or_other = myReader["Special_or_Other"].ToString();


                    Console.WriteLine("Table is ready.");
                    
             
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
        }

        //functions methods
        public void requestDoctorAppointment(List<string> appoint)
        {
            //create objects needed
            Notice notObj = new Notice();//to be used to send notice description


            string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

            Console.WriteLine("Connecting to MySQL...");
            
            string query = "SET FOREIGN_KEY_CHECKS=0;insert into wzb_appointment (date, time, description, doctor_ID, patient_ID) values (@date, @time, @desc, @docID, @patID);" +
                "SET FOREIGN_KEY_CHECKS=1";
            MySqlCommand cmd = new MySqlCommand(query, myConn);
            MySqlDataReader myReader;
            cmd.Parameters.AddWithValue("@patID", appoint[1]);
            cmd.Parameters.AddWithValue("@docID", appoint[0]);
            cmd.Parameters.AddWithValue("@desc", appoint[5]);
            cmd.Parameters.AddWithValue("@time", appoint[3]);
            cmd.Parameters.AddWithValue("@date", appoint[4]);
            
            //create a list for message components
            List<string> messageForNotice = new List<string>();
            messageForNotice.Add("AD");
            messageForNotice.Add(appoint[0]);
            messageForNotice.Add(appoint[1]);
            messageForNotice.Add(appoint[2] + " | "+appoint[3]+" | "+appoint[4]+" | "+appoint[5]);
            notObj.SendMessage(messageForNotice);
            

            try
            {
                myConn.Open();
                myReader = cmd.ExecuteReader();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

		public string getPatientName(string patID)
		{
			string patName = "";

			//connect string
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			//query
			string query = "SET FOREIGN_KEY_CHECKS=0; SELECT * FROM wzb_patient WHERE ID = @patID;SET FOREIGN_KEY_CHECKS=1";
			MySqlCommand cmd = new MySqlCommand(query, myConn);
			cmd.Parameters.AddWithValue("@patID", patID);

			MySqlDataReader myReader;

			try
			{
				myConn.Open();
				myReader = cmd.ExecuteReader();
				while (myReader.Read())
				{
					//store patient name
					patName = myReader["Name"].ToString();
					return patName;
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
			return patName;
		}

		public void requestDoctorCall(List<string> requestDoctorCallList)
		{
			Notice notObj = new Notice();
			notObj.SendMessage(requestDoctorCallList);


		}

		//method to search for patient using their name
		public List<Patient> getPatientSearch(string patName)
		{
			//variables
			List<Patient> patientList = new List<Patient>();
			string patientName;
			string patientID;
			string patientPrescrip;

			//connect string
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			//query
			string query = "SET FOREIGN_KEY_CHECKS=0; SELECT * FROM wzb_patient WHERE Name Like @patName;SET FOREIGN_KEY_CHECKS=1";
			MySqlCommand cmd = new MySqlCommand(query, myConn);
			cmd.Parameters.AddWithValue("@patName", "%"+patName+"%");

			MySqlDataReader myReader;

			try
			{
				myConn.Open();
				myReader = cmd.ExecuteReader();
				while (myReader.Read())
				{
					//store patient name
					patientName = myReader["Name"].ToString();
					patientID = myReader["ID"].ToString();
					patientPrescrip = myReader["Prescriptions"].ToString();

					//fill our list with new objects
					patientList.Add(new Patient() {
						name = patientName,
						ID = patientID,
						prescriptions =  Int32.Parse(patientPrescrip)});
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

			//return the list of patient objects that met the criteria
			return patientList;
		}

		//create an object used with records
		public Patient getPatientObject(string patID)
		{
			//patient object to be used
			Patient patObj = new Patient();

			//connection
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			//query
			string query = "SELECT * FROM wzb_patient WHERE ID = @patID";
			MySqlCommand cmd = new MySqlCommand(query, myConn);
			MySqlDataReader myReader;

			//bind parameters
			cmd.Parameters.AddWithValue("@patID", patID);

			try
			{
				myConn.Open();
				myReader = cmd.ExecuteReader();
				while (myReader.Read())
				{
					//get values from database
					name = myReader["Name"].ToString();
					gender = myReader["Gender"].ToString();
					DOB = myReader["DOB"].ToString();
					age = Int32.Parse(myReader["Age"].ToString());
					phone = myReader["Phone"].ToString();
					street1 = myReader["Street_1"].ToString();
					street2 = myReader["Street_2"].ToString();
					city = myReader["City"].ToString();
					state = myReader["State"].ToString();
					country = myReader["Country"].ToString();
					acceptedDate = myReader["Accepted_Date"].ToString();
					sickness = myReader["Sickness"].ToString();
					prescriptions = Int32.Parse(myReader["Prescriptions"].ToString());
					allergies = myReader["Allergies"].ToString();
					special_or_other = myReader["Special_or_Other"].ToString();

					//convert our dates to desired format
					DateTime dateConvert1 = DateTime.Parse(DOB);
					DateTime dateConvert2 = DateTime.Parse(acceptedDate);

					string formatDOB = dateConvert1.ToString("yyyy-MM-dd");
					string formatAccepted = dateConvert2.ToString("yyyy-MM-dd");

					//store values inside the object to be passed
					patObj.setName(name);
					patObj.setGender(gender);
					patObj.setDOB(formatDOB);
					patObj.setAge(age);
					patObj.setPhone(phone);
					patObj.setStreet1(street1);
					patObj.setStreet2(street2);
					patObj.setCity(city);
					patObj.setState(state);
					patObj.setCountry(country);
					patObj.setAccepted(formatAccepted);
					patObj.setSickness(sickness);
					patObj.setPrescriptions(prescriptions);
					patObj.setAllergies(allergies);
					patObj.setSpecial(special_or_other);

					//return the object
					return patObj;
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

			//if query fails, bull object is returned
			return patObj;
		}

		public string[] getPatientRecords(string userName)
		{
			//create array of records 
			string[] queryPatientRecords = new string[9];

			//connect string
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			//query
			string query = "SELECT * FROM wzb_patient WHERE User_name = @user";
			MySqlCommand cmd = new MySqlCommand(query, myConn);
			cmd.Parameters.AddWithValue("@user", userName);

			MySqlDataReader myReader;

			try
			{
				myConn.Open();
				myReader = cmd.ExecuteReader();
				while (myReader.Read())
				{
					//create address
					string address = myReader["Street_1"].ToString() + ", " + myReader["City"].ToString() + ", " + myReader["State"].ToString() + ", " + myReader["Country"].ToString();
					//store records
					queryPatientRecords[0] = myReader["Name"].ToString();
					queryPatientRecords[1] = myReader["Gender"].ToString();
					queryPatientRecords[2] = myReader["Age"].ToString();
					queryPatientRecords[3] = myReader["Phone"].ToString();
					queryPatientRecords[4] = address;
					queryPatientRecords[5] = myReader["Sickness"].ToString();
					queryPatientRecords[6] = myReader["Allergies"].ToString();
					queryPatientRecords[7] = myReader["Special_or_Other"].ToString();
					queryPatientRecords[8] = "N/A";
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

			return queryPatientRecords;

		}

		public string getID()
        {
            return ID;
        }
        public string getName()
        {
            return name;
        }
        public string getGender()
        {
            return gender;
        }
        public string getDOB()
        {
            return DOB;
        }
        public int getAge()
        {
            return age;
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
        public string getAcceptedDate()
        {
            return acceptedDate;
        }
        public string getSickness()
        {
            return sickness;
        }
        public int getPrescriptions()
        {
            return prescriptions;
        }
        public string getAllergies()
        {
            return allergies;
        }
        public string getSpecialOROther()
        {
            return special_or_other;
        }

		//set methods
		public void setName(string name)
		{
			this.name = name;
		}

		public void setGender(string gender)
		{
			this.gender = gender;
		}

		public void setDOB(string DOB)
		{
			this.DOB = DOB;
		}

		public void setAge(int age)
		{
			this.age = age;
		}

		public void setPhone(string phone)
		{
			this.phone = phone;
		}

		public void setStreet1(string street1)
		{
			this.street1 = street1;
		}

		public void setStreet2(string street2)
		{
			this.street2 = street2;
		}

		public void setCity(string city)
		{
			this.city = city;
		}

		public void setState(string state)
		{
			this.state = state;
		}

		public void setCountry(string country)
		{
			this.country = country;
		}

		public void setAccepted(string accepted)
		{
			this.acceptedDate = accepted;
		}

		public void setSickness(string sickness)
		{
			this.sickness = sickness;
		}

		public void setPrescriptions(int prescrip)
		{
			this.prescriptions = prescrip;
		}

		public void setAllergies(string allergies)
		{
			this.allergies = allergies;
		}

		public void setSpecial(string special)
		{
			this.special_or_other = special;
		}

        public void setUserName(string username)
        {
            userName = username;
        }

		//toString method used for the grant/reject permit function
		//can use this for others as well
		public string patientGrantorRejectToString()
		{
			return "ID: "+ID+" | Name: "+name+" | Prescriptions: "+prescriptions;
		}

    }
}
