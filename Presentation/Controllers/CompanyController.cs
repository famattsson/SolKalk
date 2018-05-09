using System;
using System.Web.Mvc;
using Logic;

namespace Presentation.Controllers
{
    public class CompanyController : Controller
    {
        public ActionResult ShowPowerOfDay()
        {
            Session["chosenACtion"] = "ShowPowerOfDay";
            var date = String.Format("{0} {1} {2} {3}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(-1).Day, DateTime.Today.Hour);
            return View("PowerView", CompanyDataHandler.GetProducedPowerOfDay(date, (string)Session["företag"]));
        }
        public ActionResult ShowPowerOfMonth()
        {
            Session["chosenACtion"] = "ShowPowerOfMonth";
            var date = String.Format("{0} {1} {2} {3}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(-1).Day, DateTime.Today.Hour);
            return View("PowerView", CompanyDataHandler.GetProducedPowerOfMonth(date, (string)Session["företag"]));
        }
        public ActionResult ShowPowerOfYear()
        {
            Session["chosenACtion"] = "ShowPowerOfYear";
            var date = String.Format("{0} {1} {2} {3}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(-1).Day, DateTime.Today.Hour);
            return View("PowerView", CompanyDataHandler.GetProducedPowerOfYear(date, (string)Session["företag"]));
        }
        public ActionResult ShowTotalPower()
        {
            Session["chosenACtion"] = "ShowTotalPower";
            return View("PowerView", CompanyDataHandler.GetTotalProducedPower((string)Session["företag"]));
        }
        public ActionResult ChooseCompany(string id)
        {
            if ((bool?)Session["compare"] == false || (bool?)Session["compare"] == null)
            {
                Session["företag"] = id;
                Session["företagOld"] = id;
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
    }
}