using Kalalidham.Data;
using Kalalidham.Models;
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
            var titles = usersEntities.tblImageMasters.ToList();
            var result = from d in titles
                         join s in gallery
                         on d.Id equals s.ImageTitleId into g
                         select new
                         {
                             DepartmentName = d.ImageTitle,
                             Students = g
                         };
            List<GalleryTitleMaster> mobjList = new List<GalleryTitleMaster>();

            foreach (var item in result)
            {
                GalleryTitleMaster mobj = new GalleryTitleMaster();
                mobj.MultiImageList = new List<GalleryTitle>();
                mobj.Title = item.DepartmentName;
                foreach (var item1 in item.Students)
                {
                    GalleryTitle mtblMultiImage = new GalleryTitle();
                    mtblMultiImage.Image = item1.Image;
                    mtblMultiImage.Title = item.DepartmentName;
                    mobj.MultiImageList.Add(mtblMultiImage);
                }
                mobjList.Add(mobj);
            }
            //var data = (from g in gallery
            //            join t in titles on g.ImageTitleId equals t.Id
            //            into gj
            //            //group
            //            select new GalleryTitleMaster {
            //                Title = gj.ImageTitle,
            //                ImageName = gj.Image
            //            }).ToList();
            return View(mobjList);
        }
    }
}