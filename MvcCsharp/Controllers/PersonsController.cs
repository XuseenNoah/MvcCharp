using MvcCsharp.Models;
using MvcCsharp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCsharp.Controllers
{
    public class PersonsController : Controller
    {
        Repository _repo = new Repository();
        // GET: Persons
        [HttpGet]
        public ViewResult CreatePerson()
        {
            return View();
        }

        [HttpPost]
        //[ActionName("CreatePerson")]
        public ActionResult CreatePerson(Persons persons)
        {
            if (ModelState.IsValid)
            {
                _repo.CreatePerson(persons);

            }
            return View();
        }
    }
}