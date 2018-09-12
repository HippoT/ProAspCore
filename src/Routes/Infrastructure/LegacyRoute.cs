using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Routes.Models;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Internal;

namespace Routes.Infrastructure
{
    public class LegacyRoute : IRouter
    {
        private string[] urls;
        private IRouter mvcRouter;

        public LegacyRoute(IServiceProvider services, params string[] targetUrls)
        {
            urls = targetUrls;
            mvcRouter = services.GetRequiredService<MvcRouteHandler>();
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            if (context.Values.ContainsKey("legacyUrl"))
            {
                string url = context.Values["legacyUrl"] as string;
                if (urls.Contains(url))
                {
                    return new VirtualPathData(this, url);
                }
            }
            return null;
        }

        public async Task RouteAsync(RouteContext context)
        {
            string requestedUrl = context.HttpContext.Request.Path.Value.TrimEnd('/');
            if (urls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase))
            {
                context.RouteData.Values["controller"] = "Legacy";
                context.RouteData.Values["action"] = "GetLegacyUrl";
                context.RouteData.Values["legacyUrl"] = requestedUrl;
                await mvcRouter.RouteAsync(context);
                //context.Handler = async ctx => {
                //    HttpResponse response = ctx.Response;
                //    byte[] bytes = Encoding.ASCII.GetBytes($"URL: {requestedUrl}");
                //    await response.Body.WriteAsync(bytes, 0, bytes.Length);
                //};
            }
        }
    }
}
