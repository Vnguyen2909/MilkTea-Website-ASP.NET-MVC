using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Identity
{
    public class AppUser: IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime? Birthday { get; set; }
        public string ImgUrl { get; set; }
    }
}