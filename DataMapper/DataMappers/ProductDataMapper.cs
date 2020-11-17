using DataMapper.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;
using DataMapper.DataMappers.Interfaces;

namespace DataMapper.DataMappers
{
    public class ProductDataMapper : IDataMapper<Product>
    {

        private readonly string _connectionString;

        public ProductDataMapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Product> GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand(@"SELECT * FROM Product WHERE Id = @id", connection);
                command.Parameters.AddWithValue("id", id);

                var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new Product
                    {
                        Id = id,
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Price = reader.GetDouble(reader.GetOrdinal("Price"))
                    };
                }

                return null;
            }
        }

        public async Task<Product> Create(Product entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand(@"INSERT INTO Product(name, price) OUTPUT Inserted.Id VALUES (@name, @price)", connection);
                command.Parameters.AddWithValue("name", entity.Name);
                command.Parameters.AddWithValue("price", entity.Price);

                var id = Convert.ToInt32(await command.ExecuteScalarAsync());
                entity.Id = id;

                return entity;
            }
        }

        public async Task<Product> Update(int id, Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
