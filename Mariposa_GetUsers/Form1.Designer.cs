namespace SendWelcomeEmail
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtSubURL = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbNotSignedIn = new System.Windows.Forms.RadioButton();
            this.rbExpiredWelcome = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSandbox = new System.Windows.Forms.RadioButton();
            this.rbProduction = new System.Windows.Forms.RadioButton();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbFileOutput = new System.Windows.Forms.RadioButton();
            this.rbEmail = new System.Windows.Forms.RadioButton();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbManagers = new System.Windows.Forms.RadioButton();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(900, 32);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(160, 52);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Get Users";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtSubURL
            // 
            this.txtSubURL.Location = new System.Drawing.Point(188, 32);
            this.txtSubURL.Name = "txtSubURL";
            this.txtSubURL.Size = new System.Drawing.Size(676, 26);
            this.txtSubURL.TabIndex = 1;
            this.txtSubURL.TextChanged += new System.EventHandler(this.txtSubURL_TextChanged);
            this.txtSubURL.Leave += new System.EventHandler(this.txtSubURL_Leave);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(188, 74);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(676, 26);
            this.txtCustomerName.TabIndex = 2;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Customer Name:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Complete Bridge URL:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(188, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(676, 276);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(900, 322);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(118, 24);
            this.rbAll.TabIndex = 20;
            this.rbAll.Text = "All Learners";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // rbNotSignedIn
            // 
            this.rbNotSignedIn.AutoSize = true;
            this.rbNotSignedIn.Checked = true;
            this.rbNotSignedIn.Location = new System.Drawing.Point(900, 352);
            this.rbNotSignedIn.Name = "rbNotSignedIn";
            this.rbNotSignedIn.Size = new System.Drawing.Size(142, 24);
            this.rbNotSignedIn.TabIndex = 21;
            this.rbNotSignedIn.TabStop = true;
            this.rbNotSignedIn.Text = "Never signed in";
            this.rbNotSignedIn.UseVisualStyleBackColor = true;
            // 
            // rbExpiredWelcome
            // 
            this.rbExpiredWelcome.AutoSize = true;
            this.rbExpiredWelcome.Location = new System.Drawing.Point(900, 382);
            this.rbExpiredWelcome.Name = "rbExpiredWelcome";
            this.rbExpiredWelcome.Size = new System.Drawing.Size(157, 24);
            this.rbExpiredWelcome.TabIndex = 22;
            this.rbExpiredWelcome.Text = "Expired Welcome";
            this.rbExpiredWelcome.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSandbox);
            this.groupBox1.Controls.Add(this.rbProduction);
            this.groupBox1.Location = new System.Drawing.Point(902, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Environment";
            // 
            // rbSandbox
            // 
            this.rbSandbox.AutoSize = true;
            this.rbSandbox.Location = new System.Drawing.Point(33, 63);
            this.rbSandbox.Name = "rbSandbox";
            this.rbSandbox.Size = new System.Drawing.Size(97, 24);
            this.rbSandbox.TabIndex = 1;
            this.rbSandbox.TabStop = true;
            this.rbSandbox.Text = "Sandbox";
            this.rbSandbox.UseVisualStyleBackColor = true;
            // 
            // rbProduction
            // 
            this.rbProduction.AutoSize = true;
            this.rbProduction.Checked = true;
            this.rbProduction.Location = new System.Drawing.Point(33, 32);
            this.rbProduction.Name = "rbProduction";
            this.rbProduction.Size = new System.Drawing.Size(110, 24);
            this.rbProduction.TabIndex = 0;
            this.rbProduction.TabStop = true;
            this.rbProduction.Text = "Production";
            this.rbProduction.UseVisualStyleBackColor = true;
            // 
            // rbFile
            // 
            this.rbFile.AutoSize = true;
            this.rbFile.Location = new System.Drawing.Point(902, 412);
            this.rbFile.Name = "rbFile";
            this.rbFile.Size = new System.Drawing.Size(59, 24);
            this.rbFile.TabIndex = 24;
            this.rbFile.TabStop = true;
            this.rbFile.Text = "File";
            this.rbFile.UseVisualStyleBackColor = true;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(190, 455);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(672, 26);
            this.txtFile.TabIndex = 25;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(22, 449);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(158, 42);
            this.btnBrowse.TabIndex = 26;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbFileOutput);
            this.groupBox2.Controls.Add(this.rbEmail);
            this.groupBox2.Location = new System.Drawing.Point(892, 455);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // rbFileOutput
            // 
            this.rbFileOutput.AutoSize = true;
            this.rbFileOutput.Location = new System.Drawing.Point(33, 63);
            this.rbFileOutput.Name = "rbFileOutput";
            this.rbFileOutput.Size = new System.Drawing.Size(59, 24);
            this.rbFileOutput.TabIndex = 1;
            this.rbFileOutput.TabStop = true;
            this.rbFileOutput.Text = "File";
            this.rbFileOutput.UseVisualStyleBackColor = true;
            // 
            // rbEmail
            // 
            this.rbEmail.AutoSize = true;
            this.rbEmail.Checked = true;
            this.rbEmail.Location = new System.Drawing.Point(33, 32);
            this.rbEmail.Name = "rbEmail";
            this.rbEmail.Size = new System.Drawing.Size(73, 24);
            this.rbEmail.TabIndex = 0;
            this.rbEmail.TabStop = true;
            this.rbEmail.Text = "Email";
            this.rbEmail.UseVisualStyleBackColor = true;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(902, 92);
            this.btnResetPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(159, 49);
            this.btnResetPassword.TabIndex = 27;
            this.btnResetPassword.Text = "Create User";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(190, 514);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(670, 26);
            this.txtEmail.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 522);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Email:";
            // 
            // rbManagers
            // 
            this.rbManagers.AutoSize = true;
            this.rbManagers.Location = new System.Drawing.Point(898, 292);
            this.rbManagers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbManagers.Name = "rbManagers";
            this.rbManagers.Size = new System.Drawing.Size(105, 24);
            this.rbManagers.TabIndex = 30;
            this.rbManagers.TabStop = true;
            this.rbManagers.Text = "Managers";
            this.rbManagers.UseVisualStyleBackColor = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(190, 412);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(673, 26);
            this.txtUserName.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "User Name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 606);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.rbManagers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.rbFile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rbExpiredWelcome);
            this.Controls.Add(this.rbNotSignedIn);
            this.Controls.Add(this.rbAll);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtSubURL);
            this.Controls.Add(this.btnConnect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Get Users";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtSubURL;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbNotSignedIn;
        private System.Windows.Forms.RadioButton rbExpiredWelcome;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSandbox;
        private System.Windows.Forms.RadioButton rbProduction;
        private System.Windows.Forms.RadioButton rbFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbFileOutput;
        private System.Windows.Forms.RadioButton rbEmail;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbManagers;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label4;
    }
}

