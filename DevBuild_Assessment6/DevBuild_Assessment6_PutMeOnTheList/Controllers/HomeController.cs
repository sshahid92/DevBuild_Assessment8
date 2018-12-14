using DevBuild_Assessment6_PutMeOnTheList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevBuild_Assessment6_PutMeOnTheList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rsvp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Rsvp(Guest teamMember)
        {
            var teamMemberRsvp = teamMember;
            return RedirectToAction("SaveGuest", "Database", teamMemberRsvp);
        }

        public ActionResult RsvpComplete(Guest teamMemberRsvp)
        {
            return View(teamMemberRsvp);
        }
       
        public ActionResult BringADish(Guest foundGuest)
        {
            return View(foundGuest);
        }
        [HttpPost]
        public ActionResult BringADish(Dish dish)
        {
            var bringDish = dish;
            return RedirectToAction("SaveDish", "Database", bringDish);
        }
        public ActionResult ThankYouForDish(Dish dish)
        {
            return View(dish);
        }
    }
}