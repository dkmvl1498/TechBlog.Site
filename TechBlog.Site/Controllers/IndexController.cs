using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechBlog.Site.Models.sitecore.templates.TechBlog_Temp;

namespace TechBlog.Site.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult ListNew()
        {
            var context = new SitecoreContext();
            var contextMvc = new MvcContext();
            var model = contextMvc.GetDataSourceItem<Page_Site>();
            return View("~/Views/Index/Render/LitsPost.cshtml", model);
        }
    }
}