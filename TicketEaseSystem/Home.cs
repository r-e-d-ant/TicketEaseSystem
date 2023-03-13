using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketEaseSystem
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        // goto see all events form
        private void seeAllEventsBtn_Click(object sender, EventArgs e)
        {
            allEvents allEvFrm = new allEvents();
            allEvFrm.Show();
            this.Hide();
        }

        // goto create events form
        private void createEventBtn_Click(object sender, EventArgs e)
        {
            CreateEvent createEvFrm = new CreateEvent();
            createEvFrm.Show();
            this.Hide();
        }

        // goto see attendance list form
        private void seeAttendanceBtn_Click(object sender, EventArgs e)
        {
            eventAttendanceList evAttFrm = new eventAttendanceList();
            evAttFrm.Show();
            this.Hide();
        }

        // logout and goto login page

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lgnFrm = new Login();
            lgnFrm.Show();
            this.Hide();
        }

        // quit entire app

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
