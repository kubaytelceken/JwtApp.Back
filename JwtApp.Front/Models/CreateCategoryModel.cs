using System.ComponentModel.DataAnnotations;

namespace JwtApp.Front.Models
{
    public class CreateCategoryModel
    {
        [Required(ErrorMessage = "Category Definition is Required.")]
        public string? Definition { get; set; }
    }
}
