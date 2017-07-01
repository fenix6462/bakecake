using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeCake.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<RecipeProducts> RecipeProducts { get; set; }

        public Recipe()
        {
            Products = new List<Product>();
            RecipeProducts = new List<RecipeProducts>();
        }

    }
}