using System;
using System.Web.Mvc;
using Hangfire;

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
            BackgroundJob.Enqueue(() => repo.SaveNewCalculation(a, b));

            return RedirectToAction("Index");
        }
    }
}