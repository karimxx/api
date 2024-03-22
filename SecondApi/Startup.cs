using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Interfaces;
using Core.Entities;
using AutoMapper;
using SecondApi.Helpers;
using SecondApi.Middelware;
using SecondApi.Errors;
using SecondApi.Extientions;
namespace SecondApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
      

// Your other routes and middleware

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
       
            services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer("Server=.\\SQLEXPRESS;Database=APIDatabase;Trusted_Connection=True;TrustServerCertificate=True");
            });
            services.AddApplicationServices();
            services.AddControllers();
            services.AddSwaggerDocumentation();
      

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
       .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseSwaggerDocumentation();
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
         

        }

    }
}
