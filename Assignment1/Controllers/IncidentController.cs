using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    public class IncidentController : Controller
    {
        private SportingContext context { get; set; }

        public IncidentController(SportingContext ctx)
        {
            context = ctx;
        }
        public IActionResult List()
        {
            // Returns list of incidents ordered by title
            var incidents = context.Incidents
                .Include(c => c.Customer)
                .Include(p => p.Product)
                .Include(t => t.Technician)
                .OrderBy(context => context.Title).ToList();
            return View(incidents);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Message"] = "incidents page";
            ViewBag.Action = "Add";
            ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
            ViewBag.Products = context.Product.OrderBy(p => p.Name).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();
            return View("Edit", new Incident());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
            ViewBag.Products = context.Product.OrderBy(p => p.Name).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();
            var incident = context.Incidents.Include(c => c.Customer).Include(p => p.Product).Include(t =>t.Technician).FirstOrDefault(c => c.IncidentId == id);
            return View(incident);
        }
        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            string action = (incident.IncidentId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {

                    context.Incidents.Add(incident);
                }
                else
                {
                    context.Incidents.Update(incident);
                }
                context.SaveChanges();
                return RedirectToAction("List", "Incident");
            }

            else
            {
                ViewBag.Action = action;
                ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
                ViewBag.Products = context.Product.OrderBy(p => p.Name).ToList();
                ViewBag.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();
                return View(incident);
            }

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Incidents.Include(c => c.Customer).Include(p => p.Product).Include(t => t.Technician).FirstOrDefault(c => c.IncidentId == id);
            return View(incident);
        }
        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("List", "Incident");
        }

    }
}
