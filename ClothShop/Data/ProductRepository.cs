using ClothShop.Interface;
using ClothShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothShop.Data
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            var products = _context.Products.Include(p=>p.Pictures);
            return products;
        }

        public Product GetOne(int id)
        {
            var product = _context.Products.Where(p => p.Id == id).Include(p=>p.Pictures).FirstOrDefault();
            return product;
        }

        public void Create(Product item)
        {
            _context.Products.Add(item);
            Save();
        }

        public void Update(Product item)
        {
            _context.Products.Update(item);
            Save();
        }

        public void Delete(int id)
        {
            var forDel = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            _context.Products.Remove(forDel);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

       
    }
}
