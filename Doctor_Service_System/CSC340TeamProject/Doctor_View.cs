using System;
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
    public partial class Doctor_View : Form
    {
        public Doctor_View(string name)
        {
            InitializeComponent();

			this.ControlBox = false;

			//bring our first user control to front to match button and panel alignment
			userControlD11.BringToFront();

			//set our logged in label
			loggedInLabel.Text = "Logged in as: "+name;
		
		}

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginWindow LW = new LoginWindow();
            LW.Show();
        }

		//set appointment
		//panel is the yellow bar used as an indicator of which button is currently clicked
		//repositioned on button click to match deminsions and position of the button
        private void button1_Click(object sender, EventArgs e)
        {
            panelShow.Height = button1.Height;
            panelShow.Top = button1.Top;
            userControlD11.BringToFront();
        }

		//check medical history
        private void button2_Click(object sender, EventArgs e)
        {
            panelShow.Height = button2.Height;
            panelShow.Top = button2.Top;
            userControlD21.BringToFront();
        }

		//request patient record access
		private void button3_Click(object sender, EventArgs e)
		{
			panelShow.Height = button3.Height;
			panelShow.Top = button3.Top;
			doctorRequestPatientRecordAccess1.BringToFront();
		}

		//grant/reject refill requests
		private void button4_Click(object sender, EventArgs e)
		{
			panelShow.Height = button4.Height;
			panelShow.Top = button4.Top;
			doctorGrantorRjectRefillRequest1.BringToFront();
		}

		//create/add/update record
		private void button5_Click(object sender, EventArgs e)
		{
			doctorCreateAddUpdateMedicalRecord1.RefreshList();
			panelShow.Height = button5.Height;
			panelShow.Top = button5.Top;
			doctorCreateAddUpdateMedicalRecord1.BringToFront();
		}

		//notications window
		private void button6_Click(object sender, EventArgs e)
		{
			panelShow.Height = button6.Height;
			panelShow.Top = button6.Top;
			doctorNotification1.BringToFront();
		}
	}
}
