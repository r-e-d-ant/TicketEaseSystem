using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BCryptNet = BCrypt.Net.BCrypt;

namespace TicketEaseSystem
{
    public partial class Login : Form
    {
        public static string emailValue; // to hold logged in user email
        public static string usrIdValue; // to hold logged in user id

        public Login()
        {
            InitializeComponent();
        }

        // open signup form
        private void signupLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signupFrm = new Signup();
            signupFrm.Show();
            this.Hide();
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            /*
             * check if input boxes are not empty,
             * get the email then get its password from db using 'clientAuth' procedure,
             * compare an entered password with the one db then login if they match.
             */
            if (emailBox.Text != "" && passwordBox.Text != "")
            {
                using (SqlConnection con = new SqlConnection(appConnection.getConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("clientAuth", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        // add entered email value to the @email variable of the procedure
                        cmd.Parameters.AddWithValue("@email", emailBox.Text);
                        SqlDataReader sdr = cmd.ExecuteReader();

                        if (sdr.Read())
                        {
                            string email = sdr["client_email"].ToString();
                            Login.emailValue = email;
                            Login.usrIdValue = sdr["client_id"].ToString();
                            string pwd = sdr["password"].ToString();

                            // verify the password using bcrypt (tool used to crypt it)
                            bool checkPwd = BCryptNet.Verify(passwordBox.Text, pwd);

                            // go to home page if its correct password.
                            if (checkPwd)
                            {
                                Home homeFrm = new Home();
                                homeFrm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect email or password, Try again", "Error");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect email or password, Try again", "Error");
                        }
                    }
                }
            } else
            {
                MessageBox.Show("Please fill all the inputs", "Error");
            }
        }
    }
}
