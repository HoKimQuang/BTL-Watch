using System;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Watch.DAL;
using Watch.Models;

namespace Watch.Controllers
{
    public class ProductsController : Controller
    {
        private WatchShopContext db = new WatchShopContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).OrderBy(p => p.CategoryID);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
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

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "TenDM");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenSP,HinhAnh,SoLuong,DonGia,MoTa,CategoryID")] Product product, HttpPostedFileBase image)
        {

            if (ModelState.IsValid)
            {
                // Verify that the user selected a file
                if (image != null && image.ContentLength > 0)
                {
                    // extract only the filename
                    var fileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetFileName(image.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/FileUploads"), fileName);
                    image.SaveAs(path);

                    product.HinhAnh = fileName;
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "TenDM", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "TenDM", product.CategoryID);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenSP,HinhAnh,SoLuong,DonGia,MoTa,CategoryID")] Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                // Verify that the user selected a file
                if (image != null && image.ContentLength > 0 && Path.GetFileName(image.FileName) != product.HinhAnh)
                {
                    // extract only the filename
                    var fileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetFileName(image.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/FileUploads"), fileName);
                    image.SaveAs(path);

                    product.HinhAnh = fileName;

                }

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "TenDM", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
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
