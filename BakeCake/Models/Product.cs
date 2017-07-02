using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BakeCake.Models
{
    public class Product
    {
        [Key]
        [MaxLength(100)]
        public string Name { get; set; }
        public float Weight { get; set; }
        public float Price { get; set; }
    }
}