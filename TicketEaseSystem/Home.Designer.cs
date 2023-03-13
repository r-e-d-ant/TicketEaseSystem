
namespace TicketEaseSystem
{
    partial class Home
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
            this.seeAllEventsBtn = new System.Windows.Forms.Button();
            this.createEventBtn = new System.Windows.Forms.Button();
            this.seeAttendanceBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // seeAllEventsBtn
            // 
            this.seeAllEventsBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.seeAllEventsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seeAllEventsBtn.Font = new System.Drawing.Font("MS PGothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seeAllEventsBtn.ForeColor = System.Drawing.Color.Ivory;
            this.seeAllEventsBtn.Location = new System.Drawing.Point(38, 126);
            this.seeAllEventsBtn.Name = "seeAllEventsBtn";
            this.seeAllEventsBtn.Size = new System.Drawing.Size(349, 43);
            this.seeAllEventsBtn.TabIndex = 14;
            this.seeAllEventsBtn.Text = "See All Events";
            this.seeAllEventsBtn.UseVisualStyleBackColor = false;
            this.seeAllEventsBtn.Click += new System.EventHandler(this.seeAllEventsBtn_Click);
            // 
            // createEventBtn
            // 
            this.createEventBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.createEventBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createEventBtn.Font = new System.Drawing.Font("MS PGothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createEventBtn.ForeColor = System.Drawing.Color.Ivory;
            this.createEventBtn.Location = new System.Drawing.Point(38, 217);
            this.createEventBtn.Name = "createEventBtn";
            this.createEventBtn.Size = new System.Drawing.Size(349, 43);
            this.createEventBtn.TabIndex = 15;
            this.createEventBtn.Text = "Create An Event";
            this.createEventBtn.UseVisualStyleBackColor = false;
            this.createEventBtn.Click += new System.EventHandler(this.createEventBtn_Click);
            // 
            // seeAttendanceBtn
            // 
            this.seeAttendanceBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.seeAttendanceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seeAttendanceBtn.Font = new System.Drawing.Font("MS PGothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seeAttendanceBtn.ForeColor = System.Drawing.Color.Ivory;
            this.seeAttendanceBtn.Location = new System.Drawing.Point(38, 302);
            this.seeAttendanceBtn.Name = "seeAttendanceBtn";
            this.seeAttendanceBtn.Size = new System.Drawing.Size(349, 43);
            this.seeAttendanceBtn.TabIndex = 16;
            this.seeAttendanceBtn.Text = "Attendance of my Events";
            this.seeAttendanceBtn.UseVisualStyleBackColor = false;
            this.seeAttendanceBtn.Click += new System.EventHandler(this.seeAttendanceBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ink Free", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(123, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 36);
            this.label3.TabIndex = 17;
            this.label3.Text = "TicketEase";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(419, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(419, 378);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.seeAttendanceBtn);
            this.Controls.Add(this.createEventBtn);
            this.Controls.Add(this.seeAllEventsBtn);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button seeAllEventsBtn;
        private System.Windows.Forms.Button createEventBtn;
        private System.Windows.Forms.Button seeAttendanceBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}