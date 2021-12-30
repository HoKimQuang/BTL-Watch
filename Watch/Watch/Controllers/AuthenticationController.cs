using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Watch.DAL;
using Watch.Models;

namespace Watch.Controllers
{
    public class AuthenticationController : Controller
    {
        private WatchShopContext db = new WatchShopContext();

        /// <summary>
        /// Action Login Method GET
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Action Login Method POST
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string taiKhoan, string matKhau)
        {
            var user = db.Users.FirstOrDefault(x => x.TaiKhoan == taiKhoan && x.MatKhau == matKhau);
            if (user == null)
            {
                ViewBag.err = "Sai tên đăng nhập hoặc mật khẩu!";
                return View();
            }
            var categories = db.Categories.ToList();
            Session["User"] = user;
            Session["Categories"] = categories;
            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// Action Logout
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
