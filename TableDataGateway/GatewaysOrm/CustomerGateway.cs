using System.Collections.Generic;
using System.Linq;
using SoftwareArchitecture.Data.Data;
using SoftwareArchitecture.Data.Models;
using TableDataGateway.GatewaysOrm.Interfaces;

namespace TableDataGateway.GatewaysOrm
{
    /// <summary>
    ///     Table Data Gateway pattern example.
    ///     Using ORM
    /// </summary>
    public class CustomerGateway : IDataGateway<Customer>
    {
        private readonly DemoContext _context;
        public CustomerGateway(DemoContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> SelectAll() => 
            _context.Customers.ToList();

        public Customer SelectById(int? id) => 
            _context.Customers.Find(id);

        public void Save() =>
            _context.SaveChanges();

        public void Insert(Customer customer)
        {
            _context.Customers.Add(customer);
            Save();
        }

        public void Update(Customer customer)
        {
            _context.Customers.Remove(customer);
            Save();
        }

        public Customer Delete(int? id)
        {
            var customer = SelectById(id);
            _context.Customers.Remove(customer);
            Save();
            return customer;
        }
    }
}
