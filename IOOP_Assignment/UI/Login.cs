using System;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.ReportingServices.Interfaces;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace IOOP_Assignment
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        bool hide = true;
        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            picShow.Image = imageList1.Images[0];
        }

        private void picShow_Click(object sender, EventArgs e)
        {
            if (hide)
            {
                picShow.Image = imageList1.Images[1];
                hide = false;
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                picShow.Image = imageList1.Images[0];
                hide = true;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            lblPassword.ForeColor = Color.White;
            lblUsername.ForeColor = Color.FromArgb(81, 81, 174);
            txtPassword.ForeColor = Color.White;
            txtUsername.ForeColor = Color.FromArgb(101, 101, 194);
            picUsername.Image = imageList1.Images[4];
            picPassword.Image = imageList1.Images[3];
            panel1.BackColor = Color.FromArgb(51, 51, 144);
            panel2.BackColor = Color.Silver;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            lblUsername.ForeColor = Color.White;
            lblPassword.ForeColor = Color.FromArgb(81, 81, 174);
            txtUsername.ForeColor = Color.White;
            txtPassword.ForeColor = Color.FromArgb(101, 101, 194);
            picUsername.Image = imageList1.Images[2];
            picPassword.Image = imageList1.Images[5];
            panel2.BackColor = Color.FromArgb(51, 51, 144);
            panel1.BackColor = Color.Silver;
        }

        private void LoginInAs(string id)
        {
            Dashboard dsh = new Dashboard();
            dsh.Access(id);
            this.Hide();
            dsh.ShowDialog();
            this.Close();
        }

        Controller ctrl = new Controller();
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Users usr = new Users(txtUsername.Text, txtPassword.Text);
            int clubid = usr.verifyLogin();
            switch (usr.Role)
            {
                case ("admin"):
                    MessageBox.Show("Successfully logged in as an admin.", "Logged in Successfully");
                    LoginInAs("admin");
                    break;

                case ("student"):
                    MessageBox.Show("Successfully logged in as a student.", "Logged in Successfully");
                    LoginInAs("student");
                    break;

                case ("club"):
                    string clubname = ctrl.getClubName(clubid);
                    Clubs clb = new Clubs(clubname);
                    bool status = clb.checkStatus();
                    if (status)
                    {
                        MessageBox.Show("Successfully logged in as " + clubname + "'s Commitee.", "Logged in Successfully");
                        LoginInAs(clubname);
                    }
                    else
                    {
                        MessageBox.Show(clubname + " has been Deactivate. Kindly please ask the administrator for details.", "Inactive Club", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                default://Data not found
                    MessageBox.Show("Login failed. Please try again.", "Incorrect Password or Username");
                    txtUsername.ForeColor = Color.FromArgb(220, 45, 45);
                    txtPassword.ForeColor = Color.FromArgb(220, 45, 45);
                    lblUsername.ForeColor = Color.FromArgb(220, 45, 45);
                    lblPassword.ForeColor = Color.FromArgb(220, 45, 45);
                    picUsername.Image = imageList1.Images[6];
                    picPassword.Image = imageList1.Images[7];
                    panel2.BackColor = Color.FromArgb(220, 45, 45);
                    panel1.BackColor = Color.FromArgb(220, 45, 45);
                    break;
            }
        }
    }
}