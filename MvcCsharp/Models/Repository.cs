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

        internal object ListPerson(string CustomerName)
        {
            using (var conn = new SqlConnection(dbconn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT *FROM Persons WHERE NAME LIKE @Search Or Phone LIKE @Phone";
                cmd.Parameters.AddWithValue("@Phone", CustomerName + "%%");
                cmd.Parameters.AddWithValue("@Search", CustomerName+"%%");
                conn.Open();
                var reader = cmd.ExecuteReader();
                var listPersons = new List<Persons>();
                while (reader.Read())
                {
                    var person = new Persons();
                    person.Id = (int)reader["Id"];
                    person.Name = reader["Name"] as string;
                    person.Addres = reader["Addres"]as string;
                    person.Phone = reader["Phone"]as string;
                    person.Date = (DateTime)reader["Date"];
                    listPersons.Add(person);

                }
                return listPersons;
             
            }
        }
    }
}