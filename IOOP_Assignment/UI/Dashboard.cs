using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        string user;
        internal void Access(string id)
        {
            user = id;
            switch (id)
            {
                case ("admin"):
                    lblUser.Text = "Welcome Back, admin";
                    break;
                case ("student"):
                    lblUser.Text = "Welcome Back, Student";
                    panelGenerator.Visible = false;
                    panelReg.Visible = false;
                    panelStatus.Visible = false;
                    panelUpdate.Visible = false;
                    break;
                default:
                    lblUser.Text = "Welcome Back, "+ id ;
                    btnPosition.Visible = false;
                    panelSubMenu.Size = new Size(275, 70);
                    panelReg.Visible = false;
                    panelStatus.Visible = false;
                    panelGenerator.Visible = false;
                    break;
            }
        }
        
        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
            panelSubMenu.Visible = false;
        }

        Form activeForm;
        private void MultiForms(Form openForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = openForm;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.TopLevel = false;
            activeForm.Dock = DockStyle.Fill;
            panelForm.Controls.Add(activeForm);
            activeForm.BringToFront();
            activeForm.Show();
        }

        private void ClearMarker()
        {
            btnDescription.BackColor = Color.FromArgb(24, 24, 25);
            btnGenerator.BackColor = Color.FromArgb(25, 25, 25);
            btnPosition.BackColor = Color.FromArgb(25, 25, 25);
            btnReg.BackColor = Color.FromArgb(25, 25, 25);
            btnReport.BackColor = Color.FromArgb(25, 25, 25);
            btnSearch.BackColor = Color.FromArgb(25, 25, 25);
            btnStatus.BackColor = Color.FromArgb(25, 25, 25);
            btnLogout.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ClearMarker();
            if (panelSubMenu.Visible == false)
            {
                panelSubMenu.Visible = true;
            }
            else
            {
                panelSubMenu.Visible = false;
            }
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            ClearMarker();
            btnPosition.BackColor = Color.FromArgb(93, 40, 158);
            MultiForms(new CommiteeDetail());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ClearMarker();
            btnReport.BackColor = Color.FromArgb(93, 40, 158);
            MultiForms(new Report(user));
        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            ClearMarker();
            btnDescription.BackColor = Color.FromArgb(93, 40, 158);
            MultiForms(new Description(user));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClearMarker();
            btnSearch.BackColor = Color.FromArgb(93, 40, 158);
            panelSubMenu.Visible = false;
            MultiForms(new Search());
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            ClearMarker();
            btnReg.BackColor = Color.FromArgb(93, 40, 158);
            panelSubMenu.Visible = false;
            MultiForms(new Registration());
        }

        private void btnGenerator_Click(object sender, EventArgs e)
        {
            ClearMarker();
            btnGenerator.BackColor = Color.FromArgb(93, 40, 158);
            MultiForms(new Generator());
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            ClearMarker();
            btnStatus.BackColor = Color.FromArgb(93, 40, 158);
            MultiForms(new Status());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ClearMarker();
            btnLogout.BackColor = Color.FromArgb(93, 40, 158);
            DialogResult ans = MessageBox.Show("Sign out?","Comfirm Sign Out",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(ans == DialogResult.Yes)
            {
                Form frm = new Login();
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void panelReg_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
