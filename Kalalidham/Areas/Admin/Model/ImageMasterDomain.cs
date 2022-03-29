using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kalalidham.Areas.Admin.Model
{
    public class ImageMasterDomain
    {
        public string TitleName { get; set; }
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int TitleId { get; set; }
    }
}