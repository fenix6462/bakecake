using BakeCake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BakeCake.Controllers.API
{
    public class ProductsController : ApiController
    {
        ApplicationDbContext _context;
        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET / api/products
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        // GET /api/products/1
        public Product GetProduct(string name)
        {
            var product = _context.Products.SingleOrDefault(r => r.Name == name);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }

        // POST /api/products
        [HttpPost]
        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        // DELETE /api/products/1
        [HttpDelete]
        public void DeleteProduct(string name)
        {
            var productInDb = _context.Products.SingleOrDefault(r => r.Name == name
                );
            if (productInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Products.Remove(productInDb);
            _context.SaveChanges();
        }

        // PUT /api/products/1
        [HttpPut]
        public Product EditProduct(string name, Product product)
        {
            var productInDb = _context.Products.SingleOrDefault(r => r.Name == name);

            if (productInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            productInDb.Name = product.Name;
            productInDb.Price = product.Price;
            productInDb.Weight = product.Weight;

            _context.SaveChanges();

            return product;
        }
    }
}
