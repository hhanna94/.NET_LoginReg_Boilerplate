using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginReg.Models

{
    public class User
    {
        [Key]
        public int Id {get;set;}
        
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

        [NotMapped]
        [Required]
        [Display(Name="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords must match.")]
        public string ConfirmPassword {get;set;}

        [Required]
        [EmailAddress]
        public string Email {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        
    }
}