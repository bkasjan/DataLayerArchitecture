using System;
using DataMapper.DataMappers;
using DataMapper.Models;

namespace DataMapper
{
    class Program
    {
        #region connection string

        public const string ConnectionString = "data source=L1078\\MSSQL2017;initial catalog=DemoDB;integrated security=SSPI;MultipleActiveResultSets=True;App=EntityFramework";

        #endregion

        static void Main(string[] args)
        {
            var productMapper = 
                new ProductDataMapper(ConnectionString);

            var product = productMapper
                .Create(new Product
                {
                    Name = "Product 10", 
                    Price = 8.99
                }).Result;

            var product2 = productMapper
                .GetById(1).Result;

            Console.WriteLine($"Product name: {product.Name}");
            Console.WriteLine($"Product 2 name: {product2.Name}");
        }
    }
}
