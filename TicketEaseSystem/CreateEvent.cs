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
    public partial class CreateEvent : Form
    {
        public CreateEvent()
        {
            InitializeComponent();
        }

        /*
         * function to
         * get data with 'clientEvents' procedure and display them into dataGridView1
         * we only get data for the logged in user
         */
        public void viewData()
        {
            using (SqlConnection con = new SqlConnection(appConnection.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("clientEvents", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@current_user_email", Login.emailValue);
                    DataTable dtEvent = new DataTable();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    dtEvent.Load(sdr);
                    dataGridView1.DataSource = dtEvent;

                }
            }
        }

        // show data on form load
        private void CreateEvent_Load(object sender, EventArgs e)
        {
            viewData();
        }

        /*
         * populate 'createEvent' procedure variables with input from the createEvent form.
         * commit them to database
         */
        private void createBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(appConnection.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("createEvent", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.AddWithValue("@e_name", eventNameBox.Text);
                        cmd.Parameters.AddWithValue("@e_date", dateTimePickerBox.Value);
                        cmd.Parameters.AddWithValue("@e_loc", locationBox.Text);
                        cmd.Parameters.AddWithValue("@e_perfomers", performersBox.Text);
                        cmd.Parameters.AddWithValue("@e_client_id", Login.usrIdValue);
                        cmd.Parameters.AddWithValue("@e_promo_code", promoCodeBox.Text);
                        cmd.Parameters.AddWithValue("@reg_ticket", regBox.Text);
                        cmd.Parameters.AddWithValue("@vip_ticket", vipBox.Text);
                        cmd.Parameters.AddWithValue("@vvip_ticket", vvipBox.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            MessageBox.Show("Event created successfully", "Confirmation");
                            viewData();
                        }
                        else
                        {
                            MessageBox.Show("Event not created", "Error");
                        }
                    } catch(Exception ex)
                    {
                        Console.WriteLine("{0} Exception caught", ex);
                    }
                }
            }
        }

        // variable to hold a selected event id.
        string eventId;

        // loop over loaded data and get the id of the clicked event for further actions like update or delete
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    eventId = row.Cells[0].Value.ToString();
                    eventNameBox.Text = row.Cells[2].Value.ToString();
                    locationBox.Text = row.Cells[4].Value.ToString();
                    dateTimePickerBox.Text = row.Cells[3].Value.ToString();
                    performersBox.Text = row.Cells[5].Value.ToString();
                    regBox.Text = row.Cells[7].Value.ToString();
                    vipBox.Text = row.Cells[8].Value.ToString();
                    vvipBox.Text = row.Cells[9].Value.ToString();
                    promoCodeBox.Text = row.Cells[6].Value.ToString();
                }
            }
        }

        // updating the event with given id
        private void updateBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(appConnection.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("updateEvent", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.AddWithValue("@e_del_id", eventId);
                        cmd.Parameters.AddWithValue("@e_c_id", Login.usrIdValue);
                        cmd.Parameters.AddWithValue("@e_name", eventNameBox.Text);
                        cmd.Parameters.AddWithValue("@e_date", dateTimePickerBox.Value);
                        cmd.Parameters.AddWithValue("@e_loc", locationBox.Text);
                        cmd.Parameters.AddWithValue("@e_perfomers", performersBox.Text);
                        cmd.Parameters.AddWithValue("@e_promo_code", promoCodeBox.Text);
                        cmd.Parameters.AddWithValue("@reg_ticket", regBox.Text);
                        cmd.Parameters.AddWithValue("@vip_ticket", vipBox.Text);
                        cmd.Parameters.AddWithValue("@vvip_ticket", vvipBox.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            MessageBox.Show("Event updated successfully", "Confirmation");
                            viewData();
                        }
                        else
                        {
                            MessageBox.Show("Event not updated", "Error");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("{0} Exception caught", ex);
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

        // deleting the event with given id
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(appConnection.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("deleteEvent", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.AddWithValue("@e_id", eventId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            MessageBox.Show("Event deleted successfully", "Confirmation");
                            viewData();
                        }
                        else
                        {
                            MessageBox.Show("Event not deleted", "Error");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("{0} Exception caught", ex);
                    }
                }
            }
        }
    }
}
