using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCsharp.Controllers
{
    public class MainController :Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult Search(string name)
        {
            var input = Server.HtmlDecode(name);
            return Content(input);
        }

        //public ActionResult EmptyResutl()
        //{
        //    //return EmptyResutl();
        //    return PartialView();
        //    return Json();
        //    return JavaScript();
        //}
    }
}