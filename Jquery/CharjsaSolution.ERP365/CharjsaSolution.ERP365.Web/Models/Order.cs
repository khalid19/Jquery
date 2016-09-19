using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharjsaSolution.ERP365.Web.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}