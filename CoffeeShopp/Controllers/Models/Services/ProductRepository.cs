using CoffeeShopp.Data;
using CoffeeShopp.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShopp.Models.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly CoffeeShopDbContext dbContext;

        public ProductRepository(CoffeeShopDbContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public void AddProduct(Product product)
        {
            dbContext.Product.Add(product);
            dbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = dbContext.Product.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                dbContext.Product.Remove(product);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return dbContext.Product.ToList();
        }

        public Product GetProductDetail(int id)
        {
            return dbContext.Product.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetTrendingProducts()
        {
            return dbContext.Product.Where(p => p.IsTrendingProduct).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = dbContext.Product.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Detail = product.Detail;
                existingProduct.Price = product.Price;
                existingProduct.ImageUrl = product.ImageUrl;
                existingProduct.IsTrendingProduct = product.IsTrendingProduct;

                dbContext.SaveChanges();
            }
        }
    }
}
