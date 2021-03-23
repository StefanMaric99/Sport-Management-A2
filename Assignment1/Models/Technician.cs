using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "A name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "An email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A phone number is required.")]
        public string Phone { get; set; }
    }
}
