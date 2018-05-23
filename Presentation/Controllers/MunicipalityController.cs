using System;
using System.Web.Mvc;
using Logic;

namespace Presentation.Controllers
{
    public class MunicipalityController : Controller
    {
        public ActionResult ShowPowerOfDay(string id)
        {
            Session["onHome"] = false;
            Session["chosenACtion"] = "ShowPowerOfDay";
            if (id == "options")
            {
                Session["options"] = true;
            }
            else if (id != "" && id != null)
            {
                Session["options"] = false;
                if ((bool?)Session["compare"] == false || (bool?)Session["compare"] == null)
                {
                    Session["kommun"] = id;
                    Session["kommunOld"] = id;
                }
            }
            var date = String.Format("{0} {1} {2} {3}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(-1).Day, DateTime.Today.Hour);
            return View("PowerView",MunicipalDataHandler.GetProducedPowerOfDay(date, (string)Session["kommun"], (bool?)Session["perInhabitant"]));
        }

        public ActionResult ShowPowerOfMonth(string id)
        {
            Session["onHome"] = false;
            Session["chosenACtion"] = "ShowPowerOfMonth";
            if (id == "options")
            {
                Session["options"] = true;
            }
            else if (id != "" && id != null)
            {
                Session["options"] = false;
                if ((bool?)Session["compare"] == false || (bool?)Session["compare"] == null)
                {
                    Session["företag"] = id;
                    Session["företagOld"] = id;
                }
            }
            var date = String.Format("{0} {1} {2} {3}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(-1).Day, DateTime.Today.Hour);
            return View("PowerView", MunicipalDataHandler.GetProducedPowerOfMonth(date, (string)Session["kommun"], (bool?)Session["perInhabitant"]));
        }

        public ActionResult ShowPowerOfYear(string id)
        {
            Session["onHome"] = false;
            Session["chosenACtion"] = "ShowPowerOfYear";
            if (id == "options")
            {
                Session["options"] = true;
            }
            else if (id != "" && id != null)
            {
                Session["options"] = false;
                if ((bool?)Session["compare"] == false || (bool?)Session["compare"] == null)
                {
                    Session["företag"] = id;
                    Session["företagOld"] = id;
                }
            }
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