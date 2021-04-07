using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class IncidentsViewModel
    {
        public string Action { get; set; }
        public string Filter { get; set; }

        // Current incident
        private Incident CurrentIncident;
        public Incident currentIncident
        {
            get => CurrentIncident;
            set => CurrentIncident = value;
        }

        private List<Incident> Incidents;
        public List<Incident> incidents
        {
            get => Incidents;
            set => Incidents = value;
        }

        private List<SelectListItem> Customers;
        public List<SelectListItem> customers
        {
            get => Customers;
            set => Customers = value;
        }

        private List<SelectListItem> Products;
        public List<SelectListItem> products
        {
            get => Products;
            set => Products = value;
        }

        private List<SelectListItem> Technicians;
        public List<SelectListItem> technicians
        {
            get => Technicians;
            set => Technicians = value;
        }

        // String for filtering

        public string FilterType(string f) => f.ToLower() == Filter.ToLower() ? "open" : "unassigned";

        // String that specifies whether the page is for add or edit
        public string CheckPageType(string p) => p.ToLower() == Action.ToLower() ? "add" : "edit";


    }
}
