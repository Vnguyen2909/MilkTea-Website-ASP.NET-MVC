using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Models;

namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DBContext db = new DBContext();
        public ActionResult Index(bool hot = true)
        {
            List<Product> product = db.Products.Where(x => x.hot == hot).ToList();
            return View(product);
        }
    }
}