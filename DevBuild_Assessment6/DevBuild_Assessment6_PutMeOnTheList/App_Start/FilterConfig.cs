using System.Web;
using System.Web.Mvc;

namespace DevBuild_Assessment6_PutMeOnTheList
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
