using Glass.Mapper.Sc;
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

        [HttpPost]
        public JsonResult uploadCmt(Comment_Temp data)
        {
            var context = new SitecoreContext();
            var masterSv = new SitecoreService("master");
            var idParent = context.GetItem<Item>(data.idParent.ToString());
            if(idParent != null)
            {
                string nameCmt = "user" + DateTime.Now.ToString("dddd, dd MMMM yyyy");
                var template = context.GetItem<Item>(IComment_TempConstants.TemplateIdString);
                using (new SecurityDisabler())
                {
                    var templateItem = new TemplateItem(template);
                    var itemChild = idParent.Add(nameCmt, templateItem);
                    itemChild.Editing.BeginEdit();
                    itemChild.Fields["name"].Value = data.Name;
                    itemChild.Fields["email"].Value = data.Email;
                    itemChild.Fields["comment"].Value = data.Comment;
                    itemChild.Fields["time cmt"].Value = Sitecore.DateUtil.ToIsoDate(DateTime.Now);
                    itemChild.Editing.EndEdit();
                }
                return Json(new { Result = "true" });
            }
            else
            {
                return Json(new { Result = "false" });
            }
        }
    }
}