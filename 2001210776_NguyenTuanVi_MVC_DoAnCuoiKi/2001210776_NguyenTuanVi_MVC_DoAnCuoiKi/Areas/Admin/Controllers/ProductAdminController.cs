using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Models;
using System.IO;
using System.Net;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Filters;

namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProductAdminController : Controller
    {
        // GET: Admin/ProductAdmin
        DBContext db = new DBContext();
        public ActionResult Index(string search = "", int page = 1)
        {
            //Search
            List<Product> products = db.Products.Where(row => row.Name_Product.Contains(search)).ToList();
            ViewBag.Search = search;

            //Paging
            int NumoofReacordPerPage = 5;
            int NoofPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NumoofReacordPerPage)));
            int NoofRecordSkip = (page - 1) * NumoofReacordPerPage;
            ViewBag.Page = page;
            ViewBag.NoofPages = NoofPages;
            products = products.Skip(NoofRecordSkip).Take(NumoofReacordPerPage).ToList();

            return View(products);
        }

        public ActionResult CreateProduct()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    // Kiểm tra loại file
                    var allowedExtensions = new[] { ".jpg", ".png" };
                    var fileEx = Path.GetExtension(imageFile.FileName).ToLower();

                    if (!allowedExtensions.Contains(fileEx))
                    {
                        ModelState.AddModelError("Image", "Chỉ chấp nhận hình ảnh dạng JPG hoặc PNG.");
                        ViewBag.Categories = db.Categories.ToList();
                        return View();
                    }

                    // Truy vấn và đổi tên ảnh
                    var fileName = product.ID_Product.ToString() + fileEx;
                    var pathh = Path.Combine(Server.MapPath("~/img/product/"), fileName);
                    imageFile.SaveAs(pathh);

                    product.Images = fileName;
                }

                // Lưu thông tin vào CSDL
                db.Products.Add(product);
                db.SaveChanges();

                int categoryID = product.ID_Category;
                string path = "/Admin/ProductAdmin/index/" + categoryID;
                return Redirect(path);
            }
            else
            {
                ViewBag.Categories = db.Categories.ToList();
                return View();
            }
        }
        public ActionResult Edit(int Id)
        {
            Product pro = db.Products.Where(item => item.ID_Product == Id).FirstOrDefault();
            ViewBag.Categories = db.Categories.ToList();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase imageFileEdit)
        {
            Product pro = db.Products.Where(row => row.ID_Product == product.ID_Product).FirstOrDefault();

            //Update
            pro.Name_Product = product.Name_Product;
            pro.Price = product.Price;
            pro.QuantityInventory = product.QuantityInventory;
            pro.hot = product.hot;
            pro.Status = product.Status;
            if (imageFileEdit != null && imageFileEdit.ContentLength > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".png" };
                var fileEx = Path.GetExtension(imageFileEdit.FileName).ToLower();
                if (!allowedExtensions.Contains(fileEx))
                {
                    ModelState.AddModelError("ProductImage", "Chỉ chấp nhận hình ảnh dạng JPG hoặc PNG.");
                    return View();
                }

                var fileName = Path.GetFileName(imageFileEdit.FileName);
                var path = Path.Combine(Server.MapPath("~/img/product/"), fileName).ToLower();
                pro.Images = fileName;
                imageFileEdit.SaveAs(path);

            }
            db.SaveChanges();
            return RedirectToAction("Index", "ProductAdmin");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Product pro = db.Products.Find(id);
            db.Products.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}