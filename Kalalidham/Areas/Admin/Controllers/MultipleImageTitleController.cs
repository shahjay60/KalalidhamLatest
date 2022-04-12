using Kalalidham.Areas.Admin.Model;
using Kalalidham.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kalalidham.Areas.Admin.Controllers
{
    [Authorize]

    public class MultipleImageTitleController : Controller
    {
        // GET: Admin/MultipleImageTitle
        KalalidhamEntities usersEntities = new KalalidhamEntities();

        public ActionResult Index()
        {
            List<ImageMasterDomain> mdata = new List<ImageMasterDomain>();
            var Imagdata = usersEntities.tblImageMasters.ToList();

            return View(Imagdata);
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.imageTitles = usersEntities.tblImageMasters.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Add(int id = 0)
        {
            try
            {
                string uname = Request["uploadername"];
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    tblMultiImage mdata = new tblMultiImage();

                    HttpPostedFileBase file = files[i];
                    string fname;
                    // Checking for Internet Explorer      
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = file.FileName;
                    }
                    
                    // Get the complete folder path and store the file inside it.      
                    fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                    file.SaveAs(fname);
                    mdata.ImageTitleId = Convert.ToInt32(uname);
                    mdata.Image = file.FileName;
                    mdata.Datetime = DateTime.Now;
                    usersEntities.tblMultiImages.Add(mdata);
                    usersEntities.SaveChanges();
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult ViewImages(int id)
        {
            List<ImageMasterDomain> mdata = new List<ImageMasterDomain>();
            var data = usersEntities.tblMultiImages.ToList();
            var Imagdata = usersEntities.tblImageMasters.ToList();
            mdata = (from mi in data
                     join imast in Imagdata
     on mi.ImageTitleId equals imast.Id
                     where imast.Id == id
                     select new ImageMasterDomain
                     {
                         TitleName = imast.ImageTitle,
                         ImageName = mi.Image,
                         Id = mi.Id
                     }).ToList();
            return View(mdata);
        }

        [HttpPost]
        public ActionResult Edit(tblMultiImage mData)
        {
            try
            {
                var data = usersEntities.tblMultiImages.Where(x => x.Id == mData.Id).FirstOrDefault();

                usersEntities.tblMultiImages.Remove(data);
                usersEntities.SaveChanges();

                mData.Datetime = DateTime.Now;
                usersEntities.tblMultiImages.Add(mData);
                usersEntities.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                return Json(false, JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult Delete(int id)
        {
            var data = usersEntities.tblMultiImages.Find(id);
            usersEntities.tblMultiImages.Remove(data);
            usersEntities.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}