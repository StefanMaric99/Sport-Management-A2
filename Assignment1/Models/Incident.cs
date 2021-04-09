using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required(ErrorMessage = "Please enter a valid ProductId")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter a valid Title")]
        [StringLength(21, ErrorMessage = "Only 1-21 characters are allowed")]
        
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a Description")]
        [StringLength(200, ErrorMessage = "Only a maximum of 200 characters are allowed")]
        public string Description { get; set; }

        [Display(Name = "Technician")]
        [ForeignKey("TechnicianId")] // Specifies that this instance of technician matches the technicianId property
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
