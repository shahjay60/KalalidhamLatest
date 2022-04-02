using Kalalidham.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kalalidham.Controllers
{
    public class DailyDarshanController : Controller
    {
        // GET: DailyDarshan
        KalalidhamEntities usersEntities = new KalalidhamEntities();

        public ActionResult Index()
        {
            ViewBag.VideoData = usersEntities.tblVideos.ToList();

            return View();
        }
    }
}