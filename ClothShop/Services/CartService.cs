using ClothShop.Interface;
using ClothShop.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace ClothShop.Services
{
    public class CartService : ICartService
    {
        IRepository<Cart> repository;
        UserManager<IdentityUser> _userManager;

        public CartService(IRepository<Cart> rep, UserManager<IdentityUser> userManager)
        {
            repository = rep;
            _userManager = userManager;
        }

        public void AddCartItem(CartItem cartItem, IdentityUser user)

        {
            var cart = GetCart(user.UserName);
            if (cart == null)
            {
                cart = new Cart() { User = user, CartItems = new List<CartItem>()  };
            }
            else
            {
                if(cart.CartItems == null)
                {
                    cart.CartItems = new List<CartItem>();
                }
            }
            cart.CartItems.Add(cartItem);
            repository.Update(cart);
           
        }

        public Cart GetCart(string userName)
        {
            var cart = repository.GetAll().Where(c => c.User.UserName == userName).FirstOrDefault();
            return cart;
        }

    }
}
