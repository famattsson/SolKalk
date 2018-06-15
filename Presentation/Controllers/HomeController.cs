﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Session["onHome"] = true;
            Session["options"] = true;
            if (Session["chosenACtion"] == null)
            {
                Session["chosenACtion"] = "ShowPowerOfYear";
            }
            return View("HomeView");
        }
    }
}