using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Schema;

namespace IOOP_Assignment
{
    public partial class CommiteeDetail : Form
    {
        public CommiteeDetail()
        {
            InitializeComponent();
        }

        Controller ctrl = new Controller();
        ClubPosition pst;

        private void CommiteeDetail_Load(object sender, EventArgs e)
        {
            cboClub.DropDownStyle = ComboBoxStyle.DropDownList;
            SqlDataReader dr = ctrl.ClubSearch("");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cboClub.Items.Add(dr["ClubName"]);
                }
            }
        }

        private void cboClub_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstCommitee.Items.Clear();
            Clubs clb = new Clubs(cboClub.Text);
            int id = clb.getClubID();
            SqlDataReader dr;

            dr = ctrl.getPosition(id, "President");
            dr.Read();
            txtPresident.Text = dr["Name"].ToString();

            dr = ctrl.getPosition(id, "Vice President");
            dr.Read();
            txtVicePresident.Text = dr["Name"].ToString();

            dr = ctrl.getPosition(id, "Secretary");
            dr.Read();
            txtSecretary.Text = dr["Name"].ToString();

            dr = ctrl.getPosition(id, "Member");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lstCommitee.Items.Add(dr["Name"].ToString());
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCommitee.Text == "")
            {
                MessageBox.Show("Commitee Name cannot be empty!", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                lstCommitee.Items.Add(txtCommitee.Text);
                txtCommitee.Text = "";
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstCommitee.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a member!", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                lstCommitee.Items.RemoveAt(lstCommitee.SelectedIndex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPresident.Text != "" || txtVicePresident.Text != "" || txtSecretary.Text != "" || cboClub.SelectedIndex >= 0 || lstCommitee.Items.Count >= 2)
            {
                string club = cboClub.Text;
                pst = new ClubPosition("Member");
                int a = pst.RemovePosition(club); // Remove all Member in the club
                int b = 1;
                for (int index = 0; index <= lstCommitee.Items.Count - 1; index++)
                {
                    string name = lstCommitee.Items[index].ToString();
                    pst = new ClubPosition(name,"member");
                    int c = pst.InsertPosition(club);
                    b = b * c;
                }

                pst = new ClubPosition(txtPresident.Text, "President");
                int d = pst.UpdatePosition(club);

                pst = new ClubPosition(txtVicePresident.Text, "Vice President");
                int f = pst.UpdatePosition(club);

                pst = new ClubPosition(txtSecretary.Text, "Secretary");
                int g = pst.UpdatePosition(club);

                if ((a * b * d * f) > 0)
                {
                    MessageBox.Show("Updated Successfully", "Position Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Something updated Failed", "Position Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please fill up all the blank before updating Commitee Detail.", "Empty data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
