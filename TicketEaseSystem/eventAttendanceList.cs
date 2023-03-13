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
    public partial class eventAttendanceList : Form
    {
        public eventAttendanceList()
        {
            InitializeComponent();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home hmfrm = new Home();
            hmfrm.Show();
            this.Hide();
        }

        // function to show revenue and event attendees numbers
        public void viewAtt(string eventId)
        {
            using (SqlConnection con = new SqlConnection(appConnection.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("showRevAndAtt", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@e_id", eventId);
                    DataTable dtEvent = new DataTable();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        revNoLbl.Text = sdr["Revenue"].ToString();
                        attNoLbl.Text = sdr["Attendees"].ToString();
                    } else
                    {
                        revNoLbl.Text = "0";
                        attNoLbl.Text = "0";
                    }

                }
            }
        }

        // function to get infos of user registered events
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
                    dataGridView2.DataSource = dtEvent;

                }
            }
        }

        private void eventAttendanceList_Load(object sender, EventArgs e)
        {
            viewData();
        }

        // get list of registered attendees
        public void viewEventAttendees(string e_id)
        {
            using (SqlConnection con = new SqlConnection(appConnection.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("viewAttendees", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@e_id", e_id);
                    DataTable dtEvent = new DataTable();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    dtEvent.Load(sdr);
                    dataGridView1.DataSource = dtEvent;
                }
            }
        }

        /*
         * get id of the event then show their attendees infos, revenue and amount of attendees
         */
        string eventId;
        private void viewEventAttend_Cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    eventId = row.Cells[0].Value.ToString();
                    viewEventAttendees(eventId);
                    viewAtt(eventId);
                }
            }
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
    }
}
