using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MvcCsharp.ViewModels;

namespace MvcCsharp.Models
{
    public class Auth_Repository
    {
        public string dbconn = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        internal Login Authenticate(Login login)
        {
            using (var conn = new SqlConnection(dbconn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT *FROM Users where Username=@User AND Password=@Pass";
                cmd.Parameters.AddWithValue("@User", login.Username);
                cmd.Parameters.AddWithValue("@Pass", login.Password);
                conn.Open();
                var reader = cmd.ExecuteReader();
                Login loginEnter = null;
                if (reader.Read())
                {
                    loginEnter = new Login();
                    loginEnter.Username = reader["Username"] as string;
                    loginEnter.Password = reader["Password"] as string;

                }
                return loginEnter;
            }
        }
    }
}