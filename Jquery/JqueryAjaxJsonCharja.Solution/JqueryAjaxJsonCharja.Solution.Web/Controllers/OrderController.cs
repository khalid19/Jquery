using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JqueryAjaxJsonCharja.Solution.Web.Models;

namespace JqueryAjaxJsonCharja.Solution.Web.Controllers
{

    public class OrderController : Controller
    {
        private OrderDbContext db = new OrderDbContext();
        //
        // GET: /Order/
        public ActionResult Index(OrderViewModel model)
        {
            model.Orders = db.Orders.ToList();
            return View(model);
        }
        public ActionResult Create(OrderViewModel model)
        {
            model.Orders = db.Orders.OrderByDescending(x => x.OrderId).ToList();
            return View(model);
        }
        //public ActionResult Save(string orderNo)
        //{
        //    return View();
        //}
        //public JsonResult Save(OrderViewModel model)
        //{
        //    model.Orders.Add(model.Order);

        //    return Json(model.Order, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Save(OrderViewModel model)
        {
            //model.Orders = db.Orders.ToList();

            if (model.Order.OrderId>0)
            {
                db.Entry(model.Order).State=EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.Orders.Add(model.Order);
                db.SaveChanges();   
            }
           

            //if (saveChanges>0)
            //{
            //    return View("Index", model);
            //}
            model.Orders = db.Orders.OrderByDescending(x => x.OrderId).ToList();

            return View("Index", model);


            //model.Orders.Add(model.Order);

        }


        public ActionResult Edit(Order model)
        {
          Order order = db.Orders.Find(model.OrderId)??new Order();

            OrderViewModel models = new OrderViewModel();

            models.Order.OrderId = order.OrderId;
            models.Order.OrderNo = order.OrderNo;
            models.Order.Date = order.Date;
         

            return View("Create",models);

        }


        public ActionResult Delete(Order model)
        {
            Order order = db.Orders.Find(model.OrderId)??new Order();

            db.Entry(order).State = EntityState.Deleted;
            db.SaveChanges();

            OrderViewModel models = new OrderViewModel();
            models.Orders = db.Orders.OrderByDescending(x => x.OrderId).ToList();

            return View("Create",models);
        }
    }
}