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
            if (obj.idParent == null)
            {
                return Ok(false);
            }
            else
            {
                var idParent = context.GetItem<Item>(obj.idParent.ToString());
                if (idParent != null)
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

        [HttpPost]
        public IHttpActionResult VoteStar(StarVote objvote)
        {
            var context = new SitecoreContext();
            var masterSV = new SitecoreService("master");
            if (objvote.idParent == null)
            {
                return Ok(false);
            }
            else
            {
                var idCurrent = context.GetItem<Item>(objvote.idParent.ToString());
                List<Item> list = idCurrent.GetChildren().ToList();
                Item idParent = null;
                foreach (var item in list)
                {
                    if (Guid.Parse(item.TemplateID.ToString()) == Guid.Parse(IStarVoteConstants.TemplateIdString.ToString()))
                    {
                        if(item.Children.Count != 0)
                        {
                            foreach (var items in item.GetChildren().ToList())
                            {
                                Item itemCheck = Sitecore.Context.Database.Items.GetItem(items.ID);
                                if (itemCheck.Fields["Email"].ToString() == objvote.Email.ToString())
                                {
                                    idParent = null;
                                    break;
                                }
                                else
                                {
                                    idParent = context.GetItem<Item>(item.ID.ToString());
                                }
                            }
                        }
                        else
                        {
                            idParent = context.GetItem<Item>(item.ID.ToString());
                        }
                    }
                }
                if (idParent == null)
                {
                    return Ok(false);
                }
                else
                {
                    string nameVote = "user" + DateTime.Now.ToString("dd-MM-yy-hh-ss");
                    var templateVote = context.GetItem<Item>(IStarVoteConstants.TemplateIdString);
                    using (new SecurityDisabler())
                    {
                        var templateId = new TemplateItem(templateVote);
                        var itemChild = idParent.Add(nameVote, templateId);
                        itemChild.Editing.BeginEdit();
                        itemChild.Fields["Email"].Value = objvote.Email;
                        itemChild.Fields["number star"].Value = objvote.Number_Star.ToString();
                        itemChild.Fields["time vote"].Value = Sitecore.DateUtil.ToIsoDate(DateTime.Now);
                        itemChild.Editing.EndEdit();
                        numberVote(objvote.idParent.ToString());
                    }
                }
            }
            return Ok(true);
        }

        public bool numberVote(string idPage)
        {
            int numberStar = 0;
            var context = new SitecoreContext();
            var model = context.GetItem<Page_Site>(idPage.ToString());
            List<StarVote> listVote = model.listVote.ToList();
            foreach (var item in listVote)
            {
                numberStar = int.Parse(item.Number_Star.ToString()) + numberStar;
            }
            double avgVote = Math.Round(float.Parse(numberStar.ToString()) / float.Parse(listVote.Count().ToString()), 2);
            model.NumberVote = avgVote.ToString();
            using (new SecurityDisabler())
            {
                Item itemPage = context.GetItem<Item>(idPage.ToString());
                try
                {
                    itemPage.Editing.BeginEdit();
                    itemPage.Fields["NumberVote"].Value = avgVote.ToString();
                    itemPage.Editing.EndEdit();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
