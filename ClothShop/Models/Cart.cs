using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothShop.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public IdentityUser User { get; set; }
    }
}
