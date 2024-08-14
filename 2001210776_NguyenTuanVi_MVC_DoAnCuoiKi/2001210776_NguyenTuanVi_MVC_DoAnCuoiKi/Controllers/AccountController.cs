using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Models;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.ViewModel;
using _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM rvm)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManeger(userStore);
                var passwdHash = Crypto.HashPassword(rvm.Password);
                var user = new AppUser()
                {
                    FullName = rvm.FullName,
                    UserName = rvm.Username,
                    PasswordHash = passwdHash,
                    Email = rvm.Email,
                    Birthday = rvm.Birthday,
                    PhoneNumber = rvm.Phone,
                    Address = rvm.Address,
                };
                IdentityResult identityResult = userManager.Create(user);
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");

                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("New Error", "IsValid Data");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM lvm)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManeger(userStore);
            var user = userManager.Find(lvm.Username, lvm.Password);
            if (user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenManager.SignIn(new AuthenticationProperties(), userIdentity);

                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("myError", "Invalid username and passowrd.");
                return View();
            }
        }
        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult InforUser()
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManeger(userStore);

            AppUser user = userManager.FindById(User.Identity.GetUserId());
            if (user.ImgUrl != null)
            {
                user.ImgUrl = "NoImgUser.png";
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult InforUser(AppUser update)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManeger(userStore);

            AppUser user = userManager.FindById(User.Identity.GetUserId());

            user.FullName = update.FullName;
            user.UserName = update.UserName;
            user.Email = update.Email;
            user.PhoneNumber = update.PhoneNumber;
            user.Birthday = update.Birthday;
            user.Address = update.Address;
            user.ImgUrl = update.ImgUrl;

            if (user.ImgUrl == null)
            {
                user.ImgUrl = "NoImgUser.png";
            }
            userManager.Update(user);
            
            return View(user);
        }
    }
}