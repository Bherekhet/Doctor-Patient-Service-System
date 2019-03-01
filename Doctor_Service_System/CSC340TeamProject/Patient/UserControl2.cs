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
    public partial class UserControl2 : UserControl
    {

		public UserControl2()
        {
            InitializeComponent();
        }


        private void buttonSubmitRefillRequest_Click(object sender, EventArgs e)
        {
            //create objects of different classes
            Notice notObj = new Notice();

            DoctorClass docObj = new DoctorClass(comboBoxDoctor.SelectedItem.ToString());

            Patient patObj = new Patient(storeKeys.loggedInfo);
            textBoxFullName.Text = patObj.getName();

            
            

            //check if field is empty
            foreach (Control c in groupBox1.Controls.Cast<Control>().OrderBy(c => c.TabIndex))
            {
                if (string.IsNullOrWhiteSpace(c.Text))
                {
                    MessageBox.Show(string.Format("Empty field {0} ", c.Name.Substring(7)));
                    c.Focus();
                    return;
                }
            }
            

            //creates a list of data inputed from patient when they request a refill permit - Bereket
            List<string> requestRefillPermitList = new List<string>();
            requestRefillPermitList.Add("RD");//type
            requestRefillPermitList.Add(docObj.getID());//send t0
            requestRefillPermitList.Add(patObj.getID());//received from
            requestRefillPermitList.Add(patObj.getName() + " | " + textBoxMedicationName.Text + " | " + textBoxReason.Text);//message + additional

            //calls a method from patient class to send a doctor phone call request - Bereket
            notObj.SendMessage(requestRefillPermitList);

            MessageBox.Show("You have successfully sent your medicine refill request!");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxReason.Text = "";
            comboBoxDoctor.Text = "";
            textBoxMedicationName.Text = "";
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            Patient patObj = new Patient(storeKeys.loggedInfo);
            textBoxFullName.Text = patObj.getName();

            DoctorClass docObj = new DoctorClass();
            

            //when appointment page opens it loads the doctors under dr dropdownlist
            List<string> newList = new List<string>();
            newList = docObj.getDoctor();
            //Console.WriteLine("classDoctor2.getDoctor()" + classDoctor2.getDoctor());
            comboBoxDoctor.DataSource = new BindingSource(newList, null);
            comboBoxDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDoctor.Enabled = true;
            
        }
        
    }
}
