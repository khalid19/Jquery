﻿using System.Web;
using System.Web.Mvc;

namespace CharjsaSolution.ERP365.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
