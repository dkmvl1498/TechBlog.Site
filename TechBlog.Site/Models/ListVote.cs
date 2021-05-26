using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechBlog.Site.Models.sitecore.templates.TechBlog_Temp
{
    public partial class Page_Site
    {
        [SitecoreQuery("./*/*[@@templatename='StarVote']", IsRelative = true)]
        public virtual IEnumerable<StarVote> listVote { set; get; }
    }
}