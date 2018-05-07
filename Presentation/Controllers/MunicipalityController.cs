using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic;
using Data;
using System.Text;

namespace Presentation.Controllers
{
    public class MunicipalityController : Controller
    {
        public ActionResult ShowPowerOfDay()
        {
            Session["chosenACtion"] = "ShowPowerOfDay";
            var date = String.Format("{0} {1} {2} {3}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(-1).Day, DateTime.Today.Hour);
            return View("PowerView",MunicipalDataHandler.GetProducedPowerOfDay(date, (string)Session["kommun"], (bool?)Session["perInhabitant"]));
        }

        public ActionResult ShowPowerOfMonth()
        {
            Session["chosenACtion"] = "ShowPowerOfMonth";
            var date = String.Format("{0} {1} {2} {3}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(-1).Day, DateTime.Today.Hour);
            return View("PowerView", MunicipalDataHandler.GetProducedPowerOfMonth(date, (string)Session["kommun"], (bool?)Session["perInhabitant"]));
        }

        public ActionResult ShowPowerOfYear()
        {
            Session["chosenACtion"] = "ShowPowerOfYear";
            var date = String.Format("{0} {1} {2} {3}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(-1).Day, DateTime.Today.Hour);
            return View("PowerView", MunicipalDataHandler.GetProducedPowerOfYear(date, (string)Session["kommun"], (bool?)Session["perInhabitant"]));
        }
        public  ActionResult ShowTotalPower()
        {
            Session["chosenACtion"] = "ShowTotalPower";
            return View("PowerView", MunicipalDataHandler.GetTotalProducedPower((string)Session["kommun"]));
        }

        public ActionResult ChooseMunicipality(string id)
        {
            if ((bool?)Session["compare"] == false || (bool?)Session["compare"] == null)
            {
                Session["kommun"] = id;
                Session["kommunOld"] = id;
            }
            return RedirectToAction((string)Session["chosenACtion"]);
        }

        public ActionResult SetCompareMode(int? id)
        {
            if (id == null || id == 0 || (bool?)Session["compare"] == true)
            {
                Session["compare"] = false;
                Session["kommun"] = Session["kommunOld"];
            }
            else
            {
                Session["compare"] = true;
                Session["kommun"] = null;
            }
            return RedirectToAction((string)Session["chosenACtion"]);
        }

        public ActionResult PerInhabitant (bool? id)
        {
            Session["perInhabitant"] = id;
            return RedirectToAction((string)Session["chosenAction"]);
        }
    }
}