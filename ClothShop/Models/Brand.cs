﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothShop.Models
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
