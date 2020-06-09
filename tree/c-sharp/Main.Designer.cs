namespace tree
{
    partial class Main
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
            this.trvInputTree = new System.Windows.Forms.TreeView();
            this.btnHandle = new System.Windows.Forms.Button();
            this.lblInputTree = new System.Windows.Forms.Label();
            this.lblOutRecursive = new System.Windows.Forms.Label();
            this.lblOutIterative = new System.Windows.Forms.Label();
            this.txtOutRecursive = new System.Windows.Forms.TextBox();
            this.txtOutIterative = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // trvInputTree
            // 
            this.trvInputTree.Location = new System.Drawing.Point(12, 38);
            this.trvInputTree.Name = "trvInputTree";
            this.trvInputTree.Size = new System.Drawing.Size(303, 202);
            this.trvInputTree.TabIndex = 0;
            // 
            // btnHandle
            // 
            this.btnHandle.Location = new System.Drawing.Point(332, 52);
            this.btnHandle.Name = "btnHandle";
            this.btnHandle.Size = new System.Drawing.Size(258, 40);
            this.btnHandle.TabIndex = 1;
            this.btnHandle.Text = "Handle Tree";
            this.btnHandle.UseVisualStyleBackColor = true;
            this.btnHandle.Click += new System.EventHandler(this.btnHandle_Click);
            // 
            // lblInputTree
            // 
            this.lblInputTree.AutoSize = true;
            this.lblInputTree.Location = new System.Drawing.Point(13, 15);
            this.lblInputTree.Name = "lblInputTree";
            this.lblInputTree.Size = new System.Drawing.Size(77, 17);
            this.lblInputTree.TabIndex = 0;
            this.lblInputTree.Text = "Input Tree:";
            // 
            // lblOutRecursive
            // 
            this.lblOutRecursive.AutoSize = true;
            this.lblOutRecursive.Location = new System.Drawing.Point(332, 117);
            this.lblOutRecursive.Name = "lblOutRecursive";
            this.lblOutRecursive.Size = new System.Drawing.Size(127, 17);
            this.lblOutRecursive.TabIndex = 3;
            this.lblOutRecursive.Text = "Output (recursive):";
            // 
            // lblOutIterative
            // 
            this.lblOutIterative.AutoSize = true;
            this.lblOutIterative.Location = new System.Drawing.Point(332, 181);
            this.lblOutIterative.Name = "lblOutIterative";
            this.lblOutIterative.Size = new System.Drawing.Size(119, 17);
            this.lblOutIterative.TabIndex = 4;
            this.lblOutIterative.Text = "Output (iterative):";
            // 
            // txtOutRecursive
            // 
            this.txtOutRecursive.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutRecursive.Location = new System.Drawing.Point(332, 137);
            this.txtOutRecursive.Name = "txtOutRecursive";
            this.txtOutRecursive.ReadOnly = true;
            this.txtOutRecursive.Size = new System.Drawing.Size(258, 22);
            this.txtOutRecursive.TabIndex = 5;
            // 
            // txtOutIterative
            // 
            this.txtOutIterative.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutIterative.Location = new System.Drawing.Point(332, 201);
            this.txtOutIterative.Name = "txtOutIterative";
            this.txtOutIterative.ReadOnly = true;
            this.txtOutIterative.Size = new System.Drawing.Size(258, 22);
            this.txtOutIterative.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 250);
            this.Controls.Add(this.txtOutIterative);
            this.Controls.Add(this.txtOutRecursive);
            this.Controls.Add(this.lblOutIterative);
            this.Controls.Add(this.lblOutRecursive);
            this.Controls.Add(this.lblInputTree);
            this.Controls.Add(this.btnHandle);
            this.Controls.Add(this.trvInputTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tree Inorder Traversal";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvInputTree;
        private System.Windows.Forms.Button btnHandle;
        private System.Windows.Forms.Label lblInputTree;
        private System.Windows.Forms.Label lblOutRecursive;
        private System.Windows.Forms.Label lblOutIterative;
        private System.Windows.Forms.TextBox txtOutRecursive;
        private System.Windows.Forms.TextBox txtOutIterative;
    }
}

