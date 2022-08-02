using Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;


namespace PouyanSiteStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();
            using (var scop = host.Services.CreateScope())
            {
                var services = scop.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    var _configuration = services.GetRequiredService<IConfiguration>();
                    context.Database.Migrate();
                    Seed.SeedData(context, _configuration).Wait();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
