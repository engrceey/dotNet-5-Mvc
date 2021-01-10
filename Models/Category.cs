using System.ComponentModel.DataAnnotations;

namespace BHRUGEN_MVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Order must be greater than 0")]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }
    }
}