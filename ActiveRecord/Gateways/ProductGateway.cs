using System;
using Microsoft.Data.SqlClient;
using RowDataGateway.Gateways.Interfaces;

namespace ActiveRecord.Gateways
{
    /// <summary>
    ///     Active Record pattern example.
    ///     Using plain SQL
    /// </summary>
    public class ProductGateway : IProductGateway
    {
        #region "Additional logic we have added to previous Row Data Gateway"

        public double PriceWithDiscount(double percentDiscount)
            => Price * (1.0 - (percentDiscount / 100.0));

        public double PriceConvertToUsd()
        {
            // some service
            var eurToUsd = 1.2;
            return Price * eurToUsd;
        }

        #endregion

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int? OrderId { get; set; }
        private readonly string _connectionString;

        public ProductGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Insert()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"INSERT INTO Product(name, price) OUTPUT Inserted.Id VALUES (@name, @price)", connection);
                command.Parameters.AddWithValue("name", Name);
                command.Parameters.AddWithValue("price", Price);

                Id = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Update()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand("UPDATE Product SET Name = @name, Price = @price WHERE Id = @id", connection);
                command.Parameters.AddWithValue("name", Name);
                command.Parameters.AddWithValue("price", Price);
                command.Parameters.AddWithValue("id", Id);

                command.ExecuteNonQuery();
            }
        }

        public bool Delete()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"DELETE FROM Product WHERE Id = @id", connection);
                command.Parameters.AddWithValue("id", Id);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
