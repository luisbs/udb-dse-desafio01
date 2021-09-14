using System.Web;
using System.Web.Mvc;

namespace udb_dse_desafio01
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
