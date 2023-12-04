using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SS.Core{
    public class Startup{

        public IConfiguration configuration { get; }
        public Startup(IConfiguration configuration){
            this.configuration = configuration;
            Console.WriteLine("Hello World");
        }

        public void ConfigureServices(IServiceCollection services){

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env ){

        }
    }
}