using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "A code is required.")]
        [StringLength(21, ErrorMessage = "Only 1-21 characters are allowed")]
        public string Code { get; set; }
        [Required(ErrorMessage = "A name is required.")]
        [StringLength(21, ErrorMessage = "Only 1-21 characters are allowed")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A price is required.")]
        [Display(Name = "Yearly Price")]
        [Range(1, 100000)]
        public double YearlyPrice { get; set; }

        [Required(ErrorMessage = "A date is required.")]
        [Display(Name = "Release Date")]
  
        public DateTime ReleaseDate { get; set; }

        public string Slug => Name?.Replace(" ", "-").ToLower();
    }
}
