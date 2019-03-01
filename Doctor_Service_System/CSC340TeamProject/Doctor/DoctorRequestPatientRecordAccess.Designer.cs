namespace CSC340TeamProject.Doctor
{
	partial class DoctorRequestPatientRecordAccess
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorRequestPatientRecordAccess));
			this.label6 = new System.Windows.Forms.Label();
			this.searchTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.searchButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.additionCommentsText = new System.Windows.Forms.TextBox();
			this.sendRequestButton = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Lucida Bright", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.label6.Location = new System.Drawing.Point(53, 15);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(510, 47);
			this.label6.TabIndex = 28;
			this.label6.Text = "Request Medical Record Permission";
			// 
			// searchTextBox
			// 
			this.searchTextBox.Location = new System.Drawing.Point(142, 65);
			this.searchTextBox.Name = "searchTextBox";
			this.searchTextBox.Size = new System.Drawing.Size(298, 20);
			this.searchTextBox.TabIndex = 29;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(55, 66);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(82, 19);
			this.label8.TabIndex = 37;
			this.label8.Text = "Last Name";
			// 
			// searchButton
			// 
			this.searchButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.searchButton.Image = ((System.Drawing.Image)(resources.GetObject("searchButton.Image")));
			this.searchButton.Location = new System.Drawing.Point(445, 50);
			this.searchButton.Margin = new System.Windows.Forms.Padding(2);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(44, 35);
			this.searchButton.TabIndex = 40;
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.additionCommentsText);
			this.groupBox1.Location = new System.Drawing.Point(545, 91);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(365, 277);
			this.groupBox1.TabIndex = 41;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Additional Comments";
			// 
			// additionCommentsText
			// 
			this.additionCommentsText.Location = new System.Drawing.Point(7, 20);
			this.additionCommentsText.Multiline = true;
			this.additionCommentsText.Name = "additionCommentsText";
			this.additionCommentsText.Size = new System.Drawing.Size(352, 251);
			this.additionCommentsText.TabIndex = 0;
			// 
			// sendRequestButton
			// 
			this.sendRequestButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sendRequestButton.Location = new System.Drawing.Point(545, 398);
			this.sendRequestButton.Margin = new System.Windows.Forms.Padding(2);
			this.sendRequestButton.Name = "sendRequestButton";
			this.sendRequestButton.Size = new System.Drawing.Size(365, 57);
			this.sendRequestButton.TabIndex = 42;
			this.sendRequestButton.Text = "Send Request";
			this.sendRequestButton.UseVisualStyleBackColor = true;
			this.sendRequestButton.Click += new System.EventHandler(this.sendRequestButton_Click);
			// 
			// listView1
			// 
			this.listView1.Location = new System.Drawing.Point(59, 91);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(430, 364);
			this.listView1.TabIndex = 43;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// DoctorRequestPatientRecordAccess
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.sendRequestButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.searchButton);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.searchTextBox);
			this.Controls.Add(this.label6);
			this.Name = "DoctorRequestPatientRecordAccess";
			this.Size = new System.Drawing.Size(968, 535);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox searchTextBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button searchButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox additionCommentsText;
		private System.Windows.Forms.Button sendRequestButton;
		private System.Windows.Forms.ListView listView1;
	}
}
