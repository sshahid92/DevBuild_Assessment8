using DevBuild_Assessment6_PutMeOnTheList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DevBuild_Assessment6_PutMeOnTheList.Controllers
{
    public class DatabaseController : Controller
    {
        // GET: Database
        public ActionResult Index()
        {
            ShahPartyDBEntities Orm = new ShahPartyDBEntities();
            ViewBag.DishList = Orm.Dishes.ToList();
            return View();
        }
        public ActionResult GuestIndex()
        {
            ShahPartyDBEntities Orm = new ShahPartyDBEntities();
            ViewBag.GuestList = Orm.Guests.ToList();
            return View();
        }

        public ActionResult SaveGuest(Guest addGuest)
        {
            ShahPartyDBEntities Orm = new ShahPartyDBEntities();
            Orm.Guests.Add(addGuest);
            Orm.SaveChanges();
            return RedirectToAction("RsvpComplete", "Home", addGuest);
        }
        public ActionResult SaveDish(Dish addDish)
        {
            ShahPartyDBEntities Orm = new ShahPartyDBEntities();
            Orm.Dishes.Add(addDish);
            Orm.SaveChanges();
            return RedirectToAction("ThankYouForDish", "Home", addDish);
        }

        public ActionResult EditGuest(int GuestID)
        {
            ShahPartyDBEntities Orm = new ShahPartyDBEntities();
            Guest found = Orm.Guests.Find(GuestID);

            return View(found);
        }

        public ActionResult EditDish(int DishID)
        {
            ShahPartyDBEntities Orm = new ShahPartyDBEntities();
            Dish found = Orm.Dishes.Find(DishID);

            return View(found);
        }

        public ActionResult FindGuestDish()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindGuestDish(string FirstName, string LastName)
        {
            ShahPartyDBEntities Orm = new ShahPartyDBEntities();
            var guestList = Orm.Guests.ToList();

            var found = from guest in guestList
                        where guest.FirstName == FirstName && guest.LastName == LastName
                        select guest;
            if(found.Any())
            {
                Guest foundGuest = found.First();
                ViewData["Guest"] = foundGuest;
                return RedirectToAction("BringADish", "Home", foundGuest);
            }
            ViewBag.ErrorMessage = "Guest not found or matched";
            return View();
            
        }

        public ActionResult SaveEditGuest(Guest updateGuest)
        {
            ShahPartyDBEntities Orm = new ShahPartyDBEntities();
            Guest oldGuest = Orm.Guests.Find(updateGuest.GuestID);

            oldGuest.FirstName = updateGuest.FirstName;
            oldGuest.LastName = updateGuest.LastName;
            oldGuest.AttendanceDate = updateGuest.AttendanceDate;
            oldGuest.EmailAddress = updateGuest.EmailAddress;
            oldGuest.Guest1 = updateGuest.Guest1;

            Orm.Entry(oldGuest).State = EntityState.Modified;
            Orm.SaveChanges();

            return RedirectToAction("GuestIndex");

        }

        public ActionResult SaveEditDish(Dish updateDish)
        {
            ShahPartyDBEntities Orm = new ShahPartyDBEntities();
            Dish oldDish = Orm.Dishes.Find(updateDish.DishID);

            oldDish.PersonName = updateDish.PersonName;
            oldDish.PhoneNumber = updateDish.PhoneNumber;
            oldDish.DishName = updateDish.DishName;
            oldDish.DishDescription = updateDish.DishDescription;
            oldDish.Option = updateDish.Option;

            Orm.Entry(oldDish).State = EntityState.Modified;
            Orm.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult DeleteGuest(int GuestID)
        {
            ShahPartyDBEntities Orm = new ShahPartyDBEntities();
            Guest found = Orm.Guests.Find(GuestID);

            Orm.Guests.Remove(found);
            Orm.SaveChanges();

            return RedirectToAction("GuestIndex");
        }

        public ActionResult DeleteDish(int DishID)
        {
            ShahPartyDBEntities Orm = new ShahPartyDBEntities();
            Dish found = Orm.Dishes.Find(DishID);

            Orm.Dishes.Remove(found);
            Orm.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}