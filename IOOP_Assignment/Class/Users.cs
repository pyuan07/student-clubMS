using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOOP_Assignment
{
    class Users
    {
        private string username;
        private string password;
        private string role;

        public Users(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }

        public Users(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }


        Controller ctrl = new Controller();
        SqlCommand cmd;

        public int InsertUser(string clubname)
        {
            Clubs clb = new Clubs(clubname);
            int id = clb.getClubID();
            string sql = "INSERT INTO Users(ClubID,Username,Password,role) VALUES (@clubid,@name,@pass,@role)";
            ctrl.Connect();
            cmd = new SqlCommand(sql, ctrl.conn);
            cmd.Parameters.AddWithValue("@clubid", id);
            cmd.Parameters.AddWithValue("@name", this.username);
            cmd.Parameters.AddWithValue("@pass", this.password);
            cmd.Parameters.AddWithValue("@role", this.role);
            int state = cmd.ExecuteNonQuery();
            return state;
        }

        public int verifyLogin()
        {
            string sql = "SELECT Username,Password,Role,ClubID FROM Users WHERE Username = @username AND Password = @password";
            ctrl.Connect();

            cmd = new SqlCommand(sql, ctrl.conn);
            cmd.Parameters.AddWithValue("@username", this.username);
            cmd.Parameters.AddWithValue("@password", this.password);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                this.role = rdr["Role"].ToString();
                if (this.role == "club")
                {
                    int clubid = int.Parse(rdr["ClubID"].ToString());
                    return clubid;
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }
    }
}