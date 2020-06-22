using System.Web;
using System.Web.Mvc;

namespace ExamenI_CertificacionI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
