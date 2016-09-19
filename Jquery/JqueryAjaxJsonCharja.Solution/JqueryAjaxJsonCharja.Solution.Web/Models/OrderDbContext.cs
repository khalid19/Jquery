using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JqueryAjaxJsonCharja.Solution.Web.Models
{
    public class OrderDbContext :DbContext
    {
        public DbSet<Order> Orders { get; set; }

       

    }
}