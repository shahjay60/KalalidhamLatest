using Kalalidham.Data;
using Kalalidham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Kalalidham.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            string message = ViewBag.Message;
            ViewBag.ErrorMessage = message;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(User user)
        {
            KalalidhamEntities usersEntities = new KalalidhamEntities();
            int? userId = usersEntities.Validate_User1(user.Username, user.Password).FirstOrDefault();

            string message = string.Empty;
            switch (userId.Value)
            {
                case -1:
                    message = "Username and/or password is incorrect.";
                    break;
                case -2:
                    message = "Account has not been activated.";
                    break;
                default:
                    FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                    return RedirectToAction("Index","Admin/DashBord");
            }

            ViewBag.Message = message;
            return View(user);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}