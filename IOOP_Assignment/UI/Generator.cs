using Microsoft.Reporting.WinForms;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    public partial class Generator : Form
    {

        public Generator()
        {
            InitializeComponent();
        }
        Controller ctrl = new Controller();

        private void Generator_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsClubs.Clubs' table. You can move, or remove it, as needed.
            this.ClubsTableAdapter.Fill(this.dsClubs.Clubs);

            reportViewerActi.Visible = false;
            reportViewerClubs.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            dtpFrom.Value = DateTime.Now.AddDays(-7);
            dtpTo.Value = DateTime.Now;
            dtpFrom.Visible = false;
            dtpTo.Visible = false;
            this.reportViewerActi.RefreshReport();
            this.reportViewerClubs.RefreshReport();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (radActivities.Checked)
            {
                this.ActivityTableAdapter.Fill(this.dsClubs.Activity, DateTime.Parse(dtpFrom.Text), DateTime.Parse(dtpTo.Text));
                this.reportViewerActi.RefreshReport();
                reportViewerClubs.Visible = false;
                reportViewerActi.Visible = true;
            }
            else
            {
                reportViewerActi.Visible = false;
                reportViewerClubs.Visible = true;
            }
        }

        private void radActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (radActivities.Checked)
            {
                label1.Visible = true;
                label2.Visible = true;
                dtpFrom.Visible = true;
                dtpTo.Visible = true;
            }
        }
        private void radClubs_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            dtpFrom.Visible = false;
            dtpTo.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
