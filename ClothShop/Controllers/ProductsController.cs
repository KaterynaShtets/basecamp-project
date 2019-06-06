using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClothShop.Data;
using ClothShop.Models;
using Microsoft.AspNetCore.Authorization;
using ClothShop.Interface;

namespace ClothShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService service;

        public ProductsController(IProductService _service)
        {
            service = _service;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(service.GetProducts());
        }

        public IActionResult SortByPrice(int from, int to)
        {
            var products = service.SortByPrice(from, to);
            return View("Index", products);
        }
        public IActionResult ChooseByBrand(int[]  brandsId)
        {
            var products = service.ChooseByBrand(brandsId);
            return View("Index", products);
        }
        // GET: Products/Details/5
        public IActionResult Details(int id)
        {
            var product = service.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Price,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                service.Create(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {

            var product = service.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id, [Bind("Id,Name,Price,Description")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            service.Edit(product);
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "admin")]
        public  IActionResult Delete(int id)
        {
            service.Delete(id);         
            return View();
        }

        //private async Task GetBrands()
        //{
        //    ViewBag.Brands = await _context.Brands.ToListAsync();
        //}
    }
}
