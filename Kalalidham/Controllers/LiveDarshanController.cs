using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kalalidham.Data;

namespace Kalalidham.Controllers
{

    public class LiveDarshanController : Controller
    {
        // GET: LiveDarshan
        KalalidhamEntities usersEntities = new KalalidhamEntities();
        public ActionResult Index()
        {
            var data = usersEntities.tblVideos.Where(x => x.IsLiveDarshan == true).FirstOrDefault();

            return View(data);
        }
    }
}