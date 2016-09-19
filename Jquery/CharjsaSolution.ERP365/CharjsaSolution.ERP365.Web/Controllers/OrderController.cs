using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CharjsaSolution.ERP365.Web.Models;

namespace CharjsaSolution.ERP365.Web.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Save(OrderViewModel model)
        {
            //List<Order> orders = new List<Order>() {model.Order};
            model.Orders.Add(model.Order);
           // return Json(model.Order, JsonRequestBehavior.AllowGet);
            return View("Index", model.Orders);
        }
	}
}