using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Core1
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public Startup(IHostingEnvironment env)
        {
            _hostingEnvironment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<ISensorDataService, SensorDataService>();
            services.AddScoped<IViewModelService, ViewModelService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            //var logger = loggerFactory.CreateLogger("info");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("before");
            //    //await context.Response.WriteAsync("Hello World!");
            //    await next();
            //    logger.LogInformation("after");
            //});
            //app.Run(async (context) =>
            //{
            //    logger.LogInformation("next one");
            //    await context.Response.WriteAsync("Hello World 2!");
            //});

            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();

        }
    }
}
