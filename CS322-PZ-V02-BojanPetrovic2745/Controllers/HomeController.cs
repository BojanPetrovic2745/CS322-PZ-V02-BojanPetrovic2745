using System.Web.Mvc;

namespace CS322_PZ_V02_BojanPetrovic2745.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}