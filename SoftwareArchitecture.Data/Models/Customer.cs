using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftwareArchitecture.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
