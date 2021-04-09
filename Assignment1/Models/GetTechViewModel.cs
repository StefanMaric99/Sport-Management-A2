using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class GetTechViewModel
    {

        private List<SelectListItem> technicians;
        private int technicianId = -1;
        private Technician technician;

        private List<Incident> incidents = new List<Incident>();

        public List<Incident> Incidents
        {
            get => incidents;
            set => incidents = value;
        }

        public List<SelectListItem> Technicians
        {
            get => technicians;
            set => technicians = value;
        }

        public int TechnicianId
        {
            get => technicianId;
            set => technicianId = value;
        }

        public Technician Technician
        {
            get => technician;
            set => technician = value;
        }
    }
}
