using Microsoft.EntityFrameworkCore;
using SoftwareArchitecture.Data.Models;

namespace SoftwareArchitecture.Data.Data
{
    public class DemoContext : DbContext
    {
        #region connection string

        public const string ConnectionString =
            "data source=L1078\\MSSQL2017;initial catalog=DemoDB;integrated security=SSPI;MultipleActiveResultSets=True;App=EntityFramework";

        #endregion

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
        }
    }
}
