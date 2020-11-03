﻿using System.ComponentModel.DataAnnotations;

namespace SoftwareArchitecture.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
