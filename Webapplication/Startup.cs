using System;
using System.Configuration;
using Hangfire;
using Microsoft.Owin;
using Owin;
using Webapplication;
using Webapplication.Jobs;

[assembly: OwinStartup(typeof(Startup))]

namespace Webapplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["hangfire"].ConnectionString;
            GlobalConfiguration.Configuration
                .UseSqlServerStorage(connectionString);

            app.UseHangfireDashboard();
            app.UseHangfireServer();




        }
    }
}
