using System;
using System.Web.Mvc;
using Logic;

namespace Presentation.Controllers
{
    public class MunicipalityController : Controller
    {
        public ActionResult ShowPowerOfDay()
        {
            Session["onHome"] = false;
            Session["chosenACtion"] = "ShowPowerOfDay";
            var date = String.Format("{0} {1} {2} {3}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(-1).Day, DateTime.Today.Hour);
            return View("PowerView",MunicipalDataHandler.GetProducedPowerOfDay(date, (string)Session["kommun"], (bool?)Session["perInhabitant"]));
        }

        public ActionResult ShowPowerOfMonth()
        {
            Session["onHome"] = false;
            Session["chosenACtion"] = "ShowPowerOfMonth";
            var date = String.Format("{0} {1} {2} {3}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(-1).Day, DateTime.Today.Hour);
            return View("PowerView", MunicipalDataHandler.GetProducedPowerOfMonth(date, (string)Session["kommun"], (bool?)Session["perInhabitant"]));
        }

        public ActionResult ShowPowerOfYear()
        {
            Session["onHome"] = false;
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
                Session["företag"] = Session["företagOld"];
            }
            else
            {
                Session["compare"] = true;
                Session["kommun"] = null;
                Session["företag"] = null;
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