using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.ComponentModel;
using MyMomentsOfZenAPI.Models;

namespace MyMomentsOfZenAPI.DataControllers
{
    public class UserDataController
    {

        private static MySQLDataContext db = new MySQLDataContext();

        private static User Populate(MySqlDataReader _dr)
        {
            User user = new User();
            user.Id = Convert.ToInt32(_dr["id"]);
            user.DisplayName = Convert.ToString(_dr["display_name"]);
            return user;

        }


        public static User GetUser(int id)
        {
            MySqlCommand cmd = new MySqlCommand("spGetUser", db.Connection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", id);
                cmd.Connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                User user = null;
                dr.Read();
                if (dr.HasRows)
                {
                    user = Populate(dr);
                }
                
                dr.Close();
                db.Connection.Dispose();
                return user;

            }
            finally
            {
                cmd.Connection.Close();
                db.Connection.Dispose();
            }


        }

        public static bool UnFavorClip(int clipid, int userid)
        {
            MySqlCommand cmd = new MySqlCommand("spUnFavorClip", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_clip_id", clipid);
            cmd.Parameters.AddWithValue("@_user_id", userid);
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dr.Close();
            db.Connection.Dispose();
            return true;
        }

        public static bool FavorClip(int clipid, int userid)
        {
            MySqlCommand cmd = new MySqlCommand("spFavorClip", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_clip_id", clipid);
            cmd.Parameters.AddWithValue("@_user_id", userid);
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dr.Close();
            db.Connection.Dispose();
            return true;
        }

    }
}