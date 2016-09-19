using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDOperatioAjaxUsingJqueryJson.DAL;
using CRUDOperatioAjaxUsingJqueryJson.Model;

namespace CRUDOperatioAjaxUsingJqueryJson.Controllers
{
    public class ProductController : Controller
    {
        private Test4Entities db=new Test4Entities();
        //
        // GET: /Product/
        //public JsonResult Index()
        //{
        //    var products = db.Products;
        //    return Json(products, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProductDetails()
        {
            List<Product> products = db.Products.ToList();

      
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]

        public JsonResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();

            return Json(product, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult Edit(int prodductId)
        {
            Product product = db.Products.Find(prodductId);

            return PartialView(product);
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {

            Product product = db.Products.Find(id);

            db.Entry(product).State=EntityState.Deleted;
            db.SaveChanges();
            return Json(product, JsonRequestBehavior.AllowGet);

        }
    }
}