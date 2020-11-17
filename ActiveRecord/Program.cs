using System;
using ActiveRecord.Finders;

namespace ActiveRecord
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

            Console.WriteLine($"Product price: {product.Price}, after discount: {product.PriceWithDiscount(10.0)}, USD: {product.PriceConvertToUsd()}");
        }
    }
}
