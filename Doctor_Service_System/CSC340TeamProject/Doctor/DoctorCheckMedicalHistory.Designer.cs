namespace CSC340TeamProject
{
    partial class UserControlD2
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
			this.button1 = new System.Windows.Forms.Button();
			this.textBoxFirstName = new System.Windows.Forms.TextBox();
			this.textBoxLastName = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.specialLabelText = new System.Windows.Forms.Label();
			this.allergiesLabelText = new System.Windows.Forms.Label();
			this.sicknessLabelText = new System.Windows.Forms.Label();
			this.nameLabelText = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.sicknessLabel = new System.Windows.Forms.Label();
			this.nameLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.searchButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Lucida Bright", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.label6.Location = new System.Drawing.Point(53, 16);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(432, 33);
			this.label6.TabIndex = 11;
			this.label6.Text = "Medical History";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(7, 384);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(252, 62);
			this.button1.TabIndex = 19;
			this.button1.Text = "Display Record";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBoxFirstName
			// 
			this.textBoxFirstName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxFirstName.ForeColor = System.Drawing.SystemColors.InfoText;
			this.textBoxFirstName.Location = new System.Drawing.Point(101, 125);
			this.textBoxFirstName.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxFirstName.Name = "textBoxFirstName";
			this.textBoxFirstName.Size = new System.Drawing.Size(158, 24);
			this.textBoxFirstName.TabIndex = 18;
			this.textBoxFirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxLastName
			// 
			this.textBoxLastName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxLastName.ForeColor = System.Drawing.SystemColors.InfoText;
			this.textBoxLastName.Location = new System.Drawing.Point(101, 81);
			this.textBoxLastName.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxLastName.Name = "textBoxLastName";
			this.textBoxLastName.Size = new System.Drawing.Size(158, 24);
			this.textBoxLastName.TabIndex = 17;
			this.textBoxLastName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tableLayoutPanel1);
			this.groupBox1.Location = new System.Drawing.Point(285, 81);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(647, 429);
			this.groupBox1.TabIndex = 21;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Medical Information";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.specialLabelText, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.allergiesLabelText, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.sicknessLabelText, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.nameLabelText, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.sicknessLabel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.nameLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.09678F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.90322F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(635, 404);
			this.tableLayoutPanel1.TabIndex = 3;
			// 
			// specialLabelText
			// 
			this.specialLabelText.AutoSize = true;
			this.specialLabelText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.specialLabelText.Location = new System.Drawing.Point(321, 271);
			this.specialLabelText.Name = "specialLabelText";
			this.specialLabelText.Size = new System.Drawing.Size(69, 19);
			this.specialLabelText.TabIndex = 7;
			this.specialLabelText.Text = "------------";
			// 
			// allergiesLabelText
			// 
			this.allergiesLabelText.AutoSize = true;
			this.allergiesLabelText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.allergiesLabelText.Location = new System.Drawing.Point(321, 154);
			this.allergiesLabelText.Name = "allergiesLabelText";
			this.allergiesLabelText.Size = new System.Drawing.Size(69, 19);
			this.allergiesLabelText.TabIndex = 6;
			this.allergiesLabelText.Text = "------------";
			// 
			// sicknessLabelText
			// 
			this.sicknessLabelText.AutoSize = true;
			this.sicknessLabelText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sicknessLabelText.Location = new System.Drawing.Point(321, 59);
			this.sicknessLabelText.Name = "sicknessLabelText";
			this.sicknessLabelText.Size = new System.Drawing.Size(69, 19);
			this.sicknessLabelText.TabIndex = 5;
			this.sicknessLabelText.Text = "------------";
			// 
			// nameLabelText
			// 
			this.nameLabelText.AutoSize = true;
			this.nameLabelText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nameLabelText.Location = new System.Drawing.Point(321, 2);
			this.nameLabelText.Name = "nameLabelText";
			this.nameLabelText.Size = new System.Drawing.Size(69, 19);
			this.nameLabelText.TabIndex = 4;
			this.nameLabelText.Text = "------------";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(5, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(102, 45);
			this.label2.TabIndex = 2;
			this.label2.Text = "Sickness";
			// 
			// sicknessLabel
			// 
			this.sicknessLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sicknessLabel.Location = new System.Drawing.Point(5, 154);
			this.sicknessLabel.Name = "sicknessLabel";
			this.sicknessLabel.Size = new System.Drawing.Size(286, 74);
			this.sicknessLabel.TabIndex = 1;
			this.sicknessLabel.Text = "Allergies";
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nameLabel.Location = new System.Drawing.Point(5, 2);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(49, 19);
			this.nameLabel.TabIndex = 0;
			this.nameLabel.Text = "Name";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(5, 271);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 19);
			this.label3.TabIndex = 3;
			this.label3.Text = "Special/Other";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(3, 82);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(93, 19);
			this.label4.TabIndex = 22;
			this.label4.Text = "First Name: ";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(3, 126);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(92, 19);
			this.label5.TabIndex = 23;
			this.label5.Text = "Last Name: ";
			// 
			// listView1
			// 
			this.listView1.Location = new System.Drawing.Point(7, 201);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(252, 178);
			this.listView1.TabIndex = 24;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// searchButton
			// 
			this.searchButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.searchButton.Location = new System.Drawing.Point(7, 159);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(252, 36);
			this.searchButton.TabIndex = 25;
			this.searchButton.Text = "Search for Patient";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
			// 
			// UserControlD2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.searchButton);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBoxFirstName);
			this.Controls.Add(this.textBoxLastName);
			this.Controls.Add(this.label6);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "UserControlD2";
			this.Size = new System.Drawing.Size(968, 535);
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label specialLabelText;
		private System.Windows.Forms.Label allergiesLabelText;
		private System.Windows.Forms.Label sicknessLabelText;
		private System.Windows.Forms.Label nameLabelText;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label sicknessLabel;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button searchButton;
	}
}
