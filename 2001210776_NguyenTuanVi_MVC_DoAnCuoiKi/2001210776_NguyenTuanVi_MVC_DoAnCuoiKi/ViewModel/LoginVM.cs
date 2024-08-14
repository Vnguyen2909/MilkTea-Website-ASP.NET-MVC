using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username cannotbe blank")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannotbe blank")]
        public string Password { get; set; }
    }
}