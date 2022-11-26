using GraphQLCore.Data;
using GraphQLCore.Interfaces;
using GraphQLCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCore.Services
{
    public class ProductService : IProduct
    {
        private readonly GraphQLDbContext _dbContext;

        public ProductService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            var productobj = _dbContext.Products.Find(id);
            _dbContext.Products.Remove(productobj);
            _dbContext.SaveChanges();
            

        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Where(c => c.Id == id).FirstOrDefault();
        }

        public Product UpdateProduct(int id, Product product)
        {
            var productobj = _dbContext.Products.Find(id);
            productobj.Name = product.Name;
            productobj.Price = product.Price;
            _dbContext.SaveChanges();
            return product;
        }
    }
}
