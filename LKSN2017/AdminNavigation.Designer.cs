namespace LKSN2017
{
    partial class AdminNavigation
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAdminName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnManageStudent = new System.Windows.Forms.Button();
            this.btnManageTeacher = new System.Windows.Forms.Button();
            this.btnManageClass = new System.Windows.Forms.Button();
            this.btnManageSchedule = new System.Windows.Forms.Button();
            this.btnFinalizeSchedule = new System.Windows.Forms.Button();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAdminName
            // 
            this.txtAdminName.AutoSize = true;
            this.txtAdminName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdminName.Location = new System.Drawing.Point(137, 41);
            this.txtAdminName.Name = "txtAdminName";
            this.txtAdminName.Size = new System.Drawing.Size(108, 20);
            this.txtAdminName.TabIndex = 3;
            this.txtAdminName.Text = "[Admin Name]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome,";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(316, 41);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(141, 23);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnManageStudent
            // 
            this.btnManageStudent.Location = new System.Drawing.Point(81, 106);
            this.btnManageStudent.Name = "btnManageStudent";
            this.btnManageStudent.Size = new System.Drawing.Size(180, 23);
            this.btnManageStudent.TabIndex = 5;
            this.btnManageStudent.Text = "Manage Student";
            this.btnManageStudent.UseVisualStyleBackColor = true;
            this.btnManageStudent.Click += new System.EventHandler(this.btnManageStudent_Click);
            // 
            // btnManageTeacher
            // 
            this.btnManageTeacher.Location = new System.Drawing.Point(81, 146);
            this.btnManageTeacher.Name = "btnManageTeacher";
            this.btnManageTeacher.Size = new System.Drawing.Size(180, 23);
            this.btnManageTeacher.TabIndex = 6;
            this.btnManageTeacher.Text = "ManageTeacher";
            this.btnManageTeacher.UseVisualStyleBackColor = true;
            this.btnManageTeacher.Click += new System.EventHandler(this.btnManageTeacher_Click);
            // 
            // btnManageClass
            // 
            this.btnManageClass.Location = new System.Drawing.Point(81, 184);
            this.btnManageClass.Name = "btnManageClass";
            this.btnManageClass.Size = new System.Drawing.Size(180, 23);
            this.btnManageClass.TabIndex = 7;
            this.btnManageClass.Text = "Manage Class";
            this.btnManageClass.UseVisualStyleBackColor = true;
            this.btnManageClass.Click += new System.EventHandler(this.btnManageClass_Click);
            // 
            // btnManageSchedule
            // 
            this.btnManageSchedule.Location = new System.Drawing.Point(277, 106);
            this.btnManageSchedule.Name = "btnManageSchedule";
            this.btnManageSchedule.Size = new System.Drawing.Size(180, 23);
            this.btnManageSchedule.TabIndex = 8;
            this.btnManageSchedule.Text = "Manage Schedule";
            this.btnManageSchedule.UseVisualStyleBackColor = true;
            this.btnManageSchedule.Click += new System.EventHandler(this.btnManageSchedule_Click);
            // 
            // btnFinalizeSchedule
            // 
            this.btnFinalizeSchedule.Location = new System.Drawing.Point(277, 146);
            this.btnFinalizeSchedule.Name = "btnFinalizeSchedule";
            this.btnFinalizeSchedule.Size = new System.Drawing.Size(180, 23);
            this.btnFinalizeSchedule.TabIndex = 9;
            this.btnFinalizeSchedule.Text = "Finalize Schedule";
            this.btnFinalizeSchedule.UseVisualStyleBackColor = true;
            this.btnFinalizeSchedule.Click += new System.EventHandler(this.btnFinalizeSchedule_Click);
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(277, 184);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(180, 23);
            this.btnViewReport.TabIndex = 10;
            this.btnViewReport.Text = "View Report Score";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // AdminNavigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 290);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.btnFinalizeSchedule);
            this.Controls.Add(this.btnManageSchedule);
            this.Controls.Add(this.btnManageClass);
            this.Controls.Add(this.btnManageTeacher);
            this.Controls.Add(this.btnManageStudent);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.txtAdminName);
            this.Controls.Add(this.label1);
            this.Name = "AdminNavigation";
            this.Text = "AdminNavigation";
            this.Load += new System.EventHandler(this.AdminNavigation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtAdminName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnManageStudent;
        private System.Windows.Forms.Button btnManageTeacher;
        private System.Windows.Forms.Button btnManageClass;
        private System.Windows.Forms.Button btnManageSchedule;
        private System.Windows.Forms.Button btnFinalizeSchedule;
        private System.Windows.Forms.Button btnViewReport;
    }
}