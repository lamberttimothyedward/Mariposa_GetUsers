using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileHelpers;
using NLog;

namespace SendWelcomeEmail
{
    public partial class Form1 : Form
    {
        private static Logger logger;
        public int domainId = 0;
        UsersRootobject uro = new UsersRootobject();
        
        //User accountUsers[] = new User();
        public Form1()
        {
            if (logger == null) logger = LogManager.GetCurrentClassLogger();

            InitializeComponent();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (logger == null) logger = LogManager.GetCurrentClassLogger();
            if (this.txtSubURL.Text != "https://")
            {
                ApiHelper.IninitializeClient(rbProduction.Checked);
                await getDomainID(this.txtSubURL.Text);
                this.txtSubURL.ReadOnly = true;
                btnConnect.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please enter a valid Bridge URL");
                this.ActiveControl = txtSubURL;
            }
        }
        private async Task resetPassword(string subdomain = "")
        {
            SendWelcomeEmail.User usr = new SendWelcomeEmail.User();

            usr = await Processor.getUser(this.txtSubURL.Text, txtEmail.Text);
            if(!string.IsNullOrEmpty(usr.id.ToString()))
            {
                await sendWelcomeEmail(Convert.ToInt32(usr.id), this.txtSubURL.Text, true);

                MessageBox.Show("Password has been reset");
            }
            else
            {
                MessageBox.Show("Password has not been reset. Unable to find this user.");
            }

        }
        private async Task getDomainID(string subdomain = "")
        {
            Sub_Accounts sa = new Sub_Accounts();


            sa = await Processor.connectToDomain(subdomain);
            if (sa != null && sa.id != "1")
            {
                domainId = Convert.ToInt32(sa.id);
                this.txtCustomerName.Text = sa.name.ToString();
                await getUsers();

            }
            else
            {
                MessageBox.Show("Could Not connect to this URL. Please check your URL and try again");
                this.txtSubURL.Text = "https://";
                this.ActiveControl = txtSubURL;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (logger == null) logger = LogManager.GetCurrentClassLogger();
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            this.txtSubURL.Text = "https://mariposa-acc.bridgeapp.com";
            //this.txtExpiryDate.Text = "YYYY-MM-DD";
            //this.txtSubURL.Text = "https://";
            this.ActiveControl = txtSubURL;
        }

        private void txtSubURL_Leave(object sender, EventArgs e)
        {
            //if (txtSubURL.Text == "https://")
            //{
            //    if(rbProduction.Checked == true)
            //    {
            //        txtSubURL.Text = txtSubURL.Text + "-acc.bridgeapp.com";
            //    }
            //    else
            //    {
            //        txtSubURL.Text = txtSubURL.Text + "-accsandbox.bridgeapp.com";
            //    }
                
            //    this.btnConnect.Focus();
            //}
        }

        private async Task sendWelcomeEmail(int userid, string domainurl, bool passwordReset)
        {
            Boolean bsuccess = true;
            bsuccess = await Processor.sendWelcomeEmail(userid, domainurl, passwordReset);
        }
        private async Task getUsers()
        {

            var outputFileEngine = new FileHelperEngine<UsersOutput>();
            var orders = new List<UsersOutput>();
            
            orders.Add(new UsersOutput()
            {
                user_id = "user_id",
                email = "email",
                first_name = "first_name",
                last_name = "last_name",
                passwordIsSet = "password_Is_Set",
                dayswelcomed = "days_welcomed"
            });

            if (rbFile.Checked == true)
            {
                var engine = new FileHelperEngine<FileUsers>();
                var records = engine.ReadFile(txtFile.Text);


                foreach (var record in records)
                {
                    if (record.user_id == "user_id")
                    {
                        //skip
                    }
                    else
                    {
                        //await sendWelcomeEmail(Convert.ToInt32(record.user_id), this.txtSubURL.Text, false);
                    }
                }

                //MessageBox.Show("Welcome Emails send to: " + records.Length.ToString() + " users");
            }
            else
            {
                uro.users = await Processor.getUsers(this.txtSubURL.Text, rbManagers.Checked);
                this.dataGridView1.DataSource = uro.users;
                foreach (User usr in uro.users)
                {
                    
                    if (rbAll.Checked || rbManagers.Checked)
                    {
                        if (rbEmail.Checked)
                        {
                            //await sendWelcomeEmail(Convert.ToInt32(usr.id), this.txtSubURL.Text, false);
                        }
                        else
                        {
                            orders.Add(new UsersOutput()
                            {
                                user_id = usr.id,
                                email = usr.email,
                                first_name = usr.first_name,
                                last_name = usr.last_name,
                                passwordIsSet = usr.passwordIsSet.ToString()
                            });
                        }
                    }

                    if (rbNotSignedIn.Checked)
                    {
                        if (string.IsNullOrEmpty(usr.loggedInAt.ToString()))
                        {
                            if (rbEmail.Checked)
                            {
                                //await sendWelcomeEmail(Convert.ToInt32(usr.id), this.txtSubURL.Text, false);
                            }
                            else
                            {
                                orders.Add(new UsersOutput()
                                {
                                    user_id = usr.id,
                                    email = usr.email,
                                    first_name = usr.first_name,
                                    last_name = usr.last_name,
                                    passwordIsSet = usr.passwordIsSet.ToString()
                                });
                            }
                        }
                    }

                    if (rbExpiredWelcome.Checked)
                    {
                        if (!string.IsNullOrEmpty(usr.welcomedAt.ToString()))
                        {
                            DateTime dtWelcome = Convert.ToDateTime(usr.welcomedAt.ToString());
                            DateTime dtNow = DateTime.Now;
                            TimeSpan diff = dtNow - dtWelcome;
                            double days = diff.TotalDays;
                            if ((usr.passwordIsSet == false) && (usr.loggedInAt.ToString() == "") )
                            {
                                if(rbEmail.Checked)
                                {
                                    //await sendWelcomeEmail(Convert.ToInt32(usr.id), this.txtSubURL.Text, false);
                                }
                                else
                                {
                                    orders.Add(new UsersOutput()
                                    {
                                        user_id = usr.id,
                                        email = usr.email,
                                        first_name = usr.first_name,
                                        last_name = usr.last_name,
                                        passwordIsSet = usr.passwordIsSet.ToString(),
                                        dayswelcomed = days.ToString()
                                    });
                                }
                                

                            }
                        }
                    }
                }
                if (uro.users.Length > 0)
                {
                    //MessageBox.Show("Welcome Emails send to: " + uro.users.Length.ToString() + " users");
                }

                if(orders.Count > 1)
                    if (orders.Count > 1)
                        if (orders.Count > 1)
                {
                    outputFileEngine.WriteFile("c:\\temp\\Output1.csv", orders);
                }
                
            }



        }

        private void btnSendWelcome_Click(object sender, EventArgs e)
        {

        }

        private void txtSubURL_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                RestoreDirectory = true,
                Title = "Browse CSV File to Share Courses",
                DefaultExt = "csv"
            };

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                txtFile.Text = openFileDialog1.FileName;
                btnConnect.Focus();
            }
            Console.WriteLine(result); // <-- For debugging use.
        }

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (logger == null) logger = LogManager.GetCurrentClassLogger();
            if (!string.IsNullOrEmpty(this.txtUserName.Text))
            {
                ApiHelper.IninitializeClient(rbProduction.Checked);

                SendWelcomeEmail.User usr = new SendWelcomeEmail.User();

                //create the user
                usr = await Processor.createUser(txtSubURL.Text, txtUserName.Text);

                //Next, update the user
                usr.first_name = "Donald";
                usr.last_name = "duck";

                bool success = await Processor.updateUser(txtSubURL.Text, usr);

                this.txtSubURL.ReadOnly = true;
                btnConnect.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please enter a user name");
                this.ActiveControl = txtUserName;
            }
        }
    }
}
