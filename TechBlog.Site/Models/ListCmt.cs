using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechBlog.Site.Models.sitecore.templates.TechBlog_Temp;

namespace TechBlog.Site.Models.sitecore.templates.TechBlog_Temp
{
    public partial class Page_Site
    {
        [SitecoreChildren]
        public virtual IEnumerable<Comment_Temp> childrenCmt { set; get; }
    }
}