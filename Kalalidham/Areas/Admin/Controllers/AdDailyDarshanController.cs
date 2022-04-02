using Kalalidham.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kalalidham.Areas.Admin.Controllers
{
    public class AdDailyDarshanController : Controller
    {
        KalalidhamEntities usersEntities = new KalalidhamEntities();

        // GET: Admin/AdDailyDarshan
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(tblDailyDarshan mData)
        {
            try
            {
                usersEntities.tblDailyDarshans.Add(mData);
                usersEntities.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(tblDailyDarshan mData)
        {
            try
            {
                var data = usersEntities.tblDailyDarshans.Where(x => x.Id == mData.Id).FirstOrDefault();

                usersEntities.tblDailyDarshans.Remove(data);
                usersEntities.SaveChanges();

                usersEntities.tblDailyDarshans.Add(mData);
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
            var data = usersEntities.tblDailyDarshans.Find(id);
            usersEntities.tblDailyDarshans.Remove(data);
            usersEntities.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}