namespace TechBlog.Site.PipeLine
{
    using Sitecore.Diagnostics;
    using Sitecore.Pipelines;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    // TODO: \App_Config\include\LoaderRouter.config created automatically when creating LoaderRouter class.

    public class LoaderRouter
    {
        public void Process(PipelineArgs args)
        {
            GlobalConfiguration.Configure(Configure);
            
        }
        protected void Configure(HttpConfiguration configuration)
        {
            var routes = configuration.Routes;
            var route = routes.MapHttpRoute(
            "TechBlogAPI",
            "TechBlog/{controller}/{action}");

            //routes.MapHttpRoute(
            //"TechBlogExternalAPI",
            //"api/techblog/External/{action}",
            //new { controller = "DetaiPage" });

            //RouteTable.Routes.MapRoute("CommentAjax", "ajax/Comment/{controller}/{action}/{id}",
            //    new { controller = "Default", action = "Index", id = UrlParameter.Optional });
        }
    }
}