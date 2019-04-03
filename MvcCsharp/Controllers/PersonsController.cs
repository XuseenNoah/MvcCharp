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
                TempData["Succes"] = "Succesfly Saved Record";
                ModelState.Clear();
                return RedirectToAction("ListPersons");

            }
            return View();
        }

        public ActionResult GetImage(string id)
        {
            var getImage = _repo.GetImage(id);
            return File(getImage, "Image/jpeg");
        }

        public ViewResult ListPersons(string CustomerName)
        {
            var getListPerson = _repo.ListPerson(CustomerName);
            return View(getListPerson);
        }

        public ActionResult Details(string id)
        {
            var getPerson = _repo.GetPerson(id);
            if (getPerson == null)ViewBag.NotFound="Ma jiro Qof Idga leh oo ku diwan gashan";
            return View(getPerson);
        }

        //public ActionResult Delete(string id)
        //{
        //    var getPerson = _repo.GetPerson(id);
        //    return View(getPerson);
        //}

  
        public ActionResult Delete(string id)
        {
            _repo.DeletePerson(id);
            TempData["SuccesfullyDeleted"] = "Succesfully Deleted";
            return RedirectToAction(nameof(ListPersons));
        }

        public ActionResult UpdatePerson(string id)
        {
            var getPerson = _repo.GetPerson(id);
            return View(getPerson);
        }

        [HttpPost]
        [ActionName("UpdatePerson")]
        public ActionResult Updated(Persons persons)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdatePerson(persons);
                TempData["SuccesfullyUpdated"] = "Succesfully Updated";
                ModelState.Clear();
                return RedirectToAction(nameof(ListPersons));
            }
            return View(persons);
        }


       
    }
}