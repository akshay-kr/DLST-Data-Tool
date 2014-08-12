namespace Quest_DLST_Data_Tool
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.selectFileButton = new System.Windows.Forms.Button();
            this.fileName = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.importLogin = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // selectFileButton
            // 
            this.selectFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFileButton.Location = new System.Drawing.Point(144, 42);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(86, 28);
            this.selectFileButton.TabIndex = 0;
            this.selectFileButton.Text = "File";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // fileName
            // 
            this.fileName.Enabled = false;
            this.fileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileName.Location = new System.Drawing.Point(251, 46);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(497, 22);
            this.fileName.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // importLogin
            // 
            this.importLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importLogin.Location = new System.Drawing.Point(345, 102);
            this.importLogin.Name = "importLogin";
            this.importLogin.Size = new System.Drawing.Size(204, 39);
            this.importLogin.TabIndex = 2;
            this.importLogin.Text = "Import Track Record";
            this.importLogin.UseVisualStyleBackColor = true;
            this.importLogin.Click += new System.EventHandler(this.importLogin_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.Color.Black;
            this.txtConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.ForeColor = System.Drawing.Color.Lime;
            this.txtConsole.Location = new System.Drawing.Point(144, 168);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(604, 258);
            this.txtConsole.TabIndex = 5;
            this.txtConsole.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 438);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.importLogin);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.selectFileButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "DLST Data Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button importLogin;
        private System.Windows.Forms.RichTextBox txtConsole;

    }
}

