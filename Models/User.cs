//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
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
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is REQIURED")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm your Password")]
        public string ConfirmPassword { get; set; }
        public string Roles { get; set; }
        public string UserName { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string Courses { get; set; }
    }
}
