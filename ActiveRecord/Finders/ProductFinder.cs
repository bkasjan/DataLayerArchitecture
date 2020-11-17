using System;
using System.Data;
using ActiveRecord.Gateways;
using Microsoft.Data.SqlClient;

namespace ActiveRecord.Finders
{
    public class ProductFinder
    {
        private readonly string _connectionString;

        public ProductFinder(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ProductGateway FindById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"SELECT * FROM Product WHERE Id = @id", connection);
                command.Parameters.AddWithValue("id", id);
                
                var table = new DataTable();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(table);

                var rawProduct = table.Rows[0];

                return new ProductGateway(_connectionString)
                {
                    Id = id,
                    Name = rawProduct["Name"].ToString(),
                    Price = Convert.ToDouble(rawProduct["Price"])
                };

            }
        }
    }
}
