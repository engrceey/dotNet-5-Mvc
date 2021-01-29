using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BHRUGEN_MVC.Models
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public IFormFile DisplayPicture { get; set; }
    }
}