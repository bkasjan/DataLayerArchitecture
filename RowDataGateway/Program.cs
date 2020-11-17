using System;
using RowDataGateway.Finders;

namespace RowDataGateway
{
    class Program
    {
        #region connection string

        public const string ConnectionString = "data source=L1078\\MSSQL2017;initial catalog=DemoDB;integrated security=SSPI;MultipleActiveResultSets=True;App=EntityFramework";

        #endregion

        static void Main(string[] args)
        {
            var productFinder = new ProductFinder(ConnectionString);
            var product = productFinder.FindById(1);

            product.Name = "New name";
            product.Update();

            var product2 = productFinder.FindById(1);
            Console.WriteLine($"Product name: {product2.Name}");
        }
    }
}
