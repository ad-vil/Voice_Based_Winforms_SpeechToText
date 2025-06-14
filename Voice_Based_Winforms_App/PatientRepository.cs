//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Voice_Based_Winforms_App
//{
//    internal class PatientRepository
//    {
//    }
//}


using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace Voice_Based_Winforms_App
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
    }

    public static class PatientRepository
    {
        private static readonly string _connectionString = "Data Source=patientDatabase.db";

        public static List<Patient> GetAll()
        {
            var list = new List<Patient>();
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, firstName, lastName, city, country FROM Patients";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Patient
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    City = reader.GetString(3),
                    Country = reader.GetString(4)
                });
            }
            return list;
        }

        public static void Add(Patient p)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Patients (firstName, lastName, city, country) VALUES (@f, @l, @c, @co)";
            cmd.Parameters.AddWithValue("@f", p.FirstName);
            cmd.Parameters.AddWithValue("@l", p.LastName);
            cmd.Parameters.AddWithValue("@c", p.City);
            cmd.Parameters.AddWithValue("@co", p.Country);
            cmd.ExecuteNonQuery();
        }

        public static void Update(Patient p)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Patients SET firstName=@f, lastName=@l, city=@c, country=@co WHERE Id=@id";
            cmd.Parameters.AddWithValue("@f", p.FirstName);
            cmd.Parameters.AddWithValue("@l", p.LastName);
            cmd.Parameters.AddWithValue("@c", p.City);
            cmd.Parameters.AddWithValue("@co", p.Country);
            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.ExecuteNonQuery();
        }

        public static void Delete(int id)
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Patients WHERE Id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}