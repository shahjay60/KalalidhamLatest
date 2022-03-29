using Kalalidham.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kalalidham.Areas.Admin.Controllers
{
    [Authorize]

    public class ImageTitleMasterController : Controller
    {
        // GET: Admin/ImageTitleMaster
        KalalidhamEntities usersEntities = new KalalidhamEntities();

        public ActionResult Index()
        {
            var model = usersEntities.tblImageMasters.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(tblImageMaster mData)
        {
            try
            {
                usersEntities.tblImageMasters.Add(mData);
                usersEntities.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = usersEntities.tblImageMasters.ToList().Where(x => x.Id == id).FirstOrDefault();

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(tblImageMaster mData)
        {
            try
            {
                var data = usersEntities.tblImageMasters.Where(x => x.Id == mData.Id).FirstOrDefault();

                usersEntities.tblImageMasters.Remove(data);
                usersEntities.SaveChanges();

                usersEntities.tblImageMasters.Add(mData);
                usersEntities.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                return Json(false, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = usersEntities.tblImageMasters.Find(id);
            usersEntities.tblImageMasters.Remove(data);
            usersEntities.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}