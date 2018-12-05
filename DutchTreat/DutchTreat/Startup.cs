using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DutchTreat
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMailService, NullMailService>();

            //Add support for real mail service in the future:

            //ASP.NET Core requires you to use dependency injection.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //Configuring the web server to do something:
            //Using static files only serves files inside the wwwroot directory.
            //Once you start using MVC, you no longer are serving the HTML file,
            //So you don't need the app.UseDefaultFiles() anymore.
            //app.UseDefaultFiles();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();

            //Using jQuery
            app.UseNodeModules(env);

            app.UseMvc(cfg => 
            {
                cfg.MapRoute("Default", "/{controller}/{action}/{id?}", 
                    new { controller = "App",
                        Action = "Index" });
            });


            //Default code:

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //A Lamda expression that says anytime a request comes in, write out Hello
            //World.
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
