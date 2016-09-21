using System.Web.Mvc;

namespace Webapplication.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var repo = new Repository.Repository();
            var calculations = repo.GetCalculations();
            return View(calculations);
        }



    }
}