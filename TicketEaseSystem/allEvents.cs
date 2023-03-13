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
    public partial class allEvents : Form
    {
        // variables to hold selected event infos
        public static string selectedEventId = null;
        public static string selectedEventName = null;
        public static string selectedEventLocation = null;
        public allEvents()
        {
            InitializeComponent();
        }

        // function to query all the available events created by users.
        public void viewData()
        {
            using (SqlConnection con = new SqlConnection(appConnection.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("viewEvent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    DataTable dtEvent = new DataTable();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    dtEvent.Load(sdr);
                    eventsDataGridView.DataSource = dtEvent;

                }
            }
        }

        // show data on form load
        private void allEvents_Load(object sender, EventArgs e)
        {
            viewData();
        }

        // clicked event and take you to event book informations
        private void bookBtn_Click(object sender, EventArgs e)
        {
            if (allEvents.selectedEventId != null)
            {
                BookEvent bEventForm = new BookEvent();
                bEventForm.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Please select an event to book");
            }
        }

        // loop over loaded data and get the id of the clicked event for further event booking actions
        private void eventsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (eventsDataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in eventsDataGridView.SelectedRows)
                {
                    allEvents.selectedEventId = row.Cells[0].Value.ToString();
                    searchBox.Text = row.Cells[2].Value.ToString();
                    allEvents.selectedEventName = row.Cells[2].Value.ToString();
                    selectedEventBox.Text = row.Cells[2].Value.ToString();
                    allEvents.selectedEventLocation = row.Cells[4].Value.ToString();
                }
            }
        }


        // menu clicks (home, logout and exit for quuiting the app)
        private void eventsToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
