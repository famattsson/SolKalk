using System;
using System.Web.Mvc;
using Logic;

namespace Presentation.Controllers
{
    public class CompanyController : Controller
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
                    Session["Organisation"] = id;
                    Session["OrganisationOld"] = id;
                }
            }

            var date = String.Format("{0} {1} {2} {3}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(-1).Day, DateTime.Today.Hour);
            return View("PowerView", CompanyDataHandler.GetProducedPowerOfDay(date, (string)Session["Organisation"]));
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
                    Session["Organisation"] = id;
                    Session["OrganisationOld"] = id;
                }
            }
            var date = String.Format("{0} {1} {2} {3}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(-1).Day, DateTime.Today.Hour);
            return View("PowerView", CompanyDataHandler.GetProducedPowerOfMonth(date, (string)Session["Organisation"]));
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
                    Session["Organisation"] = id;
                    Session["OrganisationOld"] = id;
                }
            }
            var date = String.Format("{0} {1} {2} {3}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(-1).Day, DateTime.Today.Hour);
            return View("PowerView", CompanyDataHandler.GetProducedPowerOfYear(date, (string)Session["Organisation"]));
        }
        public ActionResult ShowTotalPower()
        {
            Session["chosenACtion"] = "ShowTotalPower";
            return View("PowerView", CompanyDataHandler.GetTotalProducedPower((string)Session["Organisation"]));
        }
        public ActionResult ChooseCompany(string id)
        {
            if ((bool?)Session["compare"] == false || (bool?)Session["compare"] == null)
            {
                Session["Organisation"] = id;
                Session["OrganisationOld"] = id;
            }
            return RedirectToAction((string)Session["chosenACtion"]);
        }
        public ActionResult SetCompareMode(int? id)
        {
            if (id == null || id == 0 || (bool?)Session["compare"] == true)
            {
                Session["compare"] = false;
                Session["kommun"] = Session["kommunOld"];
                Session["Organisation"] = Session["OrganisationOld"];
            }
            else
            {
                Session["compare"] = true;
                Session["kommun"] = null;
                Session["Organisation"] = null;
            }
            return RedirectToAction((string)Session["chosenACtion"]);
        }
    }
}