using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TankiFoodAndTravel.BusinessLayer;
using TankiFoodAndTravel.Models;

namespace TankiFoodAndTravel.Controllers
{
    public class HomeController : Controller
    {
        ContactDetails contactDetails = new ContactDetails();

        public ActionResult Index()
        {
            ViewBag.hitCount = contactDetails.UpdateAndFetchHitCount();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            var contacts = contactDetails.GetContactDetails("ABC");

            return View(contacts);
        }

        public ActionResult Login()
        {

            return View();
        }
    }
}