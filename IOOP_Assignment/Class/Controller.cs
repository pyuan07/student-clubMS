using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Collections;
using System.Data;

namespace IOOP_Assignment
{
    class Controller
    {
        public SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader rdr;

        public void Connect()
        {
            conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = '|DataDirectory|\\Student_Clubs.mdf'; Integrated Security = True; Connect Timeout = 30");
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public string getClubName(int clubid)
        {
            string name = "CLUB_NAME";
            Connect();
            string sql = "SELECT ClubName FROM Clubs WHERE ClubID=@ID";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID", clubid);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                name = dr["ClubName"].ToString();
            }
            dr.Close();
            return name;
        }

        //Search
        public SqlDataReader ClubSearch(string keywords)
        {
            Connect();
            string SearchClubSQL = "SELECT ClubName FROM Clubs WHERE ClubName like '%" + keywords + "%' AND Status = 'active' GROUP BY ClubName ORDER BY ClubName";
            cmd = new SqlCommand(SearchClubSQL, conn);
            rdr = cmd.ExecuteReader();

            return rdr;
        }

        public SqlDataReader getPosition(int clubID, string position)
        {
            Connect();
            string PositionDetailSQL = "SELECT Name,Position FROM ClubPositions WHERE ClubID = @id AND Position = @pst";
            cmd = new SqlCommand(PositionDetailSQL, conn);
            cmd.Parameters.AddWithValue("@id", clubID.ToString());
            cmd.Parameters.AddWithValue("@pst", position);
            SqlDataReader rdr1 = cmd.ExecuteReader(); ;

            return rdr1;
        }
        
        //Report
        public int SubmitReport(string clubname, DateTime date, string activity, string achieve)
        {
            Clubs clb = new Clubs(clubname);
            int clubid = clb.getClubID();
            Connect();
            string SubmitReportSQL;

            if (achieve == "") //Report without Achievement
            {
                SubmitReportSQL = "INSERT INTO Report (ClubID,ReportDateTime,ActivityDesc) VALUEs (@clubid,@datetime,@activ)";
                cmd = new SqlCommand(SubmitReportSQL, conn);
                cmd.Parameters.AddWithValue("@clubid", clubid);
                cmd.Parameters.AddWithValue("@datetime", date);
                cmd.Parameters.AddWithValue("@activ", activity);
            }
            else //Report with Achievement
            {
                SubmitReportSQL = "INSERT INTO Report (ClubID,ReportDateTime,ActivityDesc,Achievement) VALUEs (@clubid,@datetime,@activ,@achieve)";
                cmd = new SqlCommand(SubmitReportSQL, conn);
                cmd.Parameters.AddWithValue("@clubid", clubid);
                cmd.Parameters.AddWithValue("@datetime", date);
                cmd.Parameters.AddWithValue("@activ", activity);
                cmd.Parameters.AddWithValue("@achieve", achieve);
            }

            int state = cmd.ExecuteNonQuery();
            conn.Close();
            return state;
        }

        //Status
        public DataSet StatusShow()
        {
            string statusSql = "SELECT ClubName AS 'Club Name',StatusChg AS 'Last Update',Status AS 'Current Status' FROM Clubs ORDER BY ClubName";
            Connect();
            SqlDataAdapter adp = new SqlDataAdapter(statusSql, conn);
            DataSet data = new DataSet();
            adp.Fill(data);

            return data;
        }

        public int CheckDuplication(string club, string username)
        {
            int duplic = 0;
            Connect();
            string sqlClubs = "SELECT ClubName FROM Clubs";
            cmd = new SqlCommand(sqlClubs, conn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (club.ToLower() == rdr[0].ToString().ToLower())
                {
                    duplic += 1; // 1 = clubname duplication
                }
            }
            rdr.Close();
            string sqlUsername = "SELECT Username FROM Users";
            cmd = new SqlCommand(sqlUsername, conn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (username.ToLower() == rdr[0].ToString().ToLower())
                {
                    duplic += 2; // 2 = username duplication
                }
            }
            // 0 = no duplication
            // 3 = both clubname and username duplication
            rdr.Close();
            return duplic;
        }
    }
}