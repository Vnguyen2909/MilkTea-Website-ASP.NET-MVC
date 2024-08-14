using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Identity;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.ViewModel;
using Microsoft.AspNet.Identity;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Filters;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Helpers;

namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UserController : Controller
    {

        // GET: Admin/User
        public ActionResult Index()
        {
            AppDbContext appDBContext = new AppDbContext();
            AppUserStore userStore = new AppUserStore(appDBContext);
            AppUserManeger userManeger = new AppUserManeger(userStore);

            List<AppUser> users = userManeger.Users.Where(x => x.UserName != "Admin").ToList();
            return View(users);
        }

        public ActionResult DetailUser(string id)
        {
            var appDBContext = new AppDbContext();
            var userStore = new AppUserStore(appDBContext);
            var userManager = new AppUserManeger(userStore);

            AppUser user = userManager.FindById(id);
            if(user.ImgUrl == null)
            {
                user.ImgUrl = "NoImgUser.png";
            }
            return View(user);
        }

        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(RegisterVM rvm, HttpPostedFileBase imageUser)
        {
            if (ModelState.IsValid)
            {
                var appDBContext = new AppDbContext();
                var userStore = new AppUserStore(appDBContext);
                var userManager = new AppUserManeger(userStore);
                var passHash = Crypto.HashPassword(rvm.Password);
                var user = new AppUser()
                {
                    FullName = rvm.FullName,
                    UserName = rvm.Username,
                    PasswordHash = passHash,
                    Birthday = rvm.Birthday,
                    Email = rvm.Email,
                    PhoneNumber = rvm.Phone,
                    Address = rvm.Address,
                };
                if (imageUser != null && imageUser.ContentLength > 0)
                {
                    var allowedExtensions = new[] { ".jpg", ".png" };
                    var fileEx = Path.GetExtension(imageUser.FileName).ToLower();
                    if (!allowedExtensions.Contains(fileEx))
                    {
                        ModelState.AddModelError("ImgUrl", "Chỉ nhận ảnh dạng JPG hoặc PNG");
                        return View();
                    }

                    var fileName = Path.GetFileName(imageUser.FileName);
                    var path = Path.Combine(Server.MapPath("~/img"), fileName).ToLower();
                    user.ImgUrl = fileName;
                    imageUser.SaveAs(path);
                }

                IdentityResult result = userManager.Create(user);
                if(result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                }

                userManager.Update(user);
                return RedirectToAction("Index", "User");
            }else
            {
                return View();
            }
        }

        public ActionResult EditUser(string id)
        {
            var appDBcontext = new AppDbContext();
            var userStore = new AppUserStore(appDBcontext);
            var userManager = new AppUserManeger(userStore);

            AppUser user = userManager.FindById(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(AppUser userEdit, HttpPostedFileBase imageEditUser)
        {
            var appDBcontext = new AppDbContext();
            var userStore = new AppUserStore(appDBcontext);
            var userManager = new AppUserManeger(userStore);

            AppUser user = userManager.FindById(userEdit.Id);

            user.UserName = userEdit.UserName;
            user.FullName = userEdit.FullName;
            user.Email = userEdit.Email;
            user.PhoneNumber = userEdit.PhoneNumber;
            user.Address = userEdit.Address;
            //user.Birthday = userEdit.Birthday;

            if(imageEditUser != null && imageEditUser.ContentLength > 0)
            {
                string filename = Path.GetFileName(imageEditUser.FileName);
                string path = Path.Combine(Server.MapPath("~/img"), filename).ToLower();
                user.ImgUrl = filename;
                imageEditUser.SaveAs(path);
            }
            userManager.Update(user);
            return View(user);
        }
        

        public ActionResult DeleteUser(string id)
        {
            var appDBContext = new AppDbContext();
            var userStore = new AppUserStore(appDBContext);
            var userManager = new AppUserManeger(userStore);
            AppUser user = userManager.FindById(id);

            return View(user);
        }
        [HttpPost]
        public ActionResult DeleteUser(AppUser userDelete)
        {
            var appDBContext = new AppDbContext();
            var userStore = new AppUserStore(appDBContext);
            var userManager = new AppUserManeger(userStore);

            AppUser user = userManager.FindById(userDelete.Id);
            userManager.Delete(user);

            return RedirectToAction("Index", "User");
        }
    }
}