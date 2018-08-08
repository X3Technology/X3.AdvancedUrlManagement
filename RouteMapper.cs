using DotNetNuke.Web.Api;
using System.Web.Http;

namespace X3.AdvancedUrlManagement
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute(
                moduleFolderName: "X3.AdvancedUrlManagement",
                routeName: "default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional
                },
                namespaces: new[] { "X3.AdvancedUrlManagement" });
        }
    }
}