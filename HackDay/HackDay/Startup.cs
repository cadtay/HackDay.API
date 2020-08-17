using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackDay.Repository;
using HackDay.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HackDay
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
            services.AddHttpClient();

            services.AddControllers();

            services.AddHttpClient("street-level-all-crimes", slc =>
            {
                slc.BaseAddress = new Uri(Configuration.GetValue<string>("StreetLevelAllCrimesAPI"));
            });

            services.AddHttpClient("street-level-crimes", slc =>
            {
                slc.BaseAddress = new Uri(Configuration.GetValue<string>("StreetLevelCrimesByCategoryAPI"));
            });

            services.AddHttpClient("street-level-outcomes", slc =>
            {
                slc.BaseAddress = new Uri(Configuration.GetValue<string>("StreetLevelOutcomesAPI"));
            });

            services.AddHttpClient("street-level-crime-categories", slc =>
            {
                slc.BaseAddress = new Uri(Configuration.GetValue<string>("StreetLevelCrimeCategoriesAPI"));
            });

            services.AddScoped<IStreetLevelCrimesRepo, CallStreetLevelCrimeApiRepo>();
          
            services.AddScoped<IFloodRepository, FloodRepository>();
            services.AddScoped<IStopSearchRepository, StopSearchRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
