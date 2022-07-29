using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void Clear()
        {
            txtDescription.Text = "";
            txtClubName.Text = "";
            txtMember1.Text = "";
            txtMember2.Text = "";
            txtPassword.Text = "";
            txtPresident.Text = "";
            txtSecretary.Text = "";
            txtUsername.Text = "";
            txtVicePresident.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult rslt = new DialogResult();
            rslt = MessageBox.Show("Please make sure that the club name you entered is correct, \nthe user name and password can be remembered, \nbecause neither of them can be changed in the future", "Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if(rslt == DialogResult.Yes)
            {
                Controller ctrl = new Controller();
                if (txtClubName.Text == "" || txtDescription.Text == "" || txtMember1.Text == "" || txtMember2.Text == "" || txtPassword.Text == "" || txtPresident.Text == "" || txtSecretary.Text == "" || txtUsername.Text == "" || txtVicePresident.Text == "")
                {
                    MessageBox.Show("Please fill up all the blank before submitting the Registration Form", "Empty data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int duplication = ctrl.CheckDuplication(txtClubName.Text, txtUsername.Text);

                    //Check for duplication
                    switch (duplication)
                    {
                        case 0: // no duplication
                                //Detail
                            Clubs clb = new Clubs(txtClubName.Text, dateTimePicker1.Value.Date, txtDescription.Text, "active", DateTime.Now);
                            int a = clb.addClub();
                            //Position
                            ClubPosition pst;
                            pst = new ClubPosition(txtPresident.Text, "President");
                            int b = pst.InsertPosition(clb.ClubName);

                            pst = new ClubPosition(txtVicePresident.Text, "Vice President");
                            int c = pst.InsertPosition(clb.ClubName);

                            pst = new ClubPosition(txtSecretary.Text, "Secretary");
                            int d = pst.InsertPosition(clb.ClubName);

                            pst = new ClubPosition(txtMember1.Text, "Member");
                            int f = pst.InsertPosition(clb.ClubName);

                            pst = new ClubPosition(txtMember2.Text, "Member");
                            int g = pst.InsertPosition(clb.ClubName);

                            //User ID
                            Users usr = new Users(txtUsername.Text, txtPassword.Text, "club");
                            int h = usr.InsertUser(clb.ClubName);

                            if (a * b * c * d * f * g * h > 0)
                            {
                                MessageBox.Show("Club has been added successfully", "Club Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                            }
                            else
                            {
                                MessageBox.Show("Unable to add club", "Add club failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;

                        case 1: // clubname duplication
                            MessageBox.Show("ClubName exist.", "Add club failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 2:// username duplication
                            MessageBox.Show("Username exist.", "Add club failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 3:// both duplication
                            MessageBox.Show("Both ClubName and Username exist.", "Add club failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
