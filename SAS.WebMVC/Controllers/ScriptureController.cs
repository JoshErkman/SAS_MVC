﻿using Microsoft.AspNet.Identity;
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

        private ScriptureService CreateScriptureService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new ScriptureService(userId);
            return service;
        }
    }
}