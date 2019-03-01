using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace CSC340TeamProject.Doctor
{
	public partial class DoctorCreateAddUpdateMedicalRecord : UserControl
	{
		//objects to reference class methods
		Patient patObj = new Patient();
		DoctorClass docObj = new DoctorClass();
		Notice notObj = new Notice();

		string name;
		string gender;
		string DOB;
		string age;
		string phone;
		string address1;
		string address2;
		string city;
		string state;
		string country;
		string accepted;
		string sickness;
		string prescriptions;
		string allergies;
		string other;

		public DoctorCreateAddUpdateMedicalRecord()
		{
			InitializeComponent();

			//handler
			listView1.MouseClick += new MouseEventHandler(this.listView1_MouseClick);

			//format our listview
			listView1.View = View.Details;
			listView1.Columns.Add("Results");
			listView1.Columns[0].Width = -2;
			listView1.GridLines = true;
			listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;

			//create base values for genderDrop
			genderDrop.SelectedItem = null;
			genderDrop.SelectedText = "---Gender---";
			genderDrop.Items.Add("M");
			genderDrop.Items.Add("F");

			//populate countryDrop and give base values
			countryDrop.SelectedItem = null;
			countryDrop.SelectedText = "Country";
			var list = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(p => new RegionInfo(p.Name).EnglishName).Distinct().OrderBy(s => s).ToList();
			countryDrop.DataSource = list;
			
		}

		//search
		private void button2_Click(object sender, EventArgs e)
		{
			listView1.Items.Clear();

			//listview to store patient objects
			List<Patient> searchResults = new List<Patient>();

			//get the search textbox value
			string nameInput = textBox2.Text.ToString();

			//send to method to get our list of patients
			searchResults = patObj.getPatientSearch(nameInput);

			//display all list objects as strings
			for (int i = 0; i < searchResults.Count; i++)
			{
				CreateListViewItem(listView1, searchResults[i]);
			}
		}

		//---------CREATE
		//
		//
		//
		//
		//
		private void buttonMakeAppointment_Click(object sender, EventArgs e)
		{
			name = nameText.Text.ToString();

			//check if gender is on default value
			if(genderDrop.SelectedItem == null)
			{
				gender = "";
			}
			else
			{
				gender = genderDrop.SelectedItem.ToString();
			}

			//calculate age
			DateTime tempDate = dobTimePicker.Value.Date;
			var today = DateTime.Today;
			var tempAge = today.Year - tempDate.Year;
			//if (tempDate > today.AddYears(-tempAge)) tempAge--;

			//format date, convert age
			DOB = tempDate.ToString("yyyy/MM/d");
			age = tempAge.ToString();


			phone = phoneText.Text.ToString();
			address1 = address1Text.Text.ToString();
			address2 = address2Text.Text.ToString();
			city = cityText.Text.ToString();
			state = stateTextBox.Text.ToString();

			//check country base value
			if(countryDrop.SelectedItem == null)
			{
				country = "";
			}
			else
			{
				country = countryDrop.SelectedItem.ToString();
			}


			accepted = acceptedTimePicker.Value.Date.ToString("yyyy/M/d");
			sickness = sicknessText.Text.ToString();
			allergies = allergiesText.Text.ToString();
			other = specialText.Text.ToString();

			//check all fields have data
			if(name == "" || gender == "" || DOB == "" || phone == "" || address1 == "" || city == "" || state == "" || country == "" || accepted == "" || prescriptions == "" || allergies == "")
			{
				MessageBox.Show("All fields must contain a value!");
				return;
			}

			//check that prescription is a number
			int parsedValue;
			if (!int.TryParse(prescriptionsText.Text, out parsedValue))
			{
				MessageBox.Show("Prescription must be a number!");
				prescriptionsText.Clear();
				return;
			}
			else
			{
				prescriptions = prescriptionsText.Text.ToString();
			}


			//check that phone is entered correct
			int parsedValue2;
			if (!int.TryParse(phoneText.Text, out parsedValue2))
			{
				MessageBox.Show("Phone must be a number!");
				phoneText.Clear();
				return;
			}
			else
			{
				phone = phoneText.Text.ToString();
			}


			//calculate username to pass
			string user = "";
			var split = name.Split(' ');
			if(split.Length < 2)
			{
				user = name;
			}
			else
			{
				user = name[0] + split[1];
			}

			//MessageBox.Show(" | "+name+ " | " +gender+ " | " +DOB+" | "+age+ " | " +phone+ " | " +address1+ " | " +city + " | " +state + " | " +country + " | " +accepted + " | " +prescriptions + " | " +allergies+" | "+other);

			//call our database method, and check if it succeeded
			int check = notObj.createMedicalRecord(name, gender, DOB, age, phone, address1, address2, city, state, country, accepted, sickness, prescriptions, allergies, other, user);

			//display message accordingly
			if(check == 1)
			{
				MessageBox.Show("New Medical Record Created!");
				nameText.Clear();
				phoneText.Clear();
				address1Text.Clear();
				address2Text.Clear();
				cityText.Clear();
				stateTextBox.Clear();
				sicknessText.Clear();
				prescriptionsText.Clear();
				allergiesText.Clear();
				sicknessText.Clear();
				specialText.Clear();
			}
			else
			{
				MessageBox.Show("Something went wrong :( Try again.");
			}
		}
		//end of create
		//
		//
		//
		//

		//-------ADD------------
		//
		//
		//
		//
		//
		private void button1_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				Patient patID = (Patient)listView1.SelectedItems[0].Tag;
				name = patID.getName();
				string id = patID.getID();

				string docID = docObj.calculateID(docObj.getUserName());

				int checkFam = docObj.checkFamily(docID, id);

				if(checkFam == 0)
				{
					MessageBox.Show("You do not have permission to access this Patient's records!");
					return;
				}

				//check if gender is on default value
				if (genderDrop.SelectedItem == null)
				{
					gender = "";
				}
				else
				{
					gender = genderDrop.SelectedItem.ToString();
				}

				//calculate age
				DateTime tempDate = dobTimePicker.Value.Date;
				var today = DateTime.Today;
				var tempAge = today.Year - tempDate.Year;

				//format date, convert age
				DOB = tempDate.ToString("yyyy/MM/d");
				age = tempAge.ToString();


				phone = phoneText.Text.ToString();
				address1 = address1Text.Text.ToString();
				address2 = address2Text.Text.ToString();
				city = cityText.Text.ToString();
				state = stateTextBox.Text.ToString();

				//check country base value
				if (countryDrop.SelectedItem == null)
				{
					country = "";
				}
				else
				{
					country = countryDrop.SelectedItem.ToString();
				}

				accepted = acceptedTimePicker.Value.Date.ToString("yyyy/M/d");
				prescriptions = prescriptionsText.Text.ToString();
				sickness = sicknessText.Text.ToString();
				allergies = allergiesText.Text.ToString();
				other = specialText.Text.ToString();

				//check all fields have data

				//check that prescription is a number
				if (prescriptionsText.Text.ToString() != "")
				{
					int parsedValue;
					if (!int.TryParse(prescriptionsText.Text, out parsedValue))
					{
						MessageBox.Show("Prescription must be a number!");
						prescriptionsText.Clear();
						return;
					}
					else
					{
						prescriptions = prescriptionsText.Text.ToString();
					}
				}

				//check that phone is entered correct
				if (phoneText.Text.ToString() != "")
				{
					int parsedValue2;
					if (!int.TryParse(phoneText.Text, out parsedValue2))
					{
						MessageBox.Show("Phone must be a number!");
						phoneText.Clear();
						return;
					}
					else
					{
						phone = phoneText.Text.ToString();
					}
				}

				//calculate username to pass
				string user = "";
				var split = name.Split(' ');
				if (split.Length < 2)
				{
					user = name;
				}
				else
				{
					user = name[0] + split[1];
				}

				//MessageBox.Show(" | "+name+ " | " +gender+ " | " +DOB+" | "+age+ " | " +phone+ " | " +address1+ " | " +city + " | " +state + " | " +country + " | " +accepted + " | " +prescriptions + " | " +allergies+" | "+other);

				//call our database method, and check if it succeeded
				Patient passPatObj = new Patient();

				passPatObj = patID.getPatientObject(patID.getID());

				int check = notObj.addMedicalRecord(name, gender, DOB, age, phone, address1, address2, city, state, country, accepted, sickness, prescriptions, allergies, other, user, passPatObj);

				//display message accordingly
				if (check == 1)
				{
					MessageBox.Show("Entered information has been modified/updated!");
					nameText.Clear();
					phoneText.Clear();
					address1Text.Clear();
					address2Text.Clear();
					cityText.Clear();
					stateTextBox.Clear();
					sicknessText.Clear();
					prescriptionsText.Clear();
					allergiesText.Clear();
					sicknessText.Clear();
					specialText.Clear();
				}
				else
				{
					MessageBox.Show("Something went wrong :( Try again.");
				}
			}
			else
			{
				MessageBox.Show("Please select a patient!");
			}
		}
		//end of add
		//
		//
		//
		//
		//

		//-------UPDATE--------------
		//
		//
		//
		//
		//
		private void button3_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				Patient patID = (Patient)listView1.SelectedItems[0].Tag;
				name = patID.getName();
				string id = patID.getID();

				string docID = docObj.calculateID(docObj.getUserName());

				int checkFam = docObj.checkFamily(docID, id);

				if (checkFam == 0)
				{
					MessageBox.Show("You do not have permission to access this Patient's records!");
					return;
				}

				//check if gender is on default value
				if (genderDrop.SelectedItem == null)
				{
					gender = "";
				}
				else
				{
					gender = genderDrop.SelectedItem.ToString();
				}

				//calculate age
				DateTime tempDate = dobTimePicker.Value.Date;
				var today = DateTime.Today;
				var tempAge = today.Year - tempDate.Year;

				//format date, convert age
				DOB = tempDate.ToString("yyyy/MM/d");
				age = tempAge.ToString();


				phone = phoneText.Text.ToString();
				address1 = address1Text.Text.ToString();
				address2 = address2Text.Text.ToString();
				city = cityText.Text.ToString();
				state = stateTextBox.Text.ToString();

				//check country base value
				if (countryDrop.SelectedItem == null)
				{
					country = "";
				}
				else
				{
					country = countryDrop.SelectedItem.ToString();
				}


				accepted = acceptedTimePicker.Value.Date.ToString("yyyy/M/d");
				prescriptions = prescriptionsText.Text.ToString();
				sickness = sicknessText.Text.ToString();
				allergies = allergiesText.Text.ToString();
				other = specialText.Text.ToString();

				//check all fields have data

				//check that prescription is a number
				if (prescriptionsText.Text.ToString() != "")
				{
					int parsedValue;
					if (!int.TryParse(prescriptionsText.Text, out parsedValue))
					{
						MessageBox.Show("Prescription must be a number!");
						prescriptionsText.Clear();
						return;
					}
					else
					{
						prescriptions = prescriptionsText.Text.ToString();
					}
				}

				//check that phone is entered correct
				if (phoneText.Text.ToString() != "")
				{
					int parsedValue2;
					if (!int.TryParse(phoneText.Text, out parsedValue2))
					{
						MessageBox.Show("Phone must be a number!");
						phoneText.Clear();
						return;
					}
					else
					{
						phone = phoneText.Text.ToString();
					}
				}

				//calculate username to pass
				string user = "";
				var split = name.Split(' ');
				if (split.Length < 2)
				{
					user = name;
				}
				else
				{
					user = name[0] + split[1];
				}

				//MessageBox.Show(" | "+name+ " | " +gender+ " | " +DOB+" | "+age+ " | " +phone+ " | " +address1+ " | " +city + " | " +state + " | " +country + " | " +accepted + " | " +prescriptions + " | " +allergies+" | "+other);

				//call our database method, and check if it succeeded
				Patient passPatObj = new Patient();

				passPatObj = patID.getPatientObject(patID.getID());

				int check = notObj.updateMedicalRecord(name, gender, DOB, age, phone, address1, address2, city, state, country, accepted, sickness, prescriptions, allergies, other, user, passPatObj);

				//display message accordingly
				if (check == 1)
				{
					MessageBox.Show("Medical Record has been Updated!");
					nameText.Clear();
					phoneText.Clear();
					address1Text.Clear();
					address2Text.Clear();
					cityText.Clear();
					stateTextBox.Clear();
					sicknessText.Clear();
					prescriptionsText.Clear();
					allergiesText.Clear();
					sicknessText.Clear();
					specialText.Clear();
				}
				else
				{
					MessageBox.Show("Something went wrong :( Try again.");
				}

			}
			else
			{
				MessageBox.Show("Please select a patient!");
			}
		}
		//end of update
		//
		//
		//
		//
		//

		//method to convert object to a listview item
		public void CreateListViewItem(ListView listView, Patient obj)
		{
			//create listview item
			ListViewItem item = new ListViewItem();
			//store our object tostring in the listview item
			item.Text = obj.patientGrantorRejectToString();
			//store our tag
			item.Tag = obj;

			//add it to listview
			listView.Items.Add(item);
		}

		void listView1_MouseClick(Object sender, MouseEventArgs e)
		{
			// Make sure it was a single left click, like the normal Click event
			if ((e.Button == MouseButtons.Left))
			{
				if (listView1.SelectedItems.Count > 0)
				{
					nameText.ReadOnly = true;
					genderDrop.Enabled = false;
					dobTimePicker.Enabled = false;
					acceptedTimePicker.Enabled = false;
				}
			}
		}

		public void RefreshList()
		{
			listView1.Items.Clear();
			textBox2.Clear();

			nameText.ReadOnly = false;
			genderDrop.Enabled = true;
			dobTimePicker.Enabled = true;
			acceptedTimePicker.Enabled = true;
		}
	}
}
