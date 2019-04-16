using MvcCsharp.Models;
using MvcCsharp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCsharp.Controllers
{
    public class AccountController : Controller
    {
        Auth_Repository _repo = new Auth_Repository();
        // GET: Account
       
         public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var User = _repo.Authenticate(login);
                if (User != null)
                {
                    Session["User"] = User;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErrorLogin"] = "Error Login";
                }
            }
            return View(login);
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}