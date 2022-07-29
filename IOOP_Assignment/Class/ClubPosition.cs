using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOOP_Assignment
{
    class ClubPosition
    {
        private string name;
        private string position;

        public ClubPosition(string name, string position)
        {
            this.name = name;
            this.position = position;
        }

        public ClubPosition(string position)
        {
            this.position = position;
        }

        public string Name { get => name; set => name = value; }
        public string Position { get => position; set => position = value; }

        Controller ctrl = new Controller();
        SqlCommand cmd;
        Clubs clb;

        public int InsertPosition(string club)
        {
            clb = new Clubs(club);
            int id = clb.getClubID();
            string sql = "INSERT INTO ClubPositions(ClubID,Name,Position) VALUES (@clubid,@name,@posit)";
            ctrl.Connect();
            cmd = new SqlCommand(sql, ctrl.conn);
            cmd.Parameters.AddWithValue("@clubid", id);
            cmd.Parameters.AddWithValue("@name", this.name);
            cmd.Parameters.AddWithValue("@posit", this.position);
            int state = cmd.ExecuteNonQuery();
            return state;
        }

        public int RemovePosition(string clubname)
        {
            clb = new Clubs(clubname);
            int clubid = clb.getClubID();
            string RemoveMemberSQL = "DELETE FROM ClubPositions WHERE (CLUBID=@clubid AND POSITION = '" + position + "')";
            ctrl.Connect();
            cmd = new SqlCommand(RemoveMemberSQL, ctrl.conn);
            cmd.Parameters.AddWithValue("@clubid", clubid);
            int state = cmd.ExecuteNonQuery();
            return state;
        }

        public int UpdatePosition(string clubname)
        {
            clb = new Clubs(clubname);
            int id = clb.getClubID();
            string sql = "UPDATE CLUBPOSITIONS SET NAME=@name WHERE CLUBID=@clubid and POSITION=@position";
            ctrl.Connect();
            cmd = new SqlCommand(sql, ctrl.conn);
            ClubPosition posit = new ClubPosition(name, position);
            cmd.Parameters.AddWithValue("@clubID", id);
            cmd.Parameters.AddWithValue("@name", this.name);
            cmd.Parameters.AddWithValue("@position", this.position);
            int state = cmd.ExecuteNonQuery();
            return state;
        }
    }
}
