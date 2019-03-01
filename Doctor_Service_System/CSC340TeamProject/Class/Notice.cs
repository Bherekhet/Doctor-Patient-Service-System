using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CSC340TeamProject
{
    public class Notice
    {
		public string connectionCLass = "server=csdatabase.eku.edu;port=3306;database=csc340_db;username=stu_csc340;password=Colonels18;SslMode=none";

		public string ID;
        string type;
        string to;
        string from;
        string message;


        string userName;
        string password;
		string name;

        Patient_View DP = new Patient_View();



        //function methods 
        public Notice()
        {

        }

		//sends notice message to database (a notice is generated for any kind of notices such as appointment, phone call request) from here. When each request is sent here from
		//respective class they will have a marker such as 'P' , 'A' and that would register in the database identifying the type of notice
		public void SendMessage(List<string> message)
		{

			string identifier = ""; ;
			List<string> messageSend = message;
			if (messageSend[0] == "AD" || messageSend[0] == "AP")//if appointment
			{
				identifier = "1";
			}
			else if (messageSend[0] == "PD")
			{
				identifier = "-1";
			}
			else if (messageSend[0] == "RD")
			{
				identifier = "-1";
			}

			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			Console.WriteLine("Connecting to MySQL...");


			//create our query and bind paramaters to a position in the list
			string query = "SET FOREIGN_KEY_CHECKS=0; insert into wzb_notice (Type_is, Response, Send_to, Received_from, message) " +
				"values (@type, @response, @sendTo, @receivedFrom, @from );SET FOREIGN_KEY_CHECKS=1";
			MySqlCommand cmd = new MySqlCommand(query, myConn);
			MySqlDataReader myReader;
			cmd.Parameters.AddWithValue("@type", messageSend[0]);
			cmd.Parameters.AddWithValue("@response", identifier);
			cmd.Parameters.AddWithValue("@sendTo", messageSend[1]);
			cmd.Parameters.AddWithValue("@receivedFrom", messageSend[2]);
			cmd.Parameters.AddWithValue("@from", messageSend[3]);

			try
			{
				myConn.Open();
				myReader = cmd.ExecuteReader();

				//Console.WriteLine("Table is ready.");
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

		//new method I added
		//who's I? - Will
		public static ArrayList validateUserInfo(string userName, string password)
        {
            ArrayList userLoginList = new ArrayList();
            DataTable myTable = new DataTable();

            string myConnection = "server=csdatabase.eku.edu;port=3306;database=csc340_db;username=stu_csc340;password=Colonels18;SslMode=none";
			MySqlConnection myConn = new MySqlConnection(myConnection);
            

            try
            {
                //Console.WriteLine("Connecting to MySQL...");
				//creat query and bind parameters
                myConn.Open();
                MySqlCommand cmd = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0;select User_name, Password, Name from wzb_logininfo where User_name=@user and Password=@pass;SET FOREIGN_KEY_CHECKS=1", myConn);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@user", userName);
                cmd.Parameters.AddWithValue("@pass", password);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            finally
            {
                myConn.Close();
            }

			//create notice objects
			//store database values
            foreach (DataRow row in myTable.Rows)
            {
                Notice infoNotice = new Notice();
                
                infoNotice.userName = row["User_name"].ToString();
                
                infoNotice.password = row["Password"].ToString();

				infoNotice.name = row["Name"].ToString();

                userLoginList.Add(infoNotice);
            }
            return userLoginList;
            
        }

		public ArrayList getPatientNotices()
		{
			//objects and variables used
			//id is used in query


			Patient patObj = new Patient(storeKeys.loginUserName);
			string patID = patObj.getID();//patient ID
			string patName = patObj.getName();//patient Name
            string status ="";


            //connection
            string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			//query
			//in the case of a patient's notices
			string query = "SELECT * FROM wzb_notice WHERE (Received_from = @patID) AND (Type_is = 'RD' or Type_is = 'RP' OR Type_is = 'AD' OR Type_is = 'AP' OR Type_is = 'PD' OR Type_is = 'EP')" +
                "OR Type_is = 'NP' OR Type_is = 'WP'";
			MySqlCommand cmd = new MySqlCommand(query, myConn);
			cmd.Parameters.AddWithValue("@patID", patID);
			MySqlDataReader myReader;

			//list to store notices
			ArrayList noticeList = new ArrayList();

			try
			{
				myConn.Open();
				myReader = cmd.ExecuteReader();
				while (myReader.Read())
				{
					//store values
					ID = myReader["ID"].ToString();
					type = myReader["Type_is"].ToString();
					string respond = myReader["Response"].ToString();
					message = myReader["Message"].ToString();

					//doctor Name
					DoctorClass docObj = new DoctorClass(myReader["Received_from"].ToString());
					string docName = docObj.getName();

					Notice notObj = new Notice();
                    if(respond != "")
                    {
                        status = notObj.checkResponse(type, respond, message);
                        noticeList.Add(status);
                    }
					    

                    //check type and convert to string
                    //----------
                    // Group
                    //----------

                    // Doctor
                    //----------
                    // Set Appt ------------------------ A ---appointment made
                    // Grant/Reject Refills ------------ R ---Refill granted/rejected/in process
                    // Doctor request for medical records M --medical record request

                    // Patient
                    //----------
                    // Request Phone Call -------------- P ---Phone call request accepted

                    //----------
                    // Individual
                    //----------
                    // Pharmacy Recevies Refill Req ---- E ---Refill pharmacy request received
                    // Pharmacy Receives New Presc ----- N ---Prescription pharmacy request received
                    // When Medicine is Ready ---------- W ---Medicine is ready
                    // Doctor DIscuss with Pharmacy ---- D




                    //build a string to add to to listview

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

			return noticeList;
		}

		public string checkResponse(string type, string repond, string messag)
		{
            string valueReturned = "";

            if (type == "RD" && repond == "-1")
            {
                valueReturned = "Refill Request in process!   (" + messag + " )";
            }
            else if ((type == "RD" || type == "RP") && repond == "0")
            {
                valueReturned = "Refill Request rejected!   (" + messag + " )";
            }
            else if ((type == "RD" || type == "RP") && repond == "1")
            {
                valueReturned = "Refill Request Accepted!   (" + messag + " )";
            }
            else if (type == "PD" && repond == "-1")
            {
                valueReturned = "Phone Call Request in process!    (" + messag + " )";
            }
            else if (type == "PD" && repond == "0")
            {
                valueReturned = "Phone Call Request rejected!   (" + messag + " )";
            }
            else if (type == "PD" && repond == "1")
            {
                valueReturned = "Phone Call Request accepted!   (" + messag + " )";
            }
            else if ((type == "AP" || type == "AD") && repond == "1")
            {
                valueReturned = "Appointment Made!   (" + messag + " )";
            }
            else if (type == "E" && repond == "1")
            {
                valueReturned = "Refill Pharmacy request received!   (" + messag + " )";
            }
            else if (type == "N" && repond == "1")
            {
                valueReturned = "Prescription pharmacy request received!   (" + messag + " )";
            }
            else if (type == "WP" && repond == "1")
            {
                valueReturned = "Medicine is ready" + messag;
            }
            else if (type == "MP" && repond == "-1")
            {
                valueReturned = "Medical record request from your doctor!   (" + messag + " )";
            }
            return valueReturned;
    }

		//method used to getNotices to display all notices to a doctor
		public List<string> getNotices()
		{
			//objects and variables used
			//username is only used to get id
			//id is used in query
			DoctorClass docObj = new DoctorClass();
			Patient patObj = new Patient();
			string docUser = docObj.getUserName();
			string docID = docObj.calculateID(docUser);


			//connection
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			//query
			//in the case of a doctor's notices
			string query = "SET FOREIGN_KEY_CHECKS=0; SELECT * FROM wzb_notice WHERE Send_to = @docID " +
				"AND (Type_is = 'RD' OR Type_is = 'AD' OR Type_is = 'PD' OR Type_is = 'DD');SET FOREIGN_KEY_CHECKS=1";
			MySqlCommand cmd = new MySqlCommand(query, myConn);
			cmd.Parameters.AddWithValue("@docID", docID);
			MySqlDataReader myReader;

			//list to store notices
			List<string> noticeList = new List<string>();

			try
			{
				myConn.Open();
				myReader = cmd.ExecuteReader();
				while (myReader.Read())
				{
					//store values
					ID = myReader["ID"].ToString();
					type = myReader["Type_is"].ToString();

					//check type and convert to string
					//----------
					// Group
					//----------

					// Doctor
					//----------
					// Set Appt ------------------------ A
					// Grant/Reject Refills ------------ R

					// Patient
					//----------
					// Request Phone Call -------------- P
					// Doctor Asks for Medical Permis -- M

					//----------
					// Individual
					//----------
					// Pharmacy Recevies Refill Req ---- E
					// Pharmacy Receives New Presc ----- N
					// When Medicine is Ready ---------- W
					// Doctor DIscuss with Pharmacy ---- D
					if (type == "R")
					{
						type = "Refill Request";
					}
					else if(type == "P")
					{
						type = "Phone Call Request";
					}
					else
					{
						type = "Appointment Request";
					}

					to = myReader["Send_to"].ToString();
					from = myReader["Received_from"].ToString();

					from = patObj.getPatientName(from);

					message = myReader["Message"].ToString();

					//build a string to add to to listview
					noticeList.Add("Notice ID: " + ID + "  |  " + type + "  |  From: " + from + "  |  Message: " + message);
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

			//return the list of string objects
			return noticeList;
		}

		//method to create a granted refill permit notice
		public int createGrantNotice(string patientID, string docID, string additionalComm, string response)
		{
			//connection
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			myConn.Open();

			MySqlCommand comm = myConn.CreateCommand();

			//command
			comm.CommandText = "SET FOREIGN_KEY_CHECKS=0;INSERT INTO wzb_notice (Type_is, Response, Send_to, Received_from, Message) " +
				"VALUES ('RP',@res, @sendTo, @receivedFrom, @additional);SET FOREIGN_KEY_CHECKS=1";
            comm.Parameters.AddWithValue("@res", response);
            comm.Parameters.AddWithValue("@sendTo", docID);
			comm.Parameters.AddWithValue("@receivedFrom", patientID);
			comm.Parameters.AddWithValue("@additional", "GRANTED! "+additionalComm);

			try
			{
				//execute the command
				//return 1 if this part is reached, meaning success
				comm.ExecuteNonQuery();
				return 1;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				myConn.Close();
			}

			//if this is reached, return 0, meaning it failed
			return 0;
		}

		//method to create a granted refill permit notice
		public int createMedicalRequestNotice(string patientID, string docID, string additionalComm)
		{
			//connection
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			myConn.Open();

			MySqlCommand comm = myConn.CreateCommand();

			//command
			comm.CommandText = "SET FOREIGN_KEY_CHECKS=0;INSERT INTO wzb_notice (Type_is, Response, Send_to, Received_from, Message) " +
                "VALUES ('MP', '-1', @sendTo, @receivedFrom, @additional);SET FOREIGN_KEY_CHECKS=1";
			comm.Parameters.AddWithValue("@sendTo", docID);
			comm.Parameters.AddWithValue("@receivedFrom", patientID);
			comm.Parameters.AddWithValue("@additional", "Requesting Access to medical Records! " + additionalComm);

			try
			{
				//execute the command
				//return 1 if this part is reached, meaning success
				comm.ExecuteNonQuery();
				return 1;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				myConn.Close();
			}

			//if this is reached, return 0, meaning it failed
			return 0;
		}

		//method to create a reject notice
		public int createRejectNotice(string patientID, string docID, string additionalComm, string response)
		{
			//connection
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			myConn.Open();

			MySqlCommand comm = myConn.CreateCommand();

			//command
			comm.CommandText = "SET FOREIGN_KEY_CHECKS=0;INSERT INTO wzb_notice (Type_is, Response, Send_to, Received_from, Message) " +
				"VALUES ('RP', @res, @patientID, @docID, @additional);SET FOREIGN_KEY_CHECKS=1";
            comm.Parameters.AddWithValue("@res", response);
            comm.Parameters.AddWithValue("@docID", docID);
			comm.Parameters.AddWithValue("@patientID", patientID);
			comm.Parameters.AddWithValue("@additional", "REJECTED! " + additionalComm);

			try
			{
				//execute the query
				//return 1 if this portion is reached
				comm.ExecuteNonQuery();
				return 1;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				myConn.Close();
			}

			//return 0 if failed
			return 0;
		}

		public ArrayList getDoctorMedicalPermitRequest()
		{
			Patient patObj = new Patient(storeKeys.loginUserName);


			//connection
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			//query
			string query = "SELECT * FROM wzb_notice WHERE Send_to = @patID AND (Type_is = 'MP' ) And (Response = '-1' )";


			//list to store medicalRequest
			ArrayList medicalRequestList = new ArrayList();

			try
			{
				MySqlCommand cmd = new MySqlCommand(query, myConn);
				cmd.Parameters.AddWithValue("@patID", patObj.getID());
                Console.WriteLine(patObj.getID());
				MySqlDataReader myReader;
				myConn.Open();
				myReader = cmd.ExecuteReader();
				while (myReader.Read())
				{
					string docID = myReader["Received_from"].ToString();
					string message = myReader["Message"].ToString();

					DoctorClass docObj = new DoctorClass(docID);
					string doctorName = docObj.getName();

					//build a string to add to to listview
					medicalRequestList.Add(doctorName);
					medicalRequestList.Add(message);
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

			return medicalRequestList;
		}

		//create a new medical record
		public int createMedicalRecord(string name, string gender, string DOB, string age, string phone, string address1, string address2,
			string city, string state, string country, string accepted, string sickness, string prescriptions, string allergies, string other, string user)
		{
			//connection
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			myConn.Open();

			MySqlCommand comm = myConn.CreateCommand();

			//command
			comm.CommandText = "SET FOREIGN_KEY_CHECKS=0;INSERT INTO wzb_patient (Name, Gender, DOB, Age, Phone, Street_1, Street_2, City, State, Country, Accepted_Date, Sickness, Prescriptions, Allergies, Special_or_Other, User_name) " +
											"VALUES (@name, @gender, @DOB, @age, @phone, @address1, @address2, @city, @state, @country, " +
											"@accepted, @sickness, @prescriptions, @allergies, @other, @user);SET FOREIGN_KEY_CHECKS=1";
			comm.Parameters.AddWithValue("@name", name);
			comm.Parameters.AddWithValue("@gender", gender);
			comm.Parameters.AddWithValue("@DOB", DOB);
			comm.Parameters.AddWithValue("@age", age);
			comm.Parameters.AddWithValue("@phone", phone);
			comm.Parameters.AddWithValue("@address1", address1);
			comm.Parameters.AddWithValue("@address2", address2);
			comm.Parameters.AddWithValue("@city", city);
			comm.Parameters.AddWithValue("@state", state);
			comm.Parameters.AddWithValue("@country", country);
			comm.Parameters.AddWithValue("@accepted", accepted);
			comm.Parameters.AddWithValue("@sickness", sickness);
			comm.Parameters.AddWithValue("@prescriptions", prescriptions);
			comm.Parameters.AddWithValue("@allergies", allergies);
			comm.Parameters.AddWithValue("@other", other);
			comm.Parameters.AddWithValue("@user", user);

			try
			{
				//execute the query
				//return 1 if this portion is reached
				comm.ExecuteNonQuery();
				return 1;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				myConn.Close();
			}

			return 0;
		}
		
		//update an existing medical record
		public int updateMedicalRecord(string name, string gender, string DOB, string age, string phone, string address1, string address2,
									   string city, string state, string country, string accepted, string sickness, string prescriptions, string allergies, string other, string user, Patient patObj)
		{
			//connection
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			myConn.Open();

			MySqlCommand comm = myConn.CreateCommand();

			//command
			//LEFT THIS AS AN INSERT
			//Chang said to insert new row values in order to make it easier to check that changes are being made
			comm.CommandText = "SET FOREIGN_KEY_CHECKS=0;INSERT INTO wzb_patient (Name, Gender, DOB, Age, Phone, Street_1, Street_2, City, State, Country, Accepted_Date, Sickness, Prescriptions, Allergies, Special_or_Other, User_name) " +
											"VALUES (@name, @gender, @DOB, @age, @phone, @address1, @address2, @city, @state, @country, " +
											"@accepted, @sickness, @prescriptions, @allergies, @other, @user);SET FOREIGN_KEY_CHECKS=1";

			//if values are empty, retain old values and only change those with input text values
			name = patObj.getName();
			gender = patObj.getGender();
			age = patObj.getAge().ToString();
			DOB = patObj.getDOB();
			accepted = patObj.getAcceptedDate();

			//MessageBox.Show("DOB: "+DOB+" | Accepted: "+accepted);

			if(phone == "")
			{
				phone = patObj.getPhone();
			}
			if(address1 == "")
			{
				address1 = patObj.getStreet1();
			}
			if(address2 == "")
			{
				address2 = patObj.getStreet2();
			}
			if(city == "")
			{
				city = patObj.getCity();
			}
			if(state == "")
			{
				state = patObj.getState();
			}
			if(sickness == "")
			{
				sickness = patObj.getSickness();
			}
			if(prescriptions == "")
			{
				prescriptions = patObj.getPrescriptions().ToString();
			}
			if(allergies == "")
			{
				allergies = patObj.getAllergies();
			}
			if(other == "")
			{
				other = patObj.getSpecialOROther();
			}

			//bind our values
			comm.Parameters.AddWithValue("@name", name);
			comm.Parameters.AddWithValue("@gender", gender);
			comm.Parameters.AddWithValue("@DOB", DOB);
			comm.Parameters.AddWithValue("@age", age);
			comm.Parameters.AddWithValue("@phone", phone);
			comm.Parameters.AddWithValue("@address1", address1);
			comm.Parameters.AddWithValue("@address2", address2);
			comm.Parameters.AddWithValue("@city", city);
			comm.Parameters.AddWithValue("@state", state);
			comm.Parameters.AddWithValue("@country", country);
			comm.Parameters.AddWithValue("@accepted", accepted);
			comm.Parameters.AddWithValue("@sickness", sickness);
			comm.Parameters.AddWithValue("@prescriptions", prescriptions);
			comm.Parameters.AddWithValue("@allergies", allergies);
			comm.Parameters.AddWithValue("@other", other);
			comm.Parameters.AddWithValue("@user", user);

			try
			{
				//execute the query
				//return 1 if this portion is reached
				comm.ExecuteNonQuery();
				return 1;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				myConn.Close();
			}

			return 0;
		}

		//add to an existing medical record
		public int addMedicalRecord(string name, string gender, string DOB, string age, string phone, string address1, string address2,
									   string city, string state, string country, string accepted, string sickness, string prescriptions, string allergies, string other, string user, Patient patObj)
		{
			//connection
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			myConn.Open();

			MySqlCommand comm = myConn.CreateCommand();

			//command
			//LEFT THIS AS AN INSERT
			//Chang said to insert new row values in order to make it easier to check that changes are being made
			comm.CommandText = "SET FOREIGN_KEY_CHECKS=0;INSERT INTO wzb_patient (Name, Gender, DOB, Age, Phone, Street_1, Street_2, City, State, Country, Accepted_Date, Sickness, Prescriptions, Allergies, Special_or_Other, User_name) " +
											"VALUES (@name, @gender, @DOB, @age, @phone, @address1, @address2, @city, @state, @country, " +
											"@accepted, @sickness, @prescriptions, @allergies, @other, @user);SET FOREIGN_KEY_CHECKS=1";

			//if values are empty, retain old values and only change those with input text values
			name = patObj.getName();
			gender = patObj.getGender();
			age = patObj.getAge().ToString();
			DOB = patObj.getDOB();
			accepted = patObj.getAcceptedDate();

			//phone
			if (phone == "")
			{
				phone = patObj.getPhone();
			}

			//address1
			if (address1 == "")
			{
				address1 = patObj.getStreet1();
			}

			//address2
			if (address2 == "")
			{
				address2 = patObj.getStreet2();
			}

			//city
			if (city == "")
			{
				city = patObj.getCity();
			}

			//sate
			if (state == "")
			{
				state = patObj.getState();
			}

			//COMBINE our main values for add below
			//sickness
			if (sickness == "")
			{
				sickness = patObj.getSickness();
			}
			else
			{
				sickness = patObj.getSickness() + ", " + sickness;
			}

			//prescriptions
			if (prescriptions == "")
			{
				prescriptions = patObj.getPrescriptions().ToString();
			}
			else
			{
				prescriptions = ""+(Int32.Parse(prescriptions) + patObj.getPrescriptions());
			}

			//allergies
			if (allergies == "")
			{
				allergies = patObj.getAllergies();
			}
			else
			{
				allergies = patObj.getAllergies() + ", " + allergies;
			}

			//other
			if (other == "")
			{
				other = patObj.getSpecialOROther();
			}
			else
			{
				if(patObj.getSpecialOROther() == "")
				{
					other = patObj.getSpecialOROther() + "" + other;
				}
				else
				{
					other = patObj.getSpecialOROther() + ", " + other;
				}
			}

			//bind our values
			comm.Parameters.AddWithValue("@name", name);
			comm.Parameters.AddWithValue("@gender", gender);
			comm.Parameters.AddWithValue("@DOB", DOB);
			comm.Parameters.AddWithValue("@age", age);
			comm.Parameters.AddWithValue("@phone", phone);
			comm.Parameters.AddWithValue("@address1", address1);
			comm.Parameters.AddWithValue("@address2", address2);
			comm.Parameters.AddWithValue("@city", city);
			comm.Parameters.AddWithValue("@state", state);
			comm.Parameters.AddWithValue("@country", country);
			comm.Parameters.AddWithValue("@accepted", accepted);
			comm.Parameters.AddWithValue("@sickness", sickness);
			comm.Parameters.AddWithValue("@prescriptions", prescriptions);
			comm.Parameters.AddWithValue("@allergies", allergies);
			comm.Parameters.AddWithValue("@other", other);
			comm.Parameters.AddWithValue("@user", user);

			try
			{
				//execute the query
				//return 1 if this portion is reached
				comm.ExecuteNonQuery();
				return 1;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				myConn.Close();
			}

			return 0;
		}

		public List<Notice> getAllDoctorNotices(string docID)
		{
			List<Notice> noticeList = new List<Notice>();

			//connect string
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			//query
			string query = "SET FOREIGN_KEY_CHECKS=0; SELECT * FROM wzb_notice WHERE (send_to = @docID or Type_is ='MP') " +
				"AND (Type_is = 'RD' OR Type_is = 'AD' OR Type_is = 'PD' OR Type_is = 'DD' or Type_is = 'MP');SET FOREIGN_KEY_CHECKS=1";
			MySqlCommand cmd = new MySqlCommand(query, myConn);
			cmd.Parameters.AddWithValue("@docID", docID);

			MySqlDataReader myReader;

			try
			{
				myConn.Open();
				myReader = cmd.ExecuteReader();
				while (myReader.Read())
				{
					//store patient name
					string buildID = myReader["ID"].ToString();
					string buildtype = myReader["Type_is"].ToString();
					string buildto = myReader["Send_to"].ToString();
					string buildfrom = myReader["Received_from"].ToString();
					string buildmessage = myReader["Message"].ToString();

					//fill our list with new objects
					noticeList.Add(new Notice()
					{
						ID = buildID,
						type = buildtype,
						to = buildto,
						from = buildfrom,
						message = buildmessage
					});
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

			return noticeList;
		}

		public int deleteNotification(string notID)
		{
			MessageBox.Show("notID: "+notID);

			//connect string
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);
			myConn.Open();

			//query
			string query = "SET FOREIGN_KEY_CHECKS=0; DELETE FROM wzb_notice WHERE ID = @notID;SET FOREIGN_KEY_CHECKS=1";
			MySqlCommand cmd = new MySqlCommand();
			cmd.Connection = myConn;
			cmd.CommandText = query;
			cmd.Parameters.AddWithValue("@notID", notID);

			try
			{
				cmd.ExecuteNonQuery();
				return 1;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				myConn.Close();
			}

			return 0;
		}

		//method to create an appointment for a patient
		public int createAppointment(string patID, string docID, string date, string time, string additional)
		{
			//connect string
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			myConn.Open();

			MySqlCommand comm = myConn.CreateCommand();

			//command
			comm.CommandText = "SET FOREIGN_KEY_CHECKS=0;INSERT INTO wzb_appointment (Date, Time, Description, Doctor_ID, Patient_ID) " +
				"VALUES (@date, @time, @additional, @docID, @patientID);SET FOREIGN_KEY_CHECKS=1;";
			comm.Parameters.AddWithValue("@docID", docID);
			comm.Parameters.AddWithValue("@patientID", patID);
			comm.Parameters.AddWithValue("@date", date);
			comm.Parameters.AddWithValue("@time", time);
			comm.Parameters.AddWithValue("@additional", additional);

			try
			{
				//execute the command
				//return 1 if this part is reached, meaning success
				comm.ExecuteNonQuery();
				return 1;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				myConn.Close();
			}

			return 0;
		}

		public int checkAvailability(string date, string time)
		{
			//connect string
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			//query
			string query = "SET FOREIGN_KEY_CHECKS=0; SELECT * FROM wzb_appointment WHERE Date = @date AND Time = @time;SET FOREIGN_KEY_CHECKS=1";
			MySqlCommand cmd = new MySqlCommand(query, myConn);
			cmd.Parameters.AddWithValue("@date", date);
			cmd.Parameters.AddWithValue("@time", time);

			MySqlDataReader myReader;

			try
			{
				myConn.Open();
				myReader = cmd.ExecuteReader();
				while (myReader.Read())
				{
					//appointment exists already
					return 1;
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

			return 0;
		}

		public void createAppointmentNotice(string patID, string docID, string additional, string time, string date)
		{
			//connect string
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			myConn.Open();

			MySqlCommand comm = myConn.CreateCommand();

			//command
			comm.CommandText = "SET FOREIGN_KEY_CHECKS=0;INSERT INTO wzb_notice (Type_is, Response, Send_to, Received_from, Message) " +
				"VALUES ('AP', '1', @patientID, @docID, @additional);SET FOREIGN_KEY_CHECKS=1";
			comm.Parameters.AddWithValue("@docID", docID);
			comm.Parameters.AddWithValue("@patientID", patID);
			comm.Parameters.AddWithValue("@additional", "New Appointment! "+additional+" | Date: "+date+" At: "+time);

			try
			{
				//execute the command
				comm.ExecuteNonQuery();
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

		//method to permit or deny doctor for viewing medical records
		public void permitOrDeny(string value)
		{
			//value has "P"PatientID"DoctorID
			string query;
			string query2;



			//connection
			string myConnection = connectionCLass;
			MySqlConnection myConn = new MySqlConnection(myConnection);

			try
			{
				myConn.Open();

				if (value.Substring(0, 1) == "P")
				{
					query = "SET FOREIGN_KEY_CHECKS=0;Update wzb_notice set Response = '1' where type_is = 'MP' and send_to =@patID and received_from =@docId;SET FOREIGN_KEY_CHECKS=1";
					MySqlCommand cmd1 = new MySqlCommand(query, myConn);
					cmd1.Parameters.AddWithValue("@patID", (value[1]));
					cmd1.Parameters.AddWithValue("@docId", value[2]);
					Console.WriteLine(value[1] + " " + value[2]);
					MySqlDataReader myReader1;
					myReader1 = cmd1.ExecuteReader();
					myReader1.Close();

					query2 = "SET FOREIGN_KEY_CHECKS=0;Update wzb_doctor_patient set family_doctor = 1 where doctor_ID = @docID2 and patient_ID = @patID2;SET FOREIGN_KEY_CHECKS=1";
					MySqlCommand cmd2 = new MySqlCommand(query2, myConn);
					cmd2.Parameters.AddWithValue("@patID2", (value[1]));
					cmd2.Parameters.AddWithValue("@docId2", value[2]);
					MySqlDataReader myReader2;
					myReader2 = cmd2.ExecuteReader();
					myReader2.Close();
				}
				else
				{
					query = "SET FOREIGN_KEY_CHECKS=0;Update wzb_notice set Response = '0' where type_is = 'MP' and send_to =@patID and received_from =@docId;SET FOREIGN_KEY_CHECKS=1";
					MySqlCommand cmd1 = new MySqlCommand(query, myConn);
					cmd1.Parameters.AddWithValue("@patID", (value[1]));
					cmd1.Parameters.AddWithValue("@docId", value[2]);
					Console.WriteLine(value[1] + " " + value[2]);
					MySqlDataReader myReader1;
					myReader1 = cmd1.ExecuteReader();
					myReader1.Close();
				}


			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			myConn.Close();



		}

		//get methods
		public string getID()
        {
            return ID;
        }

        public string getType()
        {
            return type;
        }

        public string getTo()
        {
            return to;
        }

        public string getFrom()
        {
            return from;
        }

        public string getMessage()
        {
            return message;
        }

        public string getUserName()
        {
            return userName;
        }

        public string getPassword()
        {
            return password;
        }

		//set methods
		public void setID(string ID)
		{
			this.ID = ID;
		}

		public void setType(string type)
		{
			this.type = type;
		}

		public void setTo(string to)
		{
			this.to = to;
		}

		public void setFrom(string from)
		{
			this.from = from;
		}

		public void setMessage(string message)
		{
			this.message = message;
		}

		//added getName in order to update label of who is currently logged in - Will
		public string getName()
		{
			return name;
		}

		public string displayAllNoticesToString()
		{
			return "ID: " + ID + " | From: " + from + " | Message: " + message;
		}
	}
}
