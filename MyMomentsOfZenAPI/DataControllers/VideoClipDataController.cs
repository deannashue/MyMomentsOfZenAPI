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
    public class VideoClipDataController
    {
        private static MySQLDataContext db = new MySQLDataContext();

        
        private static List<VideoClip> CalculateRank(List<VideoClip> clips)
        {
            int count = 0;
            int previousPlays = -1;

            foreach (VideoClip item in clips) {

                if (item.Plays != previousPlays)
                {
                    item.Rank = ++count;
                }
                else
                {
                    item.Rank = count;
                }
                previousPlays = item.Plays;
            }

            return clips;
        }
        private static VideoClip PopulateClip(MySqlDataReader _dr)
        {
            VideoClip clip = new VideoClip();
            clip.Id = Convert.ToInt32(_dr["id"]);
            clip.Name = Convert.ToString(_dr["clip_name"]);
            clip.ThumbnailUrl = "http://www.shueville.us/zen_thumbnails/" + Convert.ToString(_dr["thumbnail_url"]);
            clip.VideoUrl = "http://www.shueville.us/zen_videos/" + Convert.ToString(_dr["clip_url"]);
            clip.Duration = Convert.ToDateTime(_dr["length"]).TimeOfDay;
            clip.Plays = Convert.ToInt32(_dr["playcount"]);
            clip.AuthorId = Convert.ToInt32(_dr["user_id"]);
            clip.Author = Convert.ToString(_dr["author_name"]);
            clip.Favorite = Convert.ToBoolean( _dr["favorite"]);
            
            return clip;

        }

        public static List<VideoClip> ListAllClips(int userId)
        {            
            MySqlCommand cmd = new MySqlCommand("spListAllVideoClips", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_user_id", userId);
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<VideoClip> VideoClipList = new List<VideoClip>();
            
            while (dr.Read())
            {
                VideoClip clip = PopulateClip(dr);
                VideoClipList.Add(clip);
            }
            dr.Close();
            db.Connection.Dispose();
            return CalculateRank(VideoClipList);
        }

        public static List<VideoClip> SearchClips(string criteria, int userId)
        {
            MySqlCommand cmd = new MySqlCommand("spSearchVideoClips", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Criteria", criteria);
            cmd.Parameters.AddWithValue("@_user_id", userId);
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<VideoClip> VideoClipList = new List<VideoClip>();

            while (dr.Read())
            {
                VideoClip clip = PopulateClip(dr);
                VideoClipList.Add(clip);
            }
            dr.Close();
            db.Connection.Dispose();
            return CalculateRank(VideoClipList);
        }

        public static List<VideoClip> UsersFavoriteClips(int user_id)
        {
            MySqlCommand cmd = new MySqlCommand("spListUsersFavoriteClips", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user_id", user_id);
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<VideoClip> VideoClipList = new List<VideoClip>();

            while (dr.Read())
            {
                VideoClip clip = PopulateClip(dr);
                VideoClipList.Add(clip);
            }
            dr.Close();
            db.Connection.Dispose();
            return CalculateRank(VideoClipList);
        }

        public static VideoClip GetVideoClip(int id)
        {
            MySqlCommand cmd = new MySqlCommand("spGetVideoClip", db.Connection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clipid", id);
                cmd.Connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                VideoClip clip = null;
                dr.Read();
                if (dr.HasRows)
                {
                    clip = PopulateClip(dr);
                }

                dr.Close();
                db.Connection.Dispose();
                return clip;

            }
            finally
            {
                cmd.Connection.Close();
                db.Connection.Dispose();
            }
            
            
        }

        public static bool IncrementPlayCount(int clipid, int userid)
        {
            MySqlCommand cmd = new MySqlCommand("spIncrementVideoPlays", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@clip_id", clipid);
            cmd.Parameters.AddWithValue("@user_id", userid);
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dr.Close();
            db.Connection.Dispose();
            return true;
        }

        

    }
}