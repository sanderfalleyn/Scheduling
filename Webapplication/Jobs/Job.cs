using System.Linq;

namespace Webapplication.Jobs
{
    public static class Job
    {
        public static void Calculate()
        {
            var repo = new Repository.Repository();
            var calculation = repo.GetCalculations();
            foreach (var cal in calculation.Where(c => c.DateProcessed == null))
            {
                var som = cal.A + cal.B;
                repo.UpdateCalculation(cal.Id,som);
            }
        }
    }
}