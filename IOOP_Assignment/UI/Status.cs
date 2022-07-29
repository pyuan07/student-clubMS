using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace IOOP_Assignment
{
    public partial class Status : Form
    {
        public Status()
        {
            InitializeComponent();
        }
        Controller ctrl = new Controller();

        private void getStatus()
        {
            DataSet showTable = ctrl.StatusShow();
            dgvStatus.DataSource = showTable.Tables[0];
        }

        private string getCells(string col)
        {
            int RowIndex = dgvStatus.SelectedRows[0].Index;
            string data = dgvStatus.Rows[RowIndex].Cells[col].Value.ToString();
            return data;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            getStatus();
        }

        private void btnDeregister_Click(object sender, EventArgs e)
        {
            int selectedCellCount =dgvStatus.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                string clubname = getCells("Club Name");
                DialogResult rpl = MessageBox.Show("Are you sure want to deregister "+ clubname+ "?\n After Deregister, data cannot be recovered", "Confirmation of Deregister", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpl == DialogResult.Yes)
                {
                    Clubs clb = new Clubs(clubname);
                    int state = clb.Deregister();
                    if (state > 0)
                    {
                        MessageBox.Show("Deregister successfully","Deregister Club",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        ctrl.StatusShow();
                    }
                }
            }
            getStatus();
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            string clubname = getCells("Club Name");
            Clubs clb = new Clubs(clubname);
            string status = getCells("Current Status");
            if (status=="active")
            {
                int state = clb.updateStatus("inactive");
                if (state > 0)
                {
                    MessageBox.Show("Deactivated Successfully!","Update Status",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    getStatus();
                }
                else
                {
                    MessageBox.Show("Please try again!", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if(status=="inactive")
            {
                int state = clb.updateStatus("active");
                if (state > 0)
                {
                    MessageBox.Show("Activated Successfully!", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getStatus();
                }
                else
                {
                    MessageBox.Show("Please try again!", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string status = getCells("Current Status");
            if (status == "active")
            {
                btnDeactivate.Text = "Deactivate";
            }
            else if (status == "inactive")
            {
                btnDeactivate.Text = "Activate";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
