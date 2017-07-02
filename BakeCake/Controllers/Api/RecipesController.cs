using BakeCake.Models;
using BakeCake.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BakeCake.Controllers.API
{
    public class RecipesController : ApiController
    {
        ApplicationDbContext _context;

        public RecipesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/recipes
        public IEnumerable<Recipe> GetRecipes()
        {
            return _context.Recipes.ToList();
        }

        // GET /api/recipes/1
        public Recipe GetRecipe(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(r => r.Id == id);
            if(recipe == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return recipe;
        }

        // POST /api/recipes
        [HttpPost]
        public Recipe CreateRecipe(CreateRecipeViewModel recipe)
        {
            Recipe entity = new Recipe();
            entity.Name = recipe.Name;
            entity.Description = recipe.Name;

            foreach (RecipeProductViewModel recipeProduct in recipe.RecipeProducts)
            {
                Product product = _context.Products.FirstOrDefault(x => x.Name == recipeProduct.Name);
                if (product != null)
                {
                    entity.RecipeProducts.Add(new RecipeProducts
                    {
                        Product = product,
                        Weight = recipeProduct.Weight
                    });
                }
            }

            _context.Recipes.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        // DELETE /api/recipes/1
        [HttpDelete]
        public void DeleteRecipe(int id)
        {
            var recipeInDb = _context.Recipes.SingleOrDefault(r => r.Id == id);
            if(recipeInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Recipes.Remove(recipeInDb);
            _context.SaveChanges();
        }

        // PUT /api/recipes/1
        [HttpPut]
        public void EditRecipe(int id, Recipe recipe)
        {
            var recipeInDb = _context.Recipes.SingleOrDefault(r => r.Id == id);

            if(recipeInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            recipeInDb.Name = recipe.Name;
            recipeInDb.Description = recipe.Description;
            recipeInDb.RecipeProducts = recipe.RecipeProducts;

            _context.SaveChanges();
        }
    }
}
