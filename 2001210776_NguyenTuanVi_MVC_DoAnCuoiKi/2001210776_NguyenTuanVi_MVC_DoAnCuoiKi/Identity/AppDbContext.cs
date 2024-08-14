using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Identity
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext() : base("Db_StoreMilkTeaEntities")
        {

        }
    }
}