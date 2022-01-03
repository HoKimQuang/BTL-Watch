using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Watch.DAL;
using System.Data;
using System.Data.Entity;
using System.Net;

using Watch.Models;

namespace Watch.Controllers
{
    public class HomeController : Controller
    {
        private WatchShopContext db = new WatchShopContext();

        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                var products = db.Products.Include(p => p.Category);
                
                return View(products.ToList());
               
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListProduct(int? id)
        {
            var products = db.Products.Include(p => p.Category);
            if(id != null)
            {
                products = products.Where(p => p.CategoryID == id);
            }
            return View(products.ToList());
        }

        
        public ActionResult DetailProduct(int? id)
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
    }
}