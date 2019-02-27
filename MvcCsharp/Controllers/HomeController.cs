using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCsharp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult GetHOme()
        {
            //nreturn View();
            //return Content("sdfdsfsdf");
            //return RedirectToAction("Index");
            //return Json();
            //return new EmptyResult();
            //return JavaScript();
            return View();
            //throw new ArithmeticException("fsdfsdf");
        
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}