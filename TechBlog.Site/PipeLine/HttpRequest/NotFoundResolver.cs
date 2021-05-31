namespace TechBlog.Site.PipeLine.HttpRequest
{
    using Sitecore;
    using Sitecore.Configuration;
    using Sitecore.Data;
    using Sitecore.Diagnostics;
    using Sitecore.Pipelines.HttpRequest;

    // TODO: \App_Config\include\NotFoundResolver.config created automatically when creating NotFoundResolver class.

    public class NotFoundResolver : HttpRequestProcessor
    {
        private static readonly string PageNotFoundID = Settings.GetSetting("PageNotFound");
        public override void Process(HttpRequestArgs args)
        {
            //Assert.ArgumentNotNull(args, nameof(args));

            //if ((Context.Item != null) || (Context.Database == null))
            //    return;

            //if (args.Url.FilePath.StartsWith("/~/"))
            //    return;

            //var notFoundPage = Context.Database.GetItem(new ID(PageNotFoundID));
            //if (notFoundPage == null)
            //    return;

            //args.ProcessorItem = notFoundPage;
            //Context.Item = notFoundPage;

            if (Context.Item != null || Context.Site == null || Context.Database == null)
            {
                return;
            }

            if (Context.Item == null)
            {
                var notFoundPage = Context.Database.GetItem(new ID(PageNotFoundID));
                Context.Item = notFoundPage;
            }
        }
    }
}