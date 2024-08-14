using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Models;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Filters;

namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Controllers
{
    [MyAuthenFilters]
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        DBContext db = new DBContext();
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Partial_Item_Cart()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }
        public ActionResult ShowCount()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if(cart != null)
            {
                return Json(new { Count = cart.Items.Count }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Count = 0 }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddToCart(int id, int quantity)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };
            var checkPro = db.Products.FirstOrDefault(x => x.ID_Product == id);
            if (checkPro != null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if(cart == null)
                {
                    cart = new ShoppingCart();
                }
                ShoppingCartItems item = new ShoppingCartItems
                {
                    ID_Product = checkPro.ID_Product,
                    ID_Category = checkPro.ID_Category,
                    Name_Product = checkPro.Name_Product,
                    Price = checkPro.Price,
                    Images = checkPro.Images,
                    Quantity = quantity,

                };
                item.TotalPrice = item.Price * item.Quantity;
                cart.AddToCart(item, quantity);
                Session["Cart"] = cart;
                code = new { Success = true, msg = "Thêm sản phẩm vào giỏ hàng thành công", code = 1, Count = cart.Items.Count };
            }
                return Json(code);
        }

        [HttpPost]
        public ActionResult Update(int id, int quantity)
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                cart.UpdateQuantity(id, quantity);
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                var checkPro = cart.Items.FirstOrDefault(x => x.ID_Product == id);
                if(checkPro != null)
                {
                    cart.Remove(id);
                    code = new { Success = true, msg = "", code = 1, Count = cart.Items.Count };
                }
            }
            return Json(code);
        }
        public ActionResult DeleteAll()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if(cart!= null)
            {
                cart.ClearCart();
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
    }
}