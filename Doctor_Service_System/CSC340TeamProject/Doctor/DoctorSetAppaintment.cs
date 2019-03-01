using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC340TeamProject
{
    public partial class UserControlD1 : UserControl
    {
		//objects to reference class methods
		Patient patObj = new Patient();
		DoctorClass docObj = new DoctorClass();
		Notice notObj = new Notice();

		//used to determine who is logged in
		string docID;

		public UserControlD1()
        {
            InitializeComponent();

			//format listview
			listView1.View = View.Details;
			listView1.Columns.Add("Results");
			listView1.Columns[0].Width = -2;
			listView1.GridLines = true;
			listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;

			//create base values for timeDrop
			timeComboBox.SelectedItem = null;
			timeComboBox.SelectedText = "---Time---";
			timeComboBox.Items.Add("8:00:00 AM");
			timeComboBox.Items.Add("10:00:00 AM");
			timeComboBox.Items.Add("1:00:00 PM");
			timeComboBox.Items.Add("3:00:00 PM");

			//set the minimum date to be selected to be today
			dateTimePicker1.MinDate = DateTime.Today;

			docID = docObj.calculateID(docObj.getUserName());
		}

		//make the appointment
		private void buttonMakeAppointment_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				Patient patID = (Patient)listView1.SelectedItems[0].Tag;

				//get textbox field
				string additional = textBoxReason.Text.ToString();
				string date = dateTimePicker1.Value.Date.ToString("yyyy/M/d");
				string time = timeComboBox.Text.ToString();

				if(time == "---Time---")
				{
					MessageBox.Show("Please select a Time!");
					return;
				}

				//check if appoinment is open or not
				int isOpen = notObj.checkAvailability(date, time);
				if(isOpen == 1)
				{
					MessageBox.Show("That time is unavailable!");
					return;
				}
				
				//create our notice, and use return value of 1 or 0 to check if successful or not
				int check = notObj.createAppointment(patID.ID, docID, date, time, additional);

				//check if success or fail
				if (check == 1)
				{
					MessageBox.Show("Appointment Set! A notification has been sent to the patient!");
					notObj.createAppointmentNotice(patID.ID, docID, additional, time, date);
				}
				else
				{
					MessageBox.Show("Something went wrong :( Try again.");
				}

				//clear additional textbox
				dateTimePicker1.Value = DateTime.Today;
				timeComboBox.SelectedItem = null;
				timeComboBox.SelectedText = "---Time---";
				textBoxReason.Clear();
				listView1.Items.Clear();
			}
			else
			{
				MessageBox.Show("Please select a patient!");
			}
		}

		//clear all text fields
		private void buttonClear_Click(object sender, EventArgs e)
		{
			//reset dateTimePIcker and ComboBox back to defaults and clear "Reason" text
			dateTimePicker1.Value = DateTime.Today;
			timeComboBox.SelectedItem = null;
			timeComboBox.SelectedText = "---Time---";
			textBoxReason.Clear();
		}

		//search button
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
	}
}
