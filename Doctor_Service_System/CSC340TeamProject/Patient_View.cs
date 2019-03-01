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
    public partial class Patient_View : Form
    {
        public Patient_View()
        {
            InitializeComponent();
			this.ControlBox = false;
			panelShow.Height = button1.Height;
            userControl11.BringToFront();
            
        }

		//method to check password and determine which window to show based on password
		public void validateLabel(char password, string name)
		{
			LoginWindow LW = new LoginWindow();
			if (password == 'P')
			{
				LW.Hide();
				this.Show();
				patientPanel.Visible = true;
				loggedInLabel.Text = "Logged in as: " + name;
			}
			else if (password == 'D')
			{
				Doctor_View dp2 = new Doctor_View(name);
				LW.Hide();
				dp2.Show();
			}
		}


		private void button1_Click_1(object sender, EventArgs e)
		{
			panelShow.Height = button1.Height;
			panelShow.Top = button1.Top;
			userControl11.BringToFront();


		}
		private void button2_Click(object sender, EventArgs e)
		{
			panelShow.Height = button2.Height;
			panelShow.Top = button2.Top;
			userControl21.BringToFront();
		}


		private void button3_Click(object sender, EventArgs e)
		{
			panelShow.Height = button3.Height;
			panelShow.Top = button3.Top;
			userControl31.BringToFront();
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.Close();
			LoginWindow LW = new LoginWindow();
			LW.Show();

		}

		private void button4_Click(object sender, EventArgs e)
		{
			panelShow.Height = button4.Height;
			panelShow.Top = button4.Top;
			userControl41.BringToFront();
		}

		private void button5_Click(object sender, EventArgs e)
		{
            
            panelShow.Height = button5.Height;
			panelShow.Top = button5.Top;
			userControl51.BringToFront();

        }

		private void pictureBox2_Click(object sender, EventArgs e)
		{

		}
	}
}
