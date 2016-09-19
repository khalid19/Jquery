using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JqueryAjaxJsonCharja.Solution.Web.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string OrderNo { get; set; }


        public DateTime? Date { get; set; }
    }
}