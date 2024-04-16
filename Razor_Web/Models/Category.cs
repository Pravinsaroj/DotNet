using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Razor_Web.Models
{
    public class Category 
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Its Required to Enter Name")]
        [MaxLength(20, ErrorMessage = "Maximum length is 20 only")]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display order must be between 1 to 100")]
        public int DisplayOrder { get; set; }
    }
}
