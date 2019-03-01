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
	public partial class UserControlD2 : UserControl
	{
		DoctorClass docObj = new DoctorClass();
		Patient patObj = new Patient();
		Notice notObj = new Notice();

		public UserControlD2()
		{
			InitializeComponent();

			//format our listview
			listView1.View = View.Details;
			listView1.Columns.Add("Results");
			listView1.Columns[0].Width = -2;
			listView1.GridLines = true;
			listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				Patient patID = (Patient)listView1.SelectedItems[0].Tag;

				//call our method that will do the check for medical records, as well as populate
				//an array with the record information and then return it
				string[] displayRecords = docObj.viewMedicalRecord(patID.ID);

				//check our returned array. if first position is "Invalid", we do not have permission to view
				//otherwise, it is populated with data

				if (displayRecords[0] == "Invalid")
				{
					MessageBox.Show("You do not have permission to view these records!");
				}
				else if (displayRecords[0] == "Incorrect")
				{
					MessageBox.Show("Incorrect Information/No Patient Matches!");
				}
				else
				{
					//change our label data
					nameLabelText.Text = displayRecords[0];
					sicknessLabelText.Text = displayRecords[1];
					allergiesLabelText.Text = displayRecords[2];
					specialLabelText.Text = displayRecords[3];
				}

				//clear textboxes
				textBoxFirstName.Clear();
				textBoxLastName.Clear();
			}
			else
			{
				MessageBox.Show("Please Select a Patient!");
			}
		}

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

		private void searchButton_Click(object sender, EventArgs e)
		{
			listView1.Items.Clear();

			//listview to store patient objects
			List<Patient> searchResults = new List<Patient>();

			//get the search textbox value
			string firstName = textBoxLastName.Text.ToString();
			string lastName = textBoxFirstName.Text.ToString();

			string nameInput = firstName + " " + lastName;

			//send to method to get our list of patients
			searchResults = patObj.getPatientSearch(nameInput);

			//display all list objects as strings
			for (int i = 0; i < searchResults.Count; i++)
			{
				CreateListViewItem(listView1, searchResults[i]);
			}
		}
	}
}
