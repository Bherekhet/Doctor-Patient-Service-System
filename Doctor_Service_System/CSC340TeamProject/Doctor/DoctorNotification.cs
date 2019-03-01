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

namespace CSC340TeamProject.Doctor
{
	public partial class DoctorNotification : UserControl
	{
		Notice notObj = new Notice();
		DoctorClass docObj = new DoctorClass();
		public List<string> displayNotices = new List<string>();

		public DoctorNotification()
		{
			InitializeComponent();

			notificationListView.View = View.Details;
			notificationListView.Columns.Add("Notification");
			notificationListView.Columns[0].Width = -2;
			notificationListView.GridLines = true;
			notificationListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;

			List<Notice> displayAllNotices = new List<Notice>();

			string docID = docObj.calculateID(docObj.getUserName());

			displayAllNotices = notObj.getAllDoctorNotices(docID);

			//display all list objects as strings
			for (int i = 0; i < displayAllNotices.Count; i++)
			{
				CreateListViewItem(notificationListView, displayAllNotices[i]);
			}
		}

		public void showNotices(ListView listView1)
		{
			displayNotices = notObj.getNotices();

			foreach (var notice in displayNotices)
			{
				listView1.Items.Add(notice);
			}
		}

		//refresh
		private void button1_Click(object sender, EventArgs e)
		{
			notificationListView.Items.Clear();

			List<Notice> displayAllNotices = new List<Notice>();

			string docID = docObj.calculateID(docObj.getUserName());

			displayAllNotices = notObj.getAllDoctorNotices(docID);

			//display all list objects as strings
			for (int i = 0; i < displayAllNotices.Count; i++)
			{
				CreateListViewItem(notificationListView, displayAllNotices[i]);
			}
		}

		//delete
		private void button2_Click(object sender, EventArgs e)
		{
			if (notificationListView.SelectedItems.Count > 0)
			{
				Notice notID = (Notice)notificationListView.SelectedItems[0].Tag;

				//create our notice, and use return value of 1 or 0 to check if successful or not
				/*
				 * DELETE database query is not allowed, so there's no way to delete it from the table
				 * meaning on a refresh, it will show the deleted notifcation
				 * LEAVING THIS HERE IN CASE CHANG WANTS TO MESS WITH IT
				int check = notObj.deleteNotification(notID.ID);

				//check if success or fail
				if (check == 1)
				{
					MessageBox.Show("Notification Deleted!");
				}
				else
				{
					MessageBox.Show("Something went wrong :( Try again.");
				}
				*/
				foreach (ListViewItem eachItem in notificationListView.SelectedItems)
				{
					notificationListView.Items.Remove(eachItem);
				}
			}
			else
			{
				MessageBox.Show("Please select a notice!!");
			}
		}

		//method to convert object to a listview item
		public void CreateListViewItem(ListView notificationListView, Notice obj)
		{
			//create listview item
			ListViewItem item = new ListViewItem();

			//store our object tostring in the listview item
			item.Text = obj.displayAllNoticesToString();

			//store our tag
			item.Tag = obj;

			//add it to listview
			notificationListView.Items.Add(item);
		}
	}
}
