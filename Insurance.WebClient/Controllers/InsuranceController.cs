using Insurance.Model;
using Insurance.WebClient.Helper;
using Insurance.WebClient.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Insurance.WebClient.Controllers
{
    public class InsuranceController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            PremiumVM premiumvm = new PremiumVM();
            
            
            PremiumModelHelper modelHelper = new PremiumModelHelper();
            premiumvm.OccupationForList = modelHelper.PopulatePremiumVM();

            return View(premiumvm);
        }

        [HttpPost]
        public ActionResult Calculate(PremiumVM premiumDetails)
        {
            PremiumModelHelper modelHelper = new PremiumModelHelper();

            if (ModelState.IsValid)
            {
                if (premiumDetails.Dob >= DateTime.Now)
                {
                    ModelState.AddModelError(string.Empty, "Invalid date of bith");
                }
                else
                {
                    premiumDetails.Age = DateTime.Now.Year - premiumDetails.Dob.Year;

                    premiumDetails.PremiumAmount = modelHelper.CalculatePremium(premiumDetails.Age, premiumDetails.Amount, premiumDetails.Age);
                }
            }

            premiumDetails.OccupationForList = modelHelper.PopulatePremiumVM();
            return View("Index",premiumDetails);
        }

    }
}