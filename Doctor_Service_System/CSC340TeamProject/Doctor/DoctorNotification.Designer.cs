namespace CSC340TeamProject.Doctor
{
	partial class DoctorNotification
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
			this.label6 = new System.Windows.Forms.Label();
			this.notificationListView = new System.Windows.Forms.ListView();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Lucida Bright", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.label6.Location = new System.Drawing.Point(2, 9);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(432, 33);
			this.label6.TabIndex = 12;
			this.label6.Text = "Notifications";
			// 
			// notificationListView
			// 
			this.notificationListView.Location = new System.Drawing.Point(3, 45);
			this.notificationListView.Name = "notificationListView";
			this.notificationListView.Size = new System.Drawing.Size(960, 407);
			this.notificationListView.TabIndex = 13;
			this.notificationListView.UseCompatibleStateImageBehavior = false;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(87, 458);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(377, 73);
			this.button1.TabIndex = 14;
			this.button1.Text = "Refresh Notifications";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(490, 458);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(377, 73);
			this.button2.TabIndex = 15;
			this.button2.Text = "Delete";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// DoctorNotification
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.notificationListView);
			this.Controls.Add(this.label6);
			this.Name = "DoctorNotification";
			this.Size = new System.Drawing.Size(968, 535);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ListView notificationListView;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}
