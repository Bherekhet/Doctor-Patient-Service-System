using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CSC340TeamProject
{
	public partial class UserControl4 : UserControl
	{
		string connectionCLass = "server=csdatabase.eku.edu;port=3306;database=csc340_db;username=stu_csc340;password=Colonels18;SslMode=none";

		public UserControl4()
		{
			InitializeComponent();
		}



		private void UserControl4_Load(object sender, EventArgs e)
		{
			//create an object for a patient class to get patient name
			Patient patObj = new Patient(storeKeys.loggedInfo);
			textBoxFullName.Text = patObj.getName();


			//when the page loads it populates the doctor combo box with names of doctors - bereket
			//I would like to create a method in the future somewhere(preferably in one of the class) to call whenever we want to populate doctor combo boxes - bereket
			var doctorList = new List<string>();
			using (var myConn = new MySqlConnection())
			{
				myConn.ConnectionString = connectionCLass;
				myConn.Open();
				using (var cmd = new MySqlCommand("Select Name from wzb_Doctor Order by Name Asc", myConn))
				{
					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							doctorList.Add(Convert.ToString(reader["Name"]));
						}
					}
					myConn.Close();
				}
			}
			comboBoxDoctor.DataSource = new BindingSource(doctorList, null);
			comboBoxDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxDoctor.Enabled = true;
		}





		private void buttonClear_Click(object sender, EventArgs e)
		{
			textBoxMobile.Text = "";
			comboBoxDoctor.Text = "";
			textBoxReason.Text = "";
		}

		private void buttonMakePhoneCallRequest_Click(object sender, EventArgs e)
		{
			//creating an object for patient class using login info
			Patient patObj = new Patient(storeKeys.loggedInfo);
			textBoxFullName.Text = patObj.getName();

			//creating an object for doctor class using doctor name
			DoctorClass docObj = new DoctorClass(comboBoxDoctor.SelectedItem.ToString());


			foreach (Control c in groupBox1.Controls.Cast<Control>().OrderBy(c => c.TabIndex))
			{
				if (string.IsNullOrWhiteSpace(c.Text))
				{
					MessageBox.Show(string.Format("Empty field {0} ", c.Name.Substring(7)));
					c.Focus();
					return;
				}
			}


			//creates a list of inputs from patient when they request an immediate phone call. - Bereket
			List<string> requestDoctorCallList = new List<string>();
			requestDoctorCallList.Add("PD");
			requestDoctorCallList.Add(docObj.getID());
			requestDoctorCallList.Add(patObj.getID());
			requestDoctorCallList.Add(textBoxFullName.Text + " | " + textBoxMobile.Text + " | " + textBoxReason.Text);

			//calls a method from patient class to send a doctor phone call request - Bereket
			//*****Right now i have it where it a method is patient class is called and that methods calls a sendMessage() method in notice class - Bereket
			//You can change it if you want to
			patObj.requestDoctorCall(requestDoctorCallList);
			MessageBox.Show("You have successfully send your request for an immediate phone call.");
		}
	}
}
