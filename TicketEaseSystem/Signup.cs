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
using BCryptNet = BCrypt.Net.BCrypt; // password encryption algorithm

namespace TicketEaseSystem
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        /*
         * populate 'registerEvent' procedure variables with input from the signup form.
         * commit them to database
         * hash the password and save the crypted one
         */
        private void signupBtn_Click(object sender, EventArgs e)
        {
            using(SqlConnection con = new SqlConnection(appConnection.getConnectionString()))
            {
                using(SqlCommand cmd = new SqlCommand("registerEvent", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        // populating values to procedure variables
                        cmd.Parameters.AddWithValue("@fullname", fullnameBox.Text);
                        cmd.Parameters.AddWithValue("@email", emailBox.Text);
                        cmd.Parameters.AddWithValue("@phone", phoneBox.Text);
                        // hash the password
                        string hashPassword = BCryptNet.HashPassword(passwordBox.Text);
                        cmd.Parameters.AddWithValue("@password", hashPassword);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            MessageBox.Show("Successfully registered", "Confirmation");
                            Login lgnFrm = new Login();
                            lgnFrm.Show();
                            this.Hide();
                        } else
                        {
                            MessageBox.Show("Not registered, Try again", "Error");
                        }
                    } catch(Exception ex)
                    {
                        Console.WriteLine("{0} Exception caught", ex);
                    }
                }
            }
        }

        // go to login form
        private void loginLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login lgnFrm = new Login();
            lgnFrm.Show();
            this.Hide();
        }
    }
}
