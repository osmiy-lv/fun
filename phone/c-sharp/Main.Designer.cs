namespace Phone
{
    partial class frmMain
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
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.lblPhoneMsg = new System.Windows.Forms.Label();
            this.lblOutputMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Location = new System.Drawing.Point(12, 28);
            this.txtPhone.MaxLength = 9;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(338, 22);
            this.txtPhone.TabIndex = 0;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(12, 8);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(107, 17);
            this.lblPhone.TabIndex = 1;
            this.lblPhone.Text = "Phone Number:";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(12, 82);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(150, 17);
            this.lblOutput.TabIndex = 2;
            this.lblOutput.Text = "String Representation:";
            // 
            // lstOutput
            // 
            this.lstOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstOutput.FormattingEnabled = true;
            this.lstOutput.ItemHeight = 16;
            this.lstOutput.Location = new System.Drawing.Point(12, 102);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.Size = new System.Drawing.Size(338, 308);
            this.lstOutput.TabIndex = 2;
            // 
            // lblPhoneMsg
            // 
            this.lblPhoneMsg.AutoSize = true;
            this.lblPhoneMsg.Location = new System.Drawing.Point(12, 57);
            this.lblPhoneMsg.Name = "lblPhoneMsg";
            this.lblPhoneMsg.Size = new System.Drawing.Size(110, 17);
            this.lblPhoneMsg.TabIndex = 3;
            this.lblPhoneMsg.Text = "Phone Message";
            // 
            // lblOutputMsg
            // 
            this.lblOutputMsg.AutoSize = true;
            this.lblOutputMsg.Location = new System.Drawing.Point(160, 82);
            this.lblOutputMsg.Name = "lblOutputMsg";
            this.lblOutputMsg.Size = new System.Drawing.Size(112, 17);
            this.lblOutputMsg.TabIndex = 2;
            this.lblOutputMsg.Text = "Output Message";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 428);
            this.Controls.Add(this.lblPhoneMsg);
            this.Controls.Add(this.lstOutput);
            this.Controls.Add(this.lblOutputMsg);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "Phone to String translator";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.ListBox lstOutput;
        private System.Windows.Forms.Label lblPhoneMsg;
        private System.Windows.Forms.Label lblOutputMsg;
    }
}

