using System.Web;
using System.Web.Mvc;

namespace TranVanQuyen_1911062548
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
