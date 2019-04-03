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
                cmd.CommandText = "INSERT INTO Persons VALUES (@Name,@Addres,@Phone,getdate(),@Image)";
                cmd.Parameters.AddWithValue("@Name", person.Name);
                cmd.Parameters.AddWithValue("@Addres", person.Addres);
                cmd.Parameters.AddWithValue("@Phone", person.Phone);
                var bytes = new byte[person.Image.ContentLength];
                person.Image.InputStream.Read(bytes, 0, person.Image.ContentLength);
                cmd.Parameters.AddWithValue("@Image", bytes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal byte[] GetImage(string id)
        {
            using (var conn = new SqlConnection(dbconn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT IMAGE FROM Persons WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                var reader = cmd.ExecuteScalar() as byte[];
                return reader;
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

        internal void DeletePerson(string id)
        {
            using (var conn = new SqlConnection(dbconn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"DELETE FROM Persons WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdatePerson(Persons persons)
        {
            using (var conn = new SqlConnection(dbconn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE Persons SET Name=@Name,Addres=@Addres,Phone=@Phone WHERE Id=@Id  ";
                cmd.Parameters.AddWithValue("@Name", persons.Name);
                cmd.Parameters.AddWithValue("@Addres", persons.Addres);
                cmd.Parameters.AddWithValue("@Phone", persons.Phone);
                cmd.Parameters.AddWithValue("@Id", persons.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal object GetPerson(string id)
        {
            using (var conn = new SqlConnection(dbconn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT *FROM Persons WHERE Id=@Id";
                
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                var reader=cmd.ExecuteReader();
                Persons person = null;
                if (reader.Read())
                {
                    person = new Persons();
                    person.Id = (int)reader["Id"];
                    person.Name = reader["Name"] as string;
                    person.Addres = reader["Addres"] as string;
                    person.Phone = reader["Phone"] as string;
                    person.Date = (DateTime)reader["Date"];
                    

                }
                return person;

            }
        }
    }
}