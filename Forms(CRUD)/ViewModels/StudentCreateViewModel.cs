using Forms_CRUD_.Models;
using System.ComponentModel.DataAnnotations;

namespace Forms_CRUD_.ViewModels
{
    public class StudentCreateViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        //public StudentModel Student { get; set; }

        //[Required(ErrorMessage = "Bhai yeh fill karna zarori hain")]
        public List<IFormFile> Photo { get; set; }
    }
}
