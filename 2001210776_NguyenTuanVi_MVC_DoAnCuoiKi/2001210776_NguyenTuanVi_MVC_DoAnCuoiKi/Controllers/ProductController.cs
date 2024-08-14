using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Models;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Filters;

namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        DBContext db = new DBContext();
        public ActionResult Index(string sortOder, int page = 1, string search = "")
        {
            List<Product> products = db.Products.ToList();
            ViewBag.Category = db.Categories.ToList();
            //Search
            products = db.Products.Where(row => row.Name_Product.Contains(search)).ToList();
            ViewBag.Search = search;

            //Sort
            ViewBag.SortColumn = sortOder;
            switch (sortOder)
            {
                case "name":
                    products = products.OrderBy(row => row.Name_Product).ToList();
                    break;
                case "price":
                    products = products.OrderByDescending(row => row.Price).ToList();
                    break;
                default:
                    products = products.OrderBy(row => row.ID_Product).ToList();
                    break;
            }

            //Paging
            int NumoofReacordPerPage = 6;
            int NoofPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NumoofReacordPerPage)));
            int NoofRecordSkip = (page - 1) * NumoofReacordPerPage;
            ViewBag.Page = page;
            ViewBag.NoofPages = NoofPages;
            products = products.Skip(NoofRecordSkip).Take(NumoofReacordPerPage).ToList();

            
            return View(products);
        }
        public ActionResult ProductCategory(int Id)
        {
            List<Product> product = db.Products.Where(x => x.ID_Category == Id).ToList();
            ViewBag.Category = db.Categories.ToList();
            return View(product);
        }
        [MyAuthenFilters]
        public ActionResult Detail(int id)
        {
            Product pro = db.Products.Where(x => x.ID_Product == id).FirstOrDefault();
            return View(pro);
        }
    }
}