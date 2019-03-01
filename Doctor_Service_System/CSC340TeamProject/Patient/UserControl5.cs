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

namespace CSC340TeamProject
{
	public partial class UserControl5 : UserControl
	{
		public UserControl5()
		{
			InitializeComponent();
		}

		private void UserControl5_Load(object sender, EventArgs e)
		{
			//notificationListView.Items.Clear();
			//notificationlistView2.Items.Clear();
			Notice notObj = new Notice();

			//list to display permit or reject listview
			ArrayList doctorMedicalPermit = new ArrayList();
			doctorMedicalPermit = notObj.getDoctorMedicalPermitRequest();

			for (int i = 0; i < doctorMedicalPermit.Count; i += 2)
			{
                Console.WriteLine(doctorMedicalPermit[i].ToString());
				ListViewItem listItem = new ListViewItem(doctorMedicalPermit[i].ToString());
				listItem.SubItems.Add(doctorMedicalPermit[i + 1].ToString());
				notificationListView.Items.Add(listItem);
			}


			//list to display notices
			ArrayList noticelist = new ArrayList();
			noticelist = notObj.getPatientNotices();
			for (int i = 0; i < noticelist.Count; i++)
			{
				ListViewItem listItem2 = new ListViewItem(noticelist[i].ToString());
				notificationlistView2.Items.Add(listItem2);
                Console.WriteLine(noticelist[i]);
			}
		}

        private void buttonPermit_Click(object sender, EventArgs e)
        {
            string temp = notificationListView.SelectedItems[0].Text;

            Notice notObj = new Notice();

            Patient patObj = new Patient(storeKeys.loginUserName);
            string patientID = patObj.getID();

            DoctorClass docObj = new DoctorClass(notificationListView.SelectedItems[0].Text);
            string doctorID = docObj.getID();

            //create a method to permit doctor in notice class
            notObj.permitOrDeny("P" + "" + patientID + "" + doctorID);
            MessageBox.Show("You have granted access to your medical records. ");
        }

        private void buttonReject_Click(object sender, EventArgs e)
        {
            Notice notObj = new Notice();

            Patient patObj = new Patient(storeKeys.loginUserName);
            string patientID = patObj.getID();

            DoctorClass docObj = new DoctorClass(notificationListView.SelectedItems[0].Text);
            string doctorID = docObj.getID();

            //create a method to permit doctor in notice class
            notObj.permitOrDeny("R" + "" + patientID + "" + doctorID);
            MessageBox.Show("You have denied access to your medical records. ");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            notificationListView.Items.Clear();
            Notice notObj = new Notice();
            //list to display permit or reject listview
            ArrayList doctorMedicalPermit = new ArrayList();
            doctorMedicalPermit = notObj.getDoctorMedicalPermitRequest();

            for (int i = 0; i < doctorMedicalPermit.Count; i += 2)
            {
                ListViewItem listItem = new ListViewItem(doctorMedicalPermit[i].ToString());
                listItem.SubItems.Add(doctorMedicalPermit[i + 1].ToString());
                notificationListView.Items.Add(listItem);
            }
        }

        private void buttonRefresh2_Click(object sender, EventArgs e)
        {
            notificationlistView2.Items.Clear();
            Notice notObj = new Notice();
            //list to display notices
            ArrayList noticelist = new ArrayList();
            noticelist = notObj.getPatientNotices();
            for (int i = 0; i < noticelist.Count; i++)
            {
                ListViewItem listItem2 = new ListViewItem(noticelist[i].ToString());
                notificationlistView2.Items.Add(listItem2);
                Console.WriteLine(noticelist[i]);
            }
        }
    }
}
