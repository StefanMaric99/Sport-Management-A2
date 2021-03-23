using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    public class ProductController : Controller
    {
        private SportingContext context { get; set; }
        public ProductController(SportingContext ctx)
        {
            context = ctx;
        }
        public IActionResult List()
        {
            // Returns list of products ordered by first name
            var products = context.Product
                .OrderBy(context => context.Name).ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Message"] = "product page";
            ViewBag.Action = "Add";
            return View("Edit", new Product());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var product = context.Product.FirstOrDefault(c => c.ProductId == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            string action = (product.ProductId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {

                    context.Product.Add(product);
                }
                else
                {
                    context.Product.Update(product);
                }
                context.SaveChanges();
                return RedirectToAction("List", "Product");
            }

            else
            {
                ViewBag.Action = action;
                return View(product);
            }

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Product.FirstOrDefault(c => c.ProductId == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Product.Remove(product);
            context.SaveChanges();
            return RedirectToAction("List", "Product");
        }
    }
}
