using MyMomentsOfZenAPI.Controllers;
using MyMomentsOfZenAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyMomentsOfZenAPI.Views
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User theUser = new User();
            theUser.Id = 3;
            theUser.DisplayName = "Deanna";
            
            Application.Add("currentuser", theUser);
         
        }
        protected void Get_List(object sender, EventArgs e)
        {
            //VideoClipListController vcc = new VideoClipListController();
            //IEnumerable cliplist = vcc.GetAllClips();
            

        }
        protected void Inc_Play_Count(object sender, EventArgs e)
        {
            

        }
    }
}