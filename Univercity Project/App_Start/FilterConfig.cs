using System.Web.Mvc;

namespace Univercity_Project.App_Start
{
    class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
