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
        [StringLength(21, ErrorMessage = "Only 1-21 characters are allowed")]
        public string Name { get; set; }
        [Required(ErrorMessage = "An email is required.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(21, ErrorMessage = "Only 1-21 characters are allowed")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A phone number is required.")]
        [Phone(ErrorMessage = "Phone number must be in (999)999-9999 format.")]
        public string Phone { get; set; }
    }
}
