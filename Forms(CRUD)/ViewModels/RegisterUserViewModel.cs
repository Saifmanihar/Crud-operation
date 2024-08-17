using Forms_CRUD_.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace Forms_CRUD_.ViewModels
{
    public class RegisterUserViewModel 
    {
        [Required (ErrorMessage ="This is filled is required")]
        [EmailAddress]
        public  string Email { get; set; }

        [Required(ErrorMessage = "This is filled is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

       
        [DataType(DataType.Password)]
        [Display(Name = "Conform password")]
        [Compare ("Password", ErrorMessage ="Password and conform password not matched")]
        public string ConfirmPassword { get; set;}
    }
}
