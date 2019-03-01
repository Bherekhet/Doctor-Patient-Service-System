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
	public partial class DoctorGrantorRjectRefillRequest : UserControl
	{
		//objects to reference class methods
		Patient patObj = new Patient();
		DoctorClass docObj = new DoctorClass();
		Notice notObj = new Notice();

		public DoctorGrantorRjectRefillRequest()
		{
			InitializeComponent();

			//format our listview
			listView1.View = View.Details;
			listView1.Columns.Add("Results");
			listView1.Columns[0].Width = -2;
			listView1.GridLines = true;
			listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;

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
			for(int i = 0; i < searchResults.Count; i++)
			{
				CreateListViewItem(listView1, searchResults[i]);
			}
		}

		//grant 'R'
		private void buttonMakeAppointment_Click(object sender, EventArgs e)
		{
			if(listView1.SelectedItems.Count > 0)
			{
				//get patient tag tied with object
				Patient patID = (Patient)listView1.SelectedItems[0].Tag;
				//get textbox field
				string additional = textBox1.Text.ToString();

				//get our doctor ID
				string docID = docObj.calculateID(docObj.getUserName());

                //to show response in notice
                string response = "1";

				//create the notice, which returns a 1 if successful, 0 if a fail
				int check = notObj.createGrantNotice(patID.ID, docID, additional, response);

				//check if success or fail
				if (check == 1)
				{
					MessageBox.Show("Notice sent successfully! Permit has been granted!");
				}
				else
				{
					MessageBox.Show("Something went wrong :( Try again.");
				}

				//clear additional textbox
				textBox1.Clear();
				listView1.Items.Clear();
			}
			else
			{
				MessageBox.Show("Please Select a Patient!");
			}
		}

		//reject 'R'
		private void button1_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				//get patient tag tied with object
				Patient patID = (Patient)listView1.SelectedItems[0].Tag;
				//get textbox field
				string additional = textBox1.Text.ToString();

				//get doctor ID
				string docID = docObj.calculateID(docObj.getUserName());

				//to show response in notice
				string response = "0";

				//create our notice, and use return value of 1 or 0 to check if successful or not
				int check = notObj.createRejectNotice(patID.ID, docID, additional, response);

				//check if success or fail
				if (check == 1)
				{
					MessageBox.Show("Notice sent successfully! Permit has been rejected!");
				}
				else
				{
					MessageBox.Show("Something went wrong :( Try again.");
				}

				//clear additional textbox
				textBox1.Clear();
				listView1.Items.Clear();
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
	}
}
