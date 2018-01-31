using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace MyMomentsOfZenAPI.DataControllers
{
    public class MySQLDataContext
    {

        private static string GetConnectionString()
        {
            //return ConfigurationManager.ConnectionStrings
            //    ["MySQLConnectionString"].ConnectionString;
            string connstr = "Server=148.72.232.171;Port=3306;Database=MomentsOfZen;Uid=zendbuser;Pwd=Seiwbf5!2;";
            return connstr;
        }

  

        public MySqlConnection Connection { get; set; }

        public MySQLDataContext()
        {
            Connection = new MySqlConnection(GetConnectionString());
            
        }


    }
}