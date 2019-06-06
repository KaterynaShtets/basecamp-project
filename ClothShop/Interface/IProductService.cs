using ClothShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothShop.Interface
{
   public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        IEnumerable<Product> SortByPrice(int from, int to);
        IEnumerable<Product> ChooseByBrand(int[] brandsId);
        void Create(Product product);
        void Edit(Product product);
        void Delete(int id);
    }
}
