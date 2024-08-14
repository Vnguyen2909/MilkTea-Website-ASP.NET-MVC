using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Models;
using System.Net;
using System.Data.Entity;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Filters;

namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class CategoryAdminController : Controller
    {
        // GET: Admin/CategoryAdmin
        DBContext db = new DBContext();
        public ActionResult Index(string search = "")
        {
            //Search
            List<Category> categories = db.Categories.Where(row => row.Name_Category.Contains(search)).ToList();
            ViewBag.Search = search;
            return View(categories);
        }
        public ActionResult Detail(int id)
        {
            Category category = db.Categories.Where(row => row.ID_Category == id).FirstOrDefault();
            return View(category);
        }
        public ActionResult List_Product(int id)
        {
            List<Product> products = db.Products.Where(x => x.ID_Category == id).ToList();
            return View(products);
        }
    }
}