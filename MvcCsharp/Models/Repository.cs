using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MvcCsharp.ViewModels;

namespace MvcCsharp.Models
{
    public class Repository
    {
        public string dbconn = System.Configuration.ConfigurationManager.ConnectionStrings["Db"].ConnectionString;

       public void CreatePerson(Persons person)
        {
            using (var conn = new SqlConnection(dbconn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Persons VALUES (@Name,@Addres,@Phone,@Date)";
                cmd.Parameters.AddWithValue("@Name", person.Name);
                cmd.Parameters.AddWithValue("@Addres", person.Addres);
                cmd.Parameters.AddWithValue("@Phone", person.Phone);
                cmd.Parameters.AddWithValue("@Date", person.Date);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}