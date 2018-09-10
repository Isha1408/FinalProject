using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "This field is REQIURED")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is REQIURED")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "This field is REQIURED")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "This field is REQIURED")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "This field is REQIURED")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is REQIURED")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm your Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "This field is REQIURED")]
        public string Roles { get; set; }

        public int RoleId { get; set; }

        public Course Courses { get; set; }

    }

    public enum Course
    {
        BE,
        BTech,
        MBA,
        Other
    }
}