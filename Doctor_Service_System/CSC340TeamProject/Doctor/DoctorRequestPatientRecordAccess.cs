using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC340TeamProject.Doctor
{
	public partial class DoctorRequestPatientRecordAccess : UserControl
	{
		//objects to reference class methods
		Patient patObj = new Patient();
		DoctorClass docObj = new DoctorClass();
		Notice notObj = new Notice();

		public DoctorRequestPatientRecordAccess()
		{
			InitializeComponent();

			//format our listview
			listView1.View = View.Details;
			listView1.Columns.Add("Results");
			listView1.Columns[0].Width = -2;
			listView1.GridLines = true;
			listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
		}

		//send request
		private void sendRequestButton_Click(object sender, EventArgs e)
		{
			if(listView1.SelectedItems.Count > 0)
			{
				Patient patID = (Patient)listView1.SelectedItems[0].Tag;

				//get textbox field
				string additional = additionCommentsText.Text.ToString();

				//get doctor ID
				string docID = docObj.calculateID(docObj.getUserName());

				//create our notice, and use return value of 1 or 0 to check if successful or not
				int check = notObj.createMedicalRequestNotice(patID.ID, docID, additional);

				//check if success or fail
				if (check == 1)
				{
					MessageBox.Show("Medical Records Permission Request Sent Successfully!");
				}
				else
				{
					MessageBox.Show("Something went wrong :( Try again.");
				}

				//clear additional textbox
				additionCommentsText.Clear();
				listView1.Items.Clear();
			}
			else
			{
				MessageBox.Show("Please select a patient!");
			}
		}

		//search
		private void searchButton_Click(object sender, EventArgs e)
		{
			listView1.Items.Clear();

			//listview to store patient objects
			List<Patient> searchResults = new List<Patient>();

			//get the search textbox value
			string nameInput = searchTextBox.Text.ToString();

			//send to method to get our list of patients
			searchResults = patObj.getPatientSearch(nameInput);

			//display all list objects as strings
			for (int i = 0; i < searchResults.Count; i++)
			{
				CreateListViewItem(listView1, searchResults[i]);
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
	}
}
