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
            int imgid = usersEntities.tblImageMasters.Where(x => x.ImageTitle == "Daily Darshan")
                .Select(x => x.Id).FirstOrDefault();
            var data = usersEntities.tblMultiImages.Where(x => x.ImageTitleId == imgid).ToList();
            return View(data);
        }
    }
}