using System.Data;
using Microsoft.Data.SqlClient;

namespace TableDataGateway.GatewaysSql
{
    /// <summary>
    ///     Table Data Gateway pattern example.
    ///     Using plain SQL
    /// </summary>
    public class ProductGateway
    {
        private readonly string _connectionString;

        public ProductGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var adapter = new SqlDataAdapter();
                var table = new DataTable();

                var command = new SqlCommand(@"SELECT * FROM Product WHERE Id = @id", connection);
                command.Parameters.AddWithValue("id", id);

                adapter.SelectCommand = command;
                adapter.Fill(table);

                // In most cases we would use e.g. AutoMapper to convert it to DTO
                return table;
            }
        }

        public bool DeleteById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"DELETE FROM Product WHERE Id = @id", connection);
                command.Parameters.AddWithValue("id", id);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
