using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Filters;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Identity;
using Microsoft.AspNet.Identity;

namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}