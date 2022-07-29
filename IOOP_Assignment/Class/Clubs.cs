using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOOP_Assignment
{
    class Clubs
    {
        private string clubname;
        private DateTime regdate;
        private string description;
        private string status;
        private DateTime statusChg;

        // constructor
        public Clubs(string clubname, DateTime regdate, string description, string status, DateTime statusChg)
        {
            //initialize the datafield values
            this.clubname = clubname;
            this.regdate = regdate;
            this.description = description;
            this.status = status;
            this.statusChg = statusChg;
        }
        public Clubs(string clubname)
        {
            this.clubname = clubname;
        }

        // declare properties using lambda expression
        public string ClubName { get => clubname; set => clubname = value; }
        public DateTime RegDate { get => regdate; set => regdate = value; }
        public string Description { get => description; set => description = value ; }
        public string Status { get => status; set => status = value; }

        Controller ctrl = new Controller();
        SqlCommand cmd;
        SqlDataReader dr;

        public int addClub()
        {
            string insertSQL = "INSERT INTO Clubs(ClubName, RegDate, Descrip,Status,StatusChg) VALUES(@clubname,@regdate,@description,@status,@chgstatus)";
            ctrl.Connect();
            SqlCommand cmd = new SqlCommand(insertSQL, ctrl.conn);
            //define the parameters
            cmd.Parameters.AddWithValue("@clubname", this.ClubName);
            cmd.Parameters.AddWithValue("@regdate", this.RegDate);
            cmd.Parameters.AddWithValue("@description", this.Description);
            cmd.Parameters.AddWithValue("@status", this.Status);
            cmd.Parameters.AddWithValue("@chgstatus", DateTime.Now);
            int state = cmd.ExecuteNonQuery();
            return state;
        }

        public int Deregister()
        {
            int clubid = getClubID();
            ctrl.Connect();
            string sql = "DELETE FROM CLUBPOSITIONs WHERE ClubID=@id;" + "DELETE FROM REPORT WHERE ClubID=@id;" + "DELETE FROM USERS WHERE ClubID=@id;" + "DELETE FROM CLUBS WHERE ClubID = @id;";

            cmd = new SqlCommand(sql, ctrl.conn);
            cmd.Parameters.AddWithValue("@id", clubid);
            int state = cmd.ExecuteNonQuery();
            return state;
        }

        //get date
        public int getClubID()
        {
            int id = 0;
            ctrl.Connect();
            string sql = "SELECT CLUBID FROM CLUBS WHERE ClubName=@clubname";
            cmd = new SqlCommand(sql, ctrl.conn);
            cmd.Parameters.AddWithValue("@clubname", this.clubname);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                id = int.Parse(dr["ClubID"].ToString());
            }
            dr.Close();
            return id;
        }
        public SqlDataReader getClubsDetail()
        {
            ctrl.Connect();
            string ClubDetailSQL = "SELECT ClubID,ClubName,RegDate,Descrip FROM Clubs WHERE ClubName = @club";
            cmd = new SqlCommand(ClubDetailSQL, ctrl.conn);
            cmd.Parameters.AddWithValue("@club", this.clubname);
            dr = cmd.ExecuteReader();

            return dr;
        }

        public bool checkStatus()
        {
            bool flag = false;
            string sql = "SELECT Status FROM Clubs WHERE ClubName = @name";
            ctrl.Connect();
            cmd = new SqlCommand(sql, ctrl.conn);
            cmd.Parameters.AddWithValue("name", this.clubname);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string status = dr["Status"].ToString();
                if (status == "active")
                {
                    flag = true;
                }
            }
            return flag;
        }

        //update
        public int updateDescription(string desc)
        {
            string updateDescSQL = "UPDATE Clubs SET Descrip= @des WHERE ClubName=@name";
            ctrl.Connect();
            cmd = new SqlCommand(updateDescSQL, ctrl.conn);
            cmd.Parameters.AddWithValue("@name", this.clubname);
            cmd.Parameters.AddWithValue("@des", desc);
            int state = cmd.ExecuteNonQuery();
            return state;
        }

        public int updateStatus(string status)
        {
            ctrl.Connect();
            string updateStatusSQL = "UPDATE Clubs SET Status=@stat,StatusChg=@date WHERE ClubName=@name";
            cmd = new SqlCommand(updateStatusSQL, ctrl.conn);
            cmd.Parameters.AddWithValue("@name", this.clubname);
            cmd.Parameters.AddWithValue("@stat", status);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            int state = cmd.ExecuteNonQuery();
            return state;
        }

    }
}
