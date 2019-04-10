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
       public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _repo.Authenticate(login);
                if (user != null)
                {
                    Session["user"] = user;
                    FormsAuthentication.SetAuthCookie(login.Username, false);
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Error"] = "Error Loggin";
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