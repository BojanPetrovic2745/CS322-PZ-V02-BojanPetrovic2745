using System.Web;
using System.Web.Mvc;

namespace CS322_PZ_V02_BojanPetrovic2745
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
