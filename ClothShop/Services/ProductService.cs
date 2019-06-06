using ClothShop.Interface;
using ClothShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothShop.Services
{
    public class ProductService : IProductService
    {
        IRepository<Product> repository;
        public ProductService(IRepository<Product> rep)
        {
            repository = rep;
        }

        public IEnumerable<Product> ChooseByBrand(int[] brandsId)
        {
            var products = repository.GetAll();
            return products.Where(p => brandsId.Contains(p.BrandId));
        }

        public void Create(Product product)
        {
            repository.Create(product);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void Edit(Product product)
        {
            repository.Update(product);
        }

        public Product GetProduct(int id)
        {
            return repository.GetOne(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return repository.GetAll();
        }

        public IEnumerable<Product> SortByPrice(int from, int to)
        {
            var products = repository.GetAll();
            return products.Where(p => p.Price >= from && p.Price <= to);
        }
        
    }
}
