using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace TableDataGateway.Gateways
{
    public class ProductGateway
    {
        private const string GetByNameSql = "SELECT * FROM Product WHERE NAME = @name;";

        private readonly string _connectionString;

        public ProductGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetByName(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                const string getByNameSql = "SELECT * FROM Product WHERE NAME = @name;";

                var adapter = new SqlDataAdapter();
                var table = new DataTable();

                var command = new SqlCommand(getByNameSql, connection);
                command.Parameters.AddWithValue("name", name);

                adapter.SelectCommand = command;
                adapter.Fill(table);

                return table;
            }
        }

        public bool DeleteById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                const string deleteByIdSql = "DELETE FROM Product WHERE Id = @id";

                var command = new SqlCommand(deleteByIdSql, connection);
                command.Parameters.AddWithValue("id", id);

                var success = command.ExecuteNonQuery() > 0;

                return success;
            }
        }
    }
}
