using Kalalidham.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kalalidham.Models
{
    public class GalleryTitleMaster
    {
        public string Title { get; set; }
        public string ImageName { get; set; }
        public List<GalleryTitle> MultiImageList { get; set; }
    }
    public class GalleryTitle
    {
        public int Id { get; set; }
        public int ImageTitleId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
    }
}