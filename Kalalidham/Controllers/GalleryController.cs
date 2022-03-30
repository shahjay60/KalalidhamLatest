using Kalalidham.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kalalidham.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        KalalidhamEntities usersEntities = new KalalidhamEntities();

        public ActionResult Index()
        {
            var gallery = usersEntities.tblMultiImages.ToList();
            return View();
        }
    }
}