using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftwareArchitecture.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
