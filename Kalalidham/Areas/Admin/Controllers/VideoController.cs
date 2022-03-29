using Kalalidham.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kalalidham.Areas.Admin.Controllers
{
    [Authorize]

    public class VideoController : Controller
    {
        // GET: Admin/Video
        KalalidhamEntities usersEntities = new KalalidhamEntities();

        public ActionResult Index()
        {
            var model = usersEntities.tblVideos.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(tblVideo mData)
        {
            try
            {
                mData.CreatedDate = DateTime.Now;
                usersEntities.tblVideos.Add(mData);
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
            var data = usersEntities.tblVideos.ToList().Where(x => x.Id == id).FirstOrDefault();

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(tblVideo mData)
        {
            try
            {
                var data = usersEntities.tblVideos.Where(x => x.Id == mData.Id).FirstOrDefault();
                mData.CreatedDate = data.CreatedDate;

                usersEntities.tblVideos.Remove(data);
                usersEntities.SaveChanges();

                usersEntities.tblVideos.Add(mData);
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
            var data = usersEntities.tblVideos.Find(id);
            usersEntities.tblVideos.Remove(data);
            usersEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}