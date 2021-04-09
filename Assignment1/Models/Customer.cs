
using System.ComponentModel.DataAnnotations;


namespace Assignment1.Models
{
    public class Customer
    {
        [Required]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter a valid first name")]
        [StringLength(21, ErrorMessage = "Only 1-21 characters are allowed")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a valid last name")]
        [StringLength(21, ErrorMessage = "Only 1-21 characters are allowed")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a valid address")]
        [StringLength(21, ErrorMessage = "Only 1-21 characters are allowed")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a valid city")]
        [StringLength(21, ErrorMessage = "Only 1-21 characters are allowed")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a valid state")]
        [StringLength(21, ErrorMessage = "Only 1-21 characters are allowed")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a valid postal code")]
        [StringLength(21, ErrorMessage = "Only 1-21 characters are allowed")]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY, a-z]{1}\\d{1}[A-Z,a-z]{1} *\\d{1}[A-Z,a-z]{1}\\d{1}$)", ErrorMessage = "Zip code is invalid.")]
        public string PostalCode { get; set; }

        [Required]
        public int CountryId { get; set; }


        public Country Country { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(21, ErrorMessage = "Only 1-21 characters are allowed")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Phone number must be in (999)999-9999 format.")]
        public string? Phone { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
