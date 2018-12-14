using DevBuild_Assessment6_PutMeOnTheList.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DevBuild_Assessment6_PutMeOnTheList.Controllers
{
    public class IdentityController : Controller
    {
        public UserManager<IdentityUser> UserManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();
        // GET: Identity
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registration(RegistrationModel newUser)
        {

            if (ModelState.IsValid)
            {
                var identityResult = await UserManager.CreateAsync(new IdentityUser(newUser.UserName), newUser.Password);

                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                
            }

            return View(newUser);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var authManager = HttpContext.GetOwinContext().Authentication;

                IdentityUser user = UserManager.Find(login.UserName, login.Password);

                //creating an identity (ident) with the user and this is the cookie that keeps user logged in throughout the program
                if (user != null)
                {
                    var ident = UserManager.CreateIdentity(
                        user, DefaultAuthenticationTypes.ApplicationCookie);
                    //using our instance of authentication, we use the signin method
                    //IsPersistent = false will logout the user and terminate that cookie (ident)
                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);

                    return RedirectToAction("Index", "Home");
                }

            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(login);

        }
    }
}