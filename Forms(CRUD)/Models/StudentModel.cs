using System.ComponentModel.DataAnnotations;

namespace Forms_CRUD_.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Required   (ErrorMessage ="Bhai yeh fill karna zarori hain !")]
        public  string Name { get; set; } = string.Empty;

        [Required (ErrorMessage = "Bhai yeh fill karna zarori hain")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bhai yeh fill karna zarori hain")]
        public string Description { get; set; } = string.Empty;
        public string PhotoPath { get; set; }
      
    }
}
