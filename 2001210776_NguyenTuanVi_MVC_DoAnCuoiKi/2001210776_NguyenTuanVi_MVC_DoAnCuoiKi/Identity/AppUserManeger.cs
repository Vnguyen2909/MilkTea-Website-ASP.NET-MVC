using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Identity
{
    public class AppUserManeger : UserManager<AppUser>
    {
        public AppUserManeger(IUserStore<AppUser> store) : base(store)
        {

        }
    }
}