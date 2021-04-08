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
        public string Code { get; set; }
        [Required(ErrorMessage = "A name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A price is required.")]
        [Display(Name = "Yearly Price")]
        public double YearlyPrice { get; set; }

        [Required(ErrorMessage = "A date is required.")]
        [Display(Name = "Release Date")]
  
        public DateTime ReleaseDate { get; set; }

        public string Slug => Name?.Replace(" ", "-").ToLower();
    }
}
