using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;

namespace MyLogging
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string path = Directory.GetCurrentDirectory()+@"\logs\"+DateTime.Now.ToString("yyyy-MM-dd")+".log";
            if (!File.Exists(path)){
                Trace.Listeners.Add(new TextWriterTraceListener( File.CreateText(path))); 
            } else {
                Trace.Listeners.Add(new TextWriterTraceListener( File.AppendText(path)));
            }

            if (env.IsDevelopment())
            {
                Trace.AutoFlush = true;
                app.UseDeveloperExceptionPage();
            } else {
                Trace.AutoFlush = false;
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
