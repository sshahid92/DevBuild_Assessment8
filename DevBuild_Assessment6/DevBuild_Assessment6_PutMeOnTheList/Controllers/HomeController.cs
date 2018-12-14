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
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Rsvp()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Rsvp(Guest teamMember)
        {
            var teamMemberRsvp = teamMember;
            return RedirectToAction("SaveGuest", "Database", teamMemberRsvp);
        }
        [Authorize]
        public ActionResult RsvpComplete(Guest teamMemberRsvp)
        {
            return View(teamMemberRsvp);
        }
        [Authorize]
        public ActionResult BringADish(Guest foundGuest)
        {
            return View(foundGuest);
        }
        [Authorize]
        [HttpPost]
        public ActionResult BringADish(Dish dish)
        {
            var bringDish = dish;
            return RedirectToAction("SaveDish", "Database", bringDish);
        }
        [Authorize]
        public ActionResult ThankYouForDish(Dish dish)
        {
            return View(dish);
        }
    }
}