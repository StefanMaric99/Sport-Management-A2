using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        [Required]
        public int ProductId { get; set; }
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Display(Name = "Technician")]
        public Technician Technician { get; set; }
        public int? TechnicianId { get; set; }

        [Display(Name = "Date Opened")]
        [DataType(DataType.Date)]
        public DateTime? DateOpened { get; set; }

        [Display(Name = "Date Closed")]
        [DataType(DataType.Date)]
        public DateTime? DateClosed { get; set; }
    }
}
