using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;

namespace CSC340TeamProject
{
    public partial class userControl1 : UserControl
    {
		string connectionCLass = "server=csdatabase.eku.edu;port=3306;database=csc340_db;username=stu_csc340;password=Colonels18;SslMode=none";

		public userControl1()
        {
            InitializeComponent();

			//create base values for timeDrop
			comboBoxAvailableHours.SelectedItem = null;
			comboBoxAvailableHours.SelectedText = "---Time---";
			comboBoxAvailableHours.Items.Add("8:00:00 AM");
			comboBoxAvailableHours.Items.Add("10:00:00 AM");
			comboBoxAvailableHours.Items.Add("1:00:00 PM");
			comboBoxAvailableHours.Items.Add("3:00:00 PM");
		}


        

        private void buttonMakeAppointment_Click(object sender, EventArgs e)
        {
            //create objects for patient class using login username
            Patient patObj = new Patient(storeKeys.loggedInfo);

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

            //check if appoinment is open or not
            Notice notObj = new Notice();
            int isOpen = notObj.checkAvailability(dateTimePicker1.Text, comboBoxAvailableHours.SelectedItem.ToString());
            if (isOpen == 1)
            {
                MessageBox.Show("That time is unavailable!");
                return;
            }

            MessageBox.Show("You have successfully made an appointment with " + comboBoxDoctor.SelectedItem.ToString() + ".");

            List<string> appoint = new List<string>();
            appoint.Add(docObj.getID());//doctor ID
            appoint.Add(patObj.getID());// patient id
            appoint.Add(patObj.getName());//patient full name
            appoint.Add(comboBoxAvailableHours.SelectedItem.ToString());//selected appointment time  
            appoint.Add(dateTimePicker1.Text);//selected appointment date
            appoint.Add(textBoxReason.Text);//discription for doctor from patient about the appointment
            patObj.requestDoctorAppointment(appoint);
        }

        private void userControl1_Load(object sender, EventArgs e)
        {
            Patient patObj = new Patient(storeKeys.loggedInfo);
            textBoxFullName.Text = patObj.getName();//automatically sets the name of patient
            
            var list = new List<string>();
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
                            list.Add(Convert.ToString(reader["Name"]));
                        }
                    }
                    myConn.Close();
                }
            }
            comboBoxDoctor.DataSource = new BindingSource(list, null);
            comboBoxDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDoctor.Enabled = true;
            
        }
        
		private void buttonClear_Click(object sender, EventArgs e)
		{
			comboBoxDoctor.Text = "";
			textBoxReason.Text = "";
			dateTimePicker1.Text = "";
			comboBoxAvailableHours.Text = "";
		}

       
    }

}
