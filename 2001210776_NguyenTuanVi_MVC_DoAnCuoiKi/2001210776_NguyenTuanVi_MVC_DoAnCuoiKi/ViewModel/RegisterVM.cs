using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Fullname cannotbe blank")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Username cannotbe blank")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannotbe blank")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password cannotbe blank")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ComfirmPassword { get; set; }
        [Required(ErrorMessage = "Email cannotbe blank")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime? Birthday { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}