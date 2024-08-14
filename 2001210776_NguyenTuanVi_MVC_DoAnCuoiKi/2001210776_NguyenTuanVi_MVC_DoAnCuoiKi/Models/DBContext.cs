using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Models;

namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Models
{
    public class DBContext: DbContext
    {
        public DBContext() : base("Db_StoreMilkTeaEntities")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}