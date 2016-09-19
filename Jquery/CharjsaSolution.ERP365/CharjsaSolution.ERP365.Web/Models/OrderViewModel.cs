using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharjsaSolution.ERP365.Web.Models
{
    public class OrderViewModel
    {
        public List<Order> Orders { get; set; }
        public OrderViewModel()
        {
         Order=new Order();   
            Orders=new List<Order>();
        }
        public Order Order { get; set; }
    }
}