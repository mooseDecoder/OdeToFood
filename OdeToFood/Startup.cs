using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OdeToFood.Data;
using OdeToFood.Services;

namespace OdeToFood
{
    //purpose of Startup class is so you can reigster your custom services so .net core can use
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //lifetime of services: Singleton: only need one instance for entire app, Transient: if an interface is needed, create
            //a new instance, Scoped: create a service that is scoped to a spcific request and is reused in that request then discarded.

            //This basically says: When someone asks for service that implements IGreeter, use an instance of the Greeter class.
            services.AddSingleton<IGreeter, Greeter>();
            //note we can get the conneciton string via _configuration which we injected in the ctor. The appsettings.json file under ConnectionStrings
            //will hold anything we put there as accessible here - in this case, 'ConnectionStrings': {'OdeToFood': ....
            services.AddDbContext<OdeToFoodDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("OdeToFood")));
            //having a DbContext as  sSingleton is not thread safe so use Scoped.
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration, IGreeter greeter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        
            app.UseStaticFiles();
            app.UseMvc(ConfigureRoutes);


            //this code runs on every request that is recieved.
            app.Run(async (context) =>
            {
                
                var greeting = greeter.GetMessageOfTheDay();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"not found");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //  /Home/Index/#(optional)
            routeBuilder.MapRoute("Default", "{controller}/{action}/{id?}");
        }
    }
}
