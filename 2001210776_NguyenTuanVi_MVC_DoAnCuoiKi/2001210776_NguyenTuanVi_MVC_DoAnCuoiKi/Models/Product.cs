using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Models
{
    public class Product
    {
        [Key]
        public int ID_Product { get; set; }
        public int ID_Category { get; set; }
        public string Name_Product { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Price { get; set; }
        public int QuantityInventory  { get; set; }
        public string Images { get; set; }
        public string Status { get; set; }

        public bool hot { get; set; }
        public virtual Category Category { get; set; }
    }
}