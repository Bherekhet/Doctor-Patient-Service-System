using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC340TeamProject
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();

			textBoxPassword.UseSystemPasswordChar = true;
        }

        //initialize pass and user
        string signedUserName;
        string signedPassword;
		string signedName;

        private void LoginWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
			//create arraylist to store legin credentials
            ArrayList userLoginList = new ArrayList();
			//patient_view object
            Patient_View dps = new Patient_View();

			//get textbox fields
            string userName = textBoxUserName.Text;
            string password = textBoxPassword.Text;

			//add textbox values to list, after validating the credentials
            userLoginList = Notice.validateUserInfo(userName, password);
            //Console.WriteLine("count" + userLoginList.Count);

			//if empty, meaning no validated credentials, incorrect login
            if (userLoginList.Count != 0)
            {
				//class objects
				DoctorClass docObj = new DoctorClass();
                Patient patObj = new Patient();
                Notice thisNotice = (Notice)(userLoginList[0]);
                signedUserName = thisNotice.getUserName();
                
				//send userName to DoctorClass and Patient in order to store other information used in later queries
				patObj.setUserName(signedUserName);
				docObj.setUserName(signedUserName);

				//retrieve the password and name of the user stored in notice class
                signedPassword = thisNotice.getPassword();
				signedName = thisNotice.getName(); //added this to pass to both views in order to update who is logged in - will

                storeKeys.loggedInfo = userName;

				//open patient_view, where credentials will be checked
				//will either continue with patient_view, or will open doctor_view
                dps.validateLabel(signedPassword[0], signedName);

				//hide login window
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect, please try again!");    
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }


    }
}
