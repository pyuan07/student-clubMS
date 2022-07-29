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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        Controller ctrl = new Controller();

        private void Search_Load(object sender, EventArgs e)
        {
            lblDetail.Height = lstResult.Height;
            txtKeyword.ForeColor = Color.Gray;
            txtKeyword.Text = "Enter Search Keyword Here...";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtKeyword.Text == "Enter Search Keyword Here...")
            {
                txtKeyword.Text = "";
            }
            lstResult.Items.Clear();
            //call ClubSearch Function
            SqlDataReader dr = ctrl.ClubSearch(txtKeyword.Text);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lstResult.Items.Add(dr["ClubName"]);
                }
            }
            int count = lstResult.Items.Count;
            lstResult.Items.Add("-----------------------------------");
            lstResult.Items.Add("      " + count + " data Found.");
        }

        private void txtKeyword_Click(object sender, EventArgs e)
        {
            if (txtKeyword.Text == "Enter Search Keyword Here...")
            {
                txtKeyword.ForeColor = Color.White;
                txtKeyword.Text = "";
            }
        }
        private void lstResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstResult.SelectedItem.ToString() != "-------------------" || lstResult.SelectedIndex != lstResult.Items.Count)
            {
                lblDetail.Text = "";
                Clubs clb = new Clubs(lstResult.SelectedItem.ToString());
                SqlDataReader dr = clb.getClubsDetail();
                if (dr.Read())
                {
                    int clubId = int.Parse(dr["ClubID"].ToString());
                    SqlDataReader preName = ctrl.getPosition(clubId, "President");
                    SqlDataReader vicepreName = ctrl.getPosition(clubId, "Vice President");
                    preName.Read();
                    vicepreName.Read();
                    lblDetail.Text =
                        "Club Name:             " + dr["ClubName"].ToString() +
                        "\nEstablished Date:  " + dr.GetDateTime(2).ToString("dddd, dd MMMM yyyy") +
                        "\nPresident:                " + preName["Name"] +
                        "\nVice President:       " + vicepreName["Name"] +
                        "\nDescription:\n" + dr["Descrip"].ToString();
                }
            }
        }
    }
}
