using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kalalidham.Areas.Admin.Controllers
{
    public class DashBordController : Controller
    {
        // GET: Admin/DashBord
        public ActionResult Index()
        {
            return View();
        }
    }
}