using Microsoft.AspNet.Identity;
using SAS.Models;
using SAS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAS.WebMVC.Controllers
{
    [Authorize]
    public class ScriptureController : Controller
    {
        // GET: Scripture
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScriptureService(userId);
            var model = service.GetScriptures();


            return View(model);
        }

        // GET: Scripture
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScriptureCreate model)
        {
            if (!ModelState.IsValid) return View(model);


             var service = CreateScriptureService();
            
            if (service.CreateScripture(model))
             {
                TempData["SaveResult"] = "Your scripture was created.";
                return RedirectToAction("Index");
             }

            ModelState.AddModelError("", "Scripture could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateScriptureService();
            var model = svc.GetScriptureById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateScriptureService();
            var detail = service.GetScriptureById(id);
            var model =
                new ScriptureEdit
                {
                    ScriptureId = detail.ScriptureId,
                    Book = detail.Book,
                    Chapter = detail.Chapter,
                    Verses = detail.Verses,
                    Content = detail.Content
                };

            return View(model);
        }

        // Helper Method
        private ScriptureService CreateScriptureService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new ScriptureService(userId);
            return service;
        }
    }
}