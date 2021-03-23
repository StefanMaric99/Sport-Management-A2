using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    public class CustomerController : Controller
    {
        private SportingContext context { get; set;}

        public CustomerController(SportingContext ctx)
        {
            context = ctx;
        }
        public IActionResult List()
        {
            // Returns list of customers ordered by first name
            var customers = context.Customers
                .Include(c => c.Country)
                .OrderBy(context => context.FirstName).ToList();
            return View(customers);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Message"] = "customers page";
            ViewBag.Action = "Add";
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            return View("Edit", new Customer());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();

            var customer = context.Customers.Include(c => c.Country).FirstOrDefault(c => c.CustomerId == id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            string action = (customer.CustomerId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
   
                    context.Customers.Add(customer);
                }
                else
                {
                    context.Customers.Update(customer);
                }
                context.SaveChanges();
                return RedirectToAction("List", "Customer");
            }

            else
            {
                ViewBag.Action = action;
                ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
                return View(customer);
            }

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers.Include(c => c.Country).FirstOrDefault(c => c.CustomerId == id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("List", "Customer");
        }
    }
}
