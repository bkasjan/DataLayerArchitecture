using System;
using System.Data;
using TableDataGateway.Gateways;

namespace TableDataGateway
{
    class Program
    {
        #region connection string

        public const string ConnectionString = "data source=L1078\\MSSQL2017;initial catalog=DemoDB;integrated security=SSPI;MultipleActiveResultSets=True;App=EntityFramework";

        #endregion

        static void Main(string[] args)
        {
            var productGateway = new ProductGateway(ConnectionString);
            var table = productGateway.GetByName("Water");
            var success = productGateway.DeleteById(2);


            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"{row["ID"]} {row["name"]}");
            }

            Console.WriteLine($"Is row deleted: {success}");
        }
    }
}
