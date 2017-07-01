using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeCake.Models
{
    public class RecipeProducts
    {
        public int Id { get; set; }
        public Recipe Recipe { get; set; }
        public Product Product { get; set; }
        public float Weight { get; set; }
    }
}  