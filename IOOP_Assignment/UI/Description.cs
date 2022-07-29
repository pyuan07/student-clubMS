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
    public partial class Description : Form
    {
        Controller ctrl = new Controller();
        string user;

        public Description(string user)
        {
            InitializeComponent();
            this.user = user;
            
        }

        private void Description_Load(object sender, EventArgs e)
        {
            //add item to ComboBox
            cboClub.DropDownStyle = ComboBoxStyle.DropDownList;
            SqlDataReader dr = ctrl.ClubSearch("");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cboClub.Items.Add(dr["ClubName"]);
                }
            }
            //Check the user
            if (user != "admin")
            {
                cboClub.SelectedItem = user;
                cboClub.Enabled = false;
                Clubs clb = new Clubs(user);
                dr = clb.getClubsDetail();
                if (dr.Read())
                {
                    txtDescription.Text = dr["Descrip"].ToString();
                }
            }
        }

        private void cboClub_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clubs clb = new Clubs(cboClub.Text);
            SqlDataReader dr = clb.getClubsDetail();
            if (dr.Read())
            {
                txtDescription.Text = dr["Descrip"].ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cboClub.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a club before update.","Club not exist",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                Clubs clb = new Clubs(cboClub.Text);
                int state = clb.updateDescription(txtDescription.Text);
                if (state > 0)
                {
                    MessageBox.Show("Description updated successfully", "Description Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to update description", "Description update failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SqlDataReader dr = clb.getClubsDetail();
                if (dr.Read())
                {
                    txtDescription.Text = dr["Descrip"].ToString();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDescription.Clear();
        }
    }
}
