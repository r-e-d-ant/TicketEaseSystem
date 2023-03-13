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

namespace TicketEaseSystem
{
    public partial class BookEvent : Form
    {
        public BookEvent()
        {
            InitializeComponent();
        }

        /*
         * populate 'registerAttendace' procedure variables with input from the bookEvent form.
         * commit them to the database
         */
        private void checkoutBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(appConnection.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("registerAttendace", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.AddWithValue("@c_event_id", allEvents.selectedEventId);
                        cmd.Parameters.AddWithValue("@c_client_id", Login.usrIdValue);
                        cmd.Parameters.AddWithValue("@c_fullname", fullNameBox.Text);
                        cmd.Parameters.AddWithValue("@c_email", emailBox.Text);
                        cmd.Parameters.AddWithValue("@c_phone", phoneBox.Text);
                        cmd.Parameters.AddWithValue("@c_ticket", ticketType.SelectedItem);
                        cmd.Parameters.AddWithValue("@price", priceBox.Text);
                        cmd.Parameters.AddWithValue("@c_payment_det", payDetsBox.Text);
                        cmd.Parameters.AddWithValue("@c_res_seats", accSeatsBox.Text);
                        cmd.Parameters.AddWithValue("@parking_slots", parkingSlotsBox.Text);
                        cmd.Parameters.AddWithValue("@promo_code", promoCodeBox.Text);
                        cmd.Parameters.AddWithValue("@nr_of_tick", nrTicketsBox.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            MessageBox.Show("Successfully registered", "Confirmation");
                            allEvents allEve = new allEvents();
                            allEve.Show();
                            this.Hide();
                        }
                        else
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

        // populate event name input box infor from allEvents form
        private void BookEvent_Load(object sender, EventArgs e)
        {
            eventNameTxt.Text = allEvents.selectedEventName;
            locationTxt.Text = allEvents.selectedEventLocation;
        }

        // show price for each selected ticket type
        private void show_price(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(appConnection.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("showTicketPrice", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@e_id", allEvents.selectedEventId);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();

                    switch (ticketType.SelectedItem)
                    {
                        case "regular":
                            int regPrice = Int32.Parse(sdr["regular"].ToString());
                            int selectedTicketReg = Int32.Parse(nrTicketsBox.Text);
                            priceBox.Text = (selectedTicketReg * regPrice).ToString();
                            break;
                        case "vip":
                            int vipPrice = Int32.Parse(sdr["vip"].ToString());
                            int selectedTicketVip = Int32.Parse(nrTicketsBox.Text);
                            priceBox.Text = (selectedTicketVip * vipPrice).ToString();
                            break;
                        case "vvip":
                            int vvipPrice = Int32.Parse(sdr["vvip"].ToString());
                            int selectedTicketVvip = Int32.Parse(nrTicketsBox.Text);
                            priceBox.Text = (selectedTicketVvip * vvipPrice).ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home hmfrm = new Home();
            hmfrm.Show();
            this.Hide();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lgnFrm = new Login();
            lgnFrm.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ticketType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
