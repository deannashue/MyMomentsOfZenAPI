using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMomentsOfZenAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Disabled { get; set; }

        public List<VideoClip> FavoriteClips { get; set; }

        public User ()
        {
            
        }
    }
}