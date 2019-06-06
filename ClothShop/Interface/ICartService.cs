using ClothShop.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothShop.Interface
{
    public interface ICartService
    {
        Cart GetCart(string userName);
        void AddCartItem(CartItem cartItem, IdentityUser user);
    }
}
