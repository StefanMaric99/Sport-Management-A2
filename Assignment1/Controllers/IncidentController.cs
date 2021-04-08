using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;



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
            IncidentsViewModel model = new IncidentsViewModel();
            List<Incident> incidents = new List<Incident>();

            IQueryable<Incident> incidentsQ = context.Incidents
                                                         .Include(i => i.Customer)
                                                         .Include(p => p.Product)
                                                         .Include(t => t.Technician);

            // add filtering

            incidents = incidentsQ.ToList();
            model.incidents = incidents;

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {

            List<SelectListItem> customers = context.Customers.ToList().ConvertAll(c => {
                return new SelectListItem()
                {
                    Text = c.FirstName + " " + c.LastName,
                    Value = c.CustomerId.ToString(),
                    Selected = false

                };
            });

            List<SelectListItem> products = context.Product.ToList().ConvertAll(p => {
                return new SelectListItem()
                {
                    Text = p.Name,
                    Value = p.ProductId.ToString(),
                    Selected = false

                };
            });

            List<SelectListItem> technicians = context.Technicians.ToList().ConvertAll(t => {
                return new SelectListItem()
                {
                    Text = t.Name,
                    Value = t.TechnicianId.ToString(),
                    Selected = false
                };
            });
            IncidentsViewModel model = new IncidentsViewModel
            {
                customers = customers,
                products = products,
                technicians = technicians,
                currentIncident = new Incident(),
                Action = "Edit"
        };
            


            return View("Edit", model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Incident incident = context.Incidents
                                  .Include(c => c.Customer)
                                  .Include(p => p.Product)
                                  .Include(t => t.Technician)
                                  .FirstOrDefault(i => i.IncidentId == id);

            IncidentsViewModel model = new IncidentsViewModel();


            List<SelectListItem> customers = context.Customers.ToList().ConvertAll(c => {
                return new SelectListItem()
                {
                    Text = c.FirstName + " " + c.LastName,
                    Value = c.CustomerId.ToString(),
                    Selected = false

                };
            });

            List<SelectListItem> products = context.Product.ToList().ConvertAll(p => {
                return new SelectListItem()
                {
                    Text = p.Name,
                    Value = p.ProductId.ToString(),
                    Selected = false

                };
            });

            List<SelectListItem> technicians = context.Technicians.ToList().ConvertAll(t => {
                return new SelectListItem()
                {
                    Text = t.Name,
                    Value = t.TechnicianId.ToString(),
                    Selected = false
                };
            });


            model.customers = customers;
            model.products = products;
            model.technicians = technicians;
            model.currentIncident = incident;
            model.Action = "Edit";

            return View("Edit", model);

        }
        [HttpPost]
        public IActionResult Edit(IncidentsViewModel model)

        {                     

            List<SelectListItem> customers = context.Customers.ToList().ConvertAll(c => {
                return new SelectListItem()
                {
                    Text = c.FirstName + " " + c.LastName,
                    Value = c.CustomerId.ToString(),
                    Selected = false

                };
            });

            List<SelectListItem> products = context.Product.ToList().ConvertAll(p => {
                return new SelectListItem()
                {
                    Text = p.Name,
                    Value = p.ProductId.ToString(),
                    Selected = false

                };
            });

            List<SelectListItem> technicians = context.Technicians.ToList().ConvertAll(t => {
                return new SelectListItem()
                {
                    Text = t.Name,
                    Value = t.TechnicianId.ToString(),
                    Selected = false
                };
            });

            
            model.customers = customers;
            model.products = products;
            model.technicians = technicians;
            model.Action = "Edit";
            if (ModelState.IsValid)
            {   
                if (model.Action == "Add")
                {
                    context.Incidents.Add(model.currentIncident);
                }
                else
                {
                    context.Incidents.Update(model.currentIncident);
                }
                context.SaveChanges();

                return RedirectToAction("List", "Incident");
            }
                return View("Edit", model);

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
