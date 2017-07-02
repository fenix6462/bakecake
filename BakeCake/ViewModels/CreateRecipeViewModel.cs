using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeCake.ViewModels
{
    public class CreateRecipeViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<RecipeProductViewModel> RecipeProducts { get; set; }
        
        public CreateRecipeViewModel()
        {
            RecipeProducts = new List<RecipeProductViewModel>();
        }

        public class RecipeProductViewModel
        {
            public string Name { get; set; }
            public float Weight { get; set; }
        }
    }
}