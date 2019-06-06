using ClothShop.Models;
using ClothShop.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClothShop.Data
{
    public class CartRepository : IRepository<Cart>
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Cart item)
        {
            _context.Carts.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var p = _context.Carts.Where(c => c.Id == id).FirstOrDefault();
            _context.Carts.Remove(p);
            Save();
        }

        public IEnumerable<Cart> GetAll()
        {
            var carts = _context.Carts.Include(c => c.User).Include(i => i.CartItems).ThenInclude(p => p.Product).ThenInclude(pic => pic.Pictures);
            
            return carts;
        }

        public Cart GetOne(int id)
        {
            return _context.Carts.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Cart item)
        {
            _context.Carts.Update(item);
            Save();
        }
    }
}
