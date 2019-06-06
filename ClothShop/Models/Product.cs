using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClothShop.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int BrandId { get; set; }

        public ICollection<Picture> Pictures { get; set; }
    }
}
