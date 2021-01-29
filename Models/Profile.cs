using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BHRUGEN_MVC.Validations;
using Microsoft.AspNetCore.Http;

namespace BHRUGEN_MVC.Models
{
    public class Profile
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        // 1 MB
        [MaxFileSize(1* 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public string DisplayPicture { get; set; }
    }
}