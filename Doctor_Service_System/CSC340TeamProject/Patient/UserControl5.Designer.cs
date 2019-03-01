namespace CSC340TeamProject
{
    partial class UserControl5
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonReject = new System.Windows.Forms.Button();
            this.buttonPermit = new System.Windows.Forms.Button();
            this.notificationListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonRefresh2 = new System.Windows.Forms.Button();
            this.notificationlistView2 = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(62, 103);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1035, 471);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonRefresh);
            this.tabPage1.Controls.Add(this.buttonReject);
            this.tabPage1.Controls.Add(this.buttonPermit);
            this.tabPage1.Controls.Add(this.notificationListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1027, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Grant/Reject Medical Permit";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(284, 355);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(257, 44);
            this.buttonRefresh.TabIndex = 12;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonReject
            // 
            this.buttonReject.Location = new System.Drawing.Point(151, 354);
            this.buttonReject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReject.Name = "buttonReject";
            this.buttonReject.Size = new System.Drawing.Size(127, 44);
            this.buttonReject.TabIndex = 2;
            this.buttonReject.Text = "Reject";
            this.buttonReject.UseVisualStyleBackColor = true;
            this.buttonReject.Click += new System.EventHandler(this.buttonReject_Click);
            // 
            // buttonPermit
            // 
            this.buttonPermit.Location = new System.Drawing.Point(21, 354);
            this.buttonPermit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPermit.Name = "buttonPermit";
            this.buttonPermit.Size = new System.Drawing.Size(127, 44);
            this.buttonPermit.TabIndex = 1;
            this.buttonPermit.Text = "Permit";
            this.buttonPermit.UseVisualStyleBackColor = true;
            this.buttonPermit.Click += new System.EventHandler(this.buttonPermit_Click);
            // 
            // notificationListView
            // 
            this.notificationListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.notificationListView.Location = new System.Drawing.Point(21, 26);
            this.notificationListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.notificationListView.Name = "notificationListView";
            this.notificationListView.Size = new System.Drawing.Size(979, 323);
            this.notificationListView.TabIndex = 0;
            this.notificationListView.UseCompatibleStateImageBehavior = false;
            this.notificationListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name of Doctor";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Message from Doctor";
            this.columnHeader2.Width = 431;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonRefresh2);
            this.tabPage2.Controls.Add(this.notificationlistView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1027, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Check Status";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonRefresh2
            // 
            this.buttonRefresh2.Location = new System.Drawing.Point(16, 370);
            this.buttonRefresh2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRefresh2.Name = "buttonRefresh2";
            this.buttonRefresh2.Size = new System.Drawing.Size(257, 44);
            this.buttonRefresh2.TabIndex = 13;
            this.buttonRefresh2.Text = "Refresh";
            this.buttonRefresh2.UseVisualStyleBackColor = true;
            this.buttonRefresh2.Click += new System.EventHandler(this.buttonRefresh2_Click);
            // 
            // notificationlistView2
            // 
            this.notificationlistView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8});
            this.notificationlistView2.Location = new System.Drawing.Point(16, 18);
            this.notificationlistView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.notificationlistView2.Name = "notificationlistView2";
            this.notificationlistView2.Size = new System.Drawing.Size(989, 334);
            this.notificationlistView2.TabIndex = 0;
            this.notificationlistView2.UseCompatibleStateImageBehavior = false;
            this.notificationlistView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Status";
            this.columnHeader8.Width = 791;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(54, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(771, 66);
            this.label6.TabIndex = 12;
            this.label6.Text = "Check Request Status";
            // 
            // UserControl5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label6);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserControl5";
            this.Size = new System.Drawing.Size(1388, 650);
            this.Load += new System.EventHandler(this.UserControl5_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonReject;
        private System.Windows.Forms.Button buttonPermit;
        private System.Windows.Forms.ListView notificationListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonRefresh2;
        private System.Windows.Forms.ListView notificationlistView2;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label label6;
    }
}
