using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Models
{
    public class Category
    {
        [Key]
        public int ID_Category { get; set; }
        public string Name_Category { get; set; }
    }
}