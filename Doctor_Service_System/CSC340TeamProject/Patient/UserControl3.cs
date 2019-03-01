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
	public partial class UserControl3 : UserControl
	{

		public UserControl3()
		{
			InitializeComponent();
		}

		private void UserControl3_Load(object sender, EventArgs e)
		{

		}

        private void buttonMedicalRecord_Click(object sender, EventArgs e)
        {
            //hides the panel that is covering patient records
            panelHidePatientRecord.SendToBack();

            //creates patient object
            Patient patObj = new Patient();

            //creates a string array to get patient records through patient class using patient username
            string[] queriedPatientRecored = patObj.getPatientRecords(storeKeys.loginUserName);

            //connect the labels with the right patient record(information about patient)
            labelFullName.Text = queriedPatientRecored[0];
            labelPatientGender.Text = queriedPatientRecored[1];
            labelAge.Text = queriedPatientRecored[2];
            labelTelephone.Text = queriedPatientRecored[3];
            labelAddress.Text = queriedPatientRecored[4];
            labelSickness.Text = queriedPatientRecored[5];
            labelAllergies.Text = queriedPatientRecored[6];
            labelSpecial1.Text = queriedPatientRecored[7];
            labelSpecial2.Text = queriedPatientRecored[8];
        }
    }
}
