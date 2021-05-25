using Glass.Mapper.Sc;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechBlog.Site.Models.sitecore.templates.TechBlog_Temp;

namespace TechBlog.Site.Controllers
{
    public class APIController : ApiController
    {
        [HttpPost]
        public IHttpActionResult UploadCmt(Comment_Temp obj)
        {
            var context = new SitecoreContext();
            var masterSV = new SitecoreService("master");
            if(obj.idParent == null)
            {
                return Ok(false);
            }
            else
            {
                var idParent = context.GetItem<Item>(obj.idParent.ToString());
                if(idParent != null)
                {
                    string nameCmt = "user" + DateTime.Now.ToString("dd-MM-yy-hh-ss");
                    var templateCmt = context.GetItem<Item>(IComment_TempConstants.TemplateIdString);
                    using (new SecurityDisabler())
                    {
                        var templateId = new TemplateItem(templateCmt);
                        var itemChild = idParent.Add(nameCmt, templateId);
                        itemChild.Editing.BeginEdit();
                        itemChild.Fields["name"].Value = obj.Name;
                        itemChild.Fields["email"].Value = obj.Email;
                        itemChild.Fields["comment"].Value = obj.Comment;
                        itemChild.Fields["time cmt"].Value = Sitecore.DateUtil.ToIsoDate(DateTime.Now);
                        itemChild.Editing.EndEdit();
                    }
                    return Ok(true);
                }
                return Ok(false);
            }
        }
    }
}
