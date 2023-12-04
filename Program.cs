// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SS.Core{
    public class Program{
        public static void Main(string[] agrs){
            CreateHostBuilder(agrs).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] agrs ) =>
            Host.CreateDefaultBuilder(agrs).ConfigureWebHostDefaults(webBuilder => {
                webBuilder.UseStartup<Startup>();
            });
    }
}
