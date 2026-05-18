using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.SqlClient;
namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=PractikaBD;Integrated Security=True;TrustServerCertificate=True;";
            PlayerCRUD q1 = new(connectionString);
            q1.Update();
            q1.Select();
            q1.Insert();
            q1.Delete();
            
        }
    }
    class PlayerCRUD
    {
        private string _connectionString;
        public PlayerCRUD(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Select()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT Player_id, Player_name, MMR from Players where MMR > 1000";
                using (var cmd = new SqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\nСписок игроков:");
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var name = reader.GetString(1);
                        int? mmr = reader.IsDBNull(2) ? null : reader.GetInt32(2);
                        Console.WriteLine($"{id}: {name} (MMR: {mmr?.ToString() ?? "нет"})");
                    }
                }
            }

        }
        public void Insert()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Players (Player_name, MMR, DotaPlus, Country_id) VALUES (@name, @mmr, @dotaplus,@country)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", "TestUser");
                    cmd.Parameters.AddWithValue("@mmr", 1500);
                    cmd.Parameters.AddWithValue("@dotaplus", false);
                    cmd.Parameters.AddWithValue("@country", 1);
                    int rows = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Добавлено игроков: {rows}");
                }
            }

        }
        public void Update()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "Update Players SET MMR = @mmr Where player_id = @id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("mmr", 3050);
                    cmd.Parameters.AddWithValue("@id", 1);
                    int rows = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Обновлено игроков: {rows}");
                }

            }
        }
        public void Delete()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "Delete from players where player_id = @id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", 12);
                    int rows = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Удалено игроков: {rows}");

                }
            }


        }
    }
}