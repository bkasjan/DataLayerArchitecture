using System;
using System.Data;
using SoftwareArchitecture.Data.Data;
using TableDataGateway.GatewaysOrm;
using TableDataGateway.GatewaysSql;

namespace TableDataGateway
{
    class Program
    {
        #region connection string

        public const string ConnectionString = "data source=L1078\\MSSQL2017;initial catalog=DemoDB;integrated security=SSPI;MultipleActiveResultSets=True;App=EntityFramework";

        #endregion

        static void Main(string[] args)
        {
            // Usage - no ORM or Mapper for DTO example
            var productGateway = new ProductGateway(ConnectionString);
            var product = productGateway.GetById(1);
            var success = productGateway.DeleteById(2);

            foreach (DataRow row in product.Rows)
            {
                Console.WriteLine($"{row["ID"]} {row["name"]}");
            }

            Console.WriteLine($"Is row deleted: {success}");

            // Usage - with ORM
            var customerGateway = new CustomerGateway(new DemoContext());
            var customer = customerGateway.SelectById(1);

            Console.WriteLine($"Customer last name: {customer.LastName}");
        }
    }
}
