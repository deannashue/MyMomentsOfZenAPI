using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMomentsOfZenAPI.Models
{
    public class VideoClip
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string VideoUrl { get; set; }
        public TimeSpan Duration { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Disabled { get; set; }
        public int Plays { get; set;  }
        public int AuthorId { get; set; }
        public int Rank { get; set; }
        public bool Favorite { get; set; }


        public VideoClip()
        {
            Id = 0;
            Name = "Clip Name";
            Author = "Author Name";
            VideoUrl = null;
            Plays = 0;
            ThumbnailUrl = null;
            DateCreated = new DateTime();
            Disabled = false;
            Favorite = false;

        }
    }
}