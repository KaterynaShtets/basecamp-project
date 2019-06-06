using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothShop.Interface;
using ClothShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClothShop.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartService service;
        private readonly IProductService productService;
        private readonly UserManager<IdentityUser> _userManager;

        public CartsController(ICartService _service, UserManager<IdentityUser> userManager, IProductService _productService)
        {
            productService = _productService;
            service = _service;
            _userManager = userManager;
        }

        // GET: Carts
        public ActionResult Index()
        {
            return View(service.GetCart(HttpContext.User.Identity.Name));
        }

        public async Task<IActionResult> AddItem(int id,int count)
        {
            var item = new CartItem() { Product = productService.GetProduct(id), Count = count };
            service.AddCartItem(item, await _userManager.GetUserAsync(HttpContext.User));
            return RedirectToAction("Index");
        }

        // GET: Carts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Carts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Carts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Carts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}