using System;
using System.Collections.Generic;
using System.Text;

namespace DataMapper.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int? OrderId { get; set; }
    }
}
