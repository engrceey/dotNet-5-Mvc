using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace BHRUGEN_MVC.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [Remote("EmailValidation", "Account", ErrorMessage = "{0} already has an account, please enter a different email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password does not match.")]
        public string ConfirmPassword { get; set; }
    }
}