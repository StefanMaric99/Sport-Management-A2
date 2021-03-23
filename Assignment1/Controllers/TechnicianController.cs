using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    public class TechnicianController : Controller
    {
        private SportingContext context { get; set; }

        public TechnicianController(SportingContext ctx)
        {
            context = ctx;
        }
        public IActionResult List()
        {
            // Returns list of technitians ordered by first name
            var technitians = context.Technicians
                .OrderBy(context => context.Name).ToList();
            return View(technitians);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Message"] = "product page";
            ViewBag.Action = "Add";
            return View("Edit", new Technician());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var technician = context.Technicians.FirstOrDefault(c => c.TechnicianId == id);
            return View(technician);
        }
            [HttpPost]
            public IActionResult Edit(Technician technician)
            {
                string action = (technician.TechnicianId == 0) ? "Add" : "Edit";

                if (ModelState.IsValid)
                {
                    if (action == "Add")
                    {

                        context.Technicians.Add(technician);
                    }
                    else
                    {
                        context.Technicians.Update(technician);
                    }
                    context.SaveChanges();
                    return RedirectToAction("List", "Technician");
                }

                else
                {
                    ViewBag.Action = action;
                    return View(technician);
                }

            }
            [HttpGet]
            public IActionResult Delete(int id)
            {
                var technician = context.Technicians.FirstOrDefault(c => c.TechnicianId == id);
                return View(technician);
            }
            [HttpPost]
            public IActionResult Delete(Technician technician)
            {
                context.Technicians.Remove(technician);
                context.SaveChanges();
                return RedirectToAction("List", "Technician");
            }
        }
}

