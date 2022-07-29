using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    public partial class Report : Form
    {
        string user;
        public Report(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        Controller ctrl = new Controller();

        private void Report_Load(object sender, EventArgs e)
        {
            lblAchie.Visible = false;
            txtAchieve.Visible = false;
            dtpDate.Value = DateTime.Now;
            //comboBox
            cboClub.DropDownStyle = ComboBoxStyle.DropDownList;
            SqlDataReader dr = ctrl.ClubSearch("");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cboClub.Items.Add(dr["ClubName"]);
                }
            }

            if (user != "admin")
            {
                cboClub.SelectedItem = user;
                cboClub.Enabled = false;
                //DateTimePicker
                Clubs clb = new Clubs(user);
                dr = clb.getClubsDetail();
                if (dr.Read())
                {
                    dtpDate.MinDate = DateTime.Parse(dr[2].ToString());
                    dtpDate.MaxDate = DateTime.Today.AddDays(7);
                }

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkAchieve_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAchieve.Checked)
            {
                lblAchie.Visible = true;
                txtAchieve.Visible = true;
            }
            else
            {
                lblAchie.Visible = false;
                txtAchieve.Visible = false;
                txtAchieve.Text = "";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            txtActivity.Text = "";
            txtAchieve.Text = "";
            chkAchieve.Checked = false;
            lblAchie.Visible = false;
            txtAchieve.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtActivity.Text == "")
            {
                MessageBox.Show("Please fill up all the blank before submitting the Registration Form", "Empty data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int state = ctrl.SubmitReport(cboClub.Text, dtpDate.Value, txtActivity.Text, txtAchieve.Text);
                if (state > 0)
                {
                    MessageBox.Show("Updated Successfully", " Update Weekly Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtActivity.Text = "";
                    txtAchieve.Text = "";
                }
                else
                {
                    MessageBox.Show("Updated Failed, Please try again.", "Update Position", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
