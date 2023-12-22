using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SS.Service;

namespace SS.Core{
    public class Startup{

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration){
            this.Configuration = configuration;
            Console.WriteLine("Hello World");
        }

        public void ConfigureServices(IServiceCollection services){
            Console.WriteLine("Start Config Service");

            ConfigApiVersion(services);
            ConfigDBContext(services);

            services.AddScoped<IStreamingRepo, StreamingRepo>();
            services.AddScoped<StreamingService, StreamingService>();

            services.AddControllers();
            
        }

        private void ConfigApiVersion(IServiceCollection services){
            services.AddApiVersioning(option =>{
                option.DefaultApiVersion = new ApiVersion(1, 0);
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.ReportApiVersions = true;
            });
        }

        private void ConfigDBContext(IServiceCollection services){
            services.AddDbContext<Infrastructure.StreamingDbContext_pgsql>(option => 
                option.UseNpgsql(this.Configuration.GetConnectionString("pgsql")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env ){
            
            if(env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }else{
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithReExecute("Home/Error/{0}");
                app.UseHsts();
            }
            // Middleware setting
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints=>{
                endpoints.MapControllers();
                endpoints.MapGet("/", async context => {
                    await context.Response.WriteAsync("Hello, World!");
                });
            });

        }
    }
}