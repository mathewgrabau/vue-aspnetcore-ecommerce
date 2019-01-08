using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace FirstProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            // Creating the migration that will ensure the migrations are completed and database is seeded before running.
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<FirstProjectContext>();

                dbContext.Database.Migrate();
                dbContext.EnsureSeeded();
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
