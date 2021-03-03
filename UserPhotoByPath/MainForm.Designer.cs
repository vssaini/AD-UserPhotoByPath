using System.ComponentModel;
using System.Windows.Forms;

namespace UserPhotoByPath
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLdapPath = new System.Windows.Forms.TextBox();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnRetrieveDetail = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgwPhoto = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "LDAP Path:";
            // 
            // txtLdapPath
            // 
            this.txtLdapPath.Location = new System.Drawing.Point(94, 9);
            this.txtLdapPath.Name = "txtLdapPath";
            this.txtLdapPath.Size = new System.Drawing.Size(384, 23);
            this.txtLdapPath.TabIndex = 1;
            // 
            // picUser
            // 
            this.picUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picUser.Location = new System.Drawing.Point(12, 64);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(295, 241);
            this.picUser.TabIndex = 2;
            this.picUser.TabStop = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(12, 46);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(63, 15);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "User Photo";
            // 
            // btnRetrieveDetail
            // 
            this.btnRetrieveDetail.Location = new System.Drawing.Point(403, 38);
            this.btnRetrieveDetail.Name = "btnRetrieveDetail";
            this.btnRetrieveDetail.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieveDetail.TabIndex = 4;
            this.btnRetrieveDetail.Text = "Retrieve...";
            this.btnRetrieveDetail.UseVisualStyleBackColor = true;
            this.btnRetrieveDetail.Click += new System.EventHandler(this.btnRetrieveDetail_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 321);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(488, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(26, 17);
            this.lblStatus.Text = "Idle";
            // 
            // bgwPhoto
            // 
            this.bgwPhoto.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwPhoto_DoWork);
            this.bgwPhoto.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwPhoto_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 343);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnRetrieveDetail);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.picUser);
            this.Controls.Add(this.txtLdapPath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AD User Photo - By path";
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtLdapPath;
        private PictureBox picUser;
        private Label lblUser;
        private Button btnRetrieveDetail;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private BackgroundWorker bgwPhoto;
    }
}

