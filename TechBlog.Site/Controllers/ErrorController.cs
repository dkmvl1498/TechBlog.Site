using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechBlog.Site.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult ErrorIndex()
        {
            return View("~/Views/Error/ErrorMain.cshtml");
        }
    }
}