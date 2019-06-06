using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClothShop.Models
{
    [Table("Picture")]
    public class Picture
    {
        public int Id { get; set; }

        public string Name { get; set; } // название картинки

        public string Url { get; set; }

    }
}
