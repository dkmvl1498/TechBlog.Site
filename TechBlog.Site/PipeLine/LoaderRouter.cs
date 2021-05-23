namespace TechBlog.Site.PipeLine
{
    using Sitecore.Diagnostics;
    using Sitecore.Pipelines;
    using System.Web.Mvc;
    using System.Web.Routing;

    // TODO: \App_Config\include\LoaderRouter.config created automatically when creating LoaderRouter class.

    public class LoaderRouter
    {
        public void Process(PipelineArgs args)
        {
            RouteTable.Routes.MapRoute("VillageHouseAjax", "ajax/villagehouse/{controller}/{action}/{id}",
                new { controller = "Default", action = "Index", id = UrlParameter.Optional });
        }
    }
}