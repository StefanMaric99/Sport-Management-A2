using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class TechIncidentController : Controller
    {
        private SportingContext context { get; set; }

        public TechIncidentController(SportingContext ctx)
        {
            context = ctx;
        }

        public IActionResult GetTechnician(int id = -1)
        {
            if (id != -1)
            {
                return RedirectToAction();
            }

            List<SelectListItem> technicians = context.Technicians.ToList().ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Name,
                    Value = t.TechnicianId.ToString(),
                    Selected = false
                };
            });

            GetTechViewModel model = new GetTechViewModel();
            model.Technicians = technicians;
            return View(model);
        }

        [HttpPost]
        public IActionResult List(GetTechViewModel model)
        {
            if (model.TechnicianId != -1)
            {
                return RedirectToAction("List", "TechIncident", new { id = model.TechnicianId });
            }

            TempData["message"] = "Please select a valid Technician";
            TempData["indicator"] = "danger";
            return RedirectToAction("GetTechnician", "TechIncident");
        }

        public IActionResult List(int id)
        {
            Technician technician = context.Technicians.FirstOrDefault(t => t.TechnicianId == id);

            if (technician == null)
            {
                TempData["message"] = "Please select a valid Technician";
                TempData["indicator"] = "danger";
                return RedirectToAction("GetTechnician", "TechIncident");
            }

            List<Incident> techIncidents = context.Incidents
                                              .Include(c => c.Customer)
                                              .Include(p => p.Product)
                                              .Where(Incident => Incident.TechnicianId == id && Incident.DateClosed == null)
                                              .ToList();

            GetTechViewModel model = new GetTechViewModel();

            model.Technician = technician;
            model.Incidents = techIncidents;

            HttpContext.Session.SetInt32("TechnicianId", id);

            return View(model);
        }

        [HttpGet]
        public IActionResult EditIncident(int id)
        {
            if (!HttpContext.Session.GetInt32("TechnicianId").HasValue)
            {
                TempData["message"] = "Please select a valid Technician";
                TempData["indicator"] = "danger";
                return RedirectToAction("GetTechnician", "TechIncident");
            }

            Incident incident = context.Incidents
                                   .Include(t => t.Technician)
                                   .Include(c => c.Customer)
                                   .Include(p => p.Product)
                                   .FirstOrDefault(i => i.IncidentId == id);

            int? TechnicianId = HttpContext.Session.GetInt32("TechnicianId");
            if (incident == null)
            {
                TempData["message"] = "Please select a valid Incident";
                TempData["indicator"] = "danger";
                return RedirectToAction("List", "TechIncident", new { id = TechnicianId });
            }

            if (incident.TechnicianId != TechnicianId)
            {
                TempData["message"] = "This incident does not belong to selected technician.";
                TempData["indicator"] = "danger";
                return RedirectToAction("List", "TechIncident", new { id = TechnicianId });
            }

            return View("Edit", incident);
        }

        [HttpPost]
        public IActionResult EditIncident(Incident incident)
        {
            int? id = HttpContext.Session.GetInt32("TechnicianId");

            if (ModelState.IsValid)
            {
                context.Incidents.Update(incident);
                context.SaveChanges();
                if (id.HasValue)
                {
                    return RedirectToAction("List", "TechIncident", new { id });
                }
                else
                {
                    TempData["message"] = "Session cleared for safety concerns. Please select again.";
                    TempData["indicator"] = "warning";
                    return RedirectToAction("GetTechnician", "TechIncident");
                }
            }

            if (!HttpContext.Session.GetInt32("TechnicianId").HasValue)
            {
                TempData["message"] = "Please select a valid Technician";
                TempData["indicator"] = "danger";
                return RedirectToAction("GetTechnician", "TechIncident");
            }

            if (incident == null)
            {
                TempData["message"] = "Please select a valid Incident";
                TempData["indicator"] = "danger";
                return RedirectToAction("List", "TechIncident", new { id });
            }

            if (incident.TechnicianId != id)
            {
                TempData["message"] = "This incident does not belong to selected technician.";
                TempData["indicator"] = "danger";
                return RedirectToAction("List", "TechIncident", new { id });
            }

            return View("Edit", incident);
        }
    }
}
