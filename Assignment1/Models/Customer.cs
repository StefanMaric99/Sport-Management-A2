
using System.ComponentModel.DataAnnotations;


namespace Assignment1.Models
{
    public class Customer
    {
        [Required]
        public int CustomerId { get; set; }
        

        [Required(ErrorMessage = "Please enter a valid first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a valid last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a valid address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a valid city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a valid state")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a valid postal code")]
        public string PostalCode { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
