using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public static class crud
    {
        public static void Create(string regionDescription, SqlConnection conn)
        {
            string sql = "INSERT INTO northwind.dbo.Region(RegionId,RegionDescription) VALUES (5,'@regionName');";
            var command = new SqlCommand(sql, conn);
            command.Parameters.Add("regionName", regionDescription);

            int a = command.ExecuteNonQuery();
            if (a > 0)
            {
                Console.WriteLine("Wpisano");
            }
        }

        public static void Read(SqlConnection connect)
        {
            SqlCommand command = new SqlCommand
            {
                CommandText = "SELECT * FROM Northwind.dbo.Customers",
                Connection = connect,
            };

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["CompanyName"]);
            }
            reader.Close();
        }

        public static void Update(SqlConnection connect)
        {
            connect.Open();
            string sql = "UPDATE Region SET RegionDescription = @regionName WHERE RegionId = @id";

            var command = new SqlCommand(sql);
            command.Parameters.AddWithValue("id", "");
            command.Parameters.AddWithValue("regionName", "");

            command.ExecuteNonQuery();

            connect.Close();
        }
    }
}
