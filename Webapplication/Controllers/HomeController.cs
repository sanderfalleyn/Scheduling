using System;
using System.Web.Mvc;
using Hangfire;
using Webapplication.Jobs;

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


        public ActionResult GenerateNewCalculation()
        {
            var randomGenerator = new Random();
            var repo = new Repository.Repository();
            var a = randomGenerator.Next(0, 1000);
            var b = randomGenerator.Next(0, 1000);
            var id = BackgroundJob.Schedule(() => repo.SaveNewCalculation(a, b),TimeSpan.FromSeconds(10));
            BackgroundJob.ContinueWith(id,() => Job.Calculate());
            return RedirectToAction("Index");
        }
    }
}