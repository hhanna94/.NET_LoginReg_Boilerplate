using System.ComponentModel.DataAnnotations;

namespace LoginReg.Models

{
    public class User
    {
        [Required]
        [Display(Name="First Name")]
        public string FirstName {get;set;}

        [Required]
        [Display(Name="Last Name")]
        public string LastName {get;set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        [Required]
        [Display(Name="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords must match.")]
        public string ConfirmPassword {get;set;}

        [Required]
        [EmailAddress]
        public string Email {get;set;}
        
    }
}