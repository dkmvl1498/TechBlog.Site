using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechBlog.Site.Models.sitecore.templates.TechBlog_Temp;

namespace TechBlog.Site.Controllers
{
    public class DetailPageController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult commentPage()
        {
            var context = new SitecoreContext();
            var model = context.GetCurrentItem<Page_Site>();
            return View("~/Views/Detail/commentPage.cshtml",model);
        }
        
        public ActionResult DetailPost(string idPost)
        {
            var context = new SitecoreContext();
            var contextDB = new MvcContext();
            var item = context.GetItem<Posts_Temp>(idPost);
            return View("~/Views/Detail/Render/PostDetail.cshtml", item);
        }

        public ActionResult MenuRender()
        {
            var context = new SitecoreContext();
            var model = context.GetHomeItem<Item>();
            return View();
        }
    }
}