using SAS.Models;
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
            var model = new ScriptureListItem[0];
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
            if (ModelState.IsValid)
            {

            }

            return View(model);
        }
    }
}