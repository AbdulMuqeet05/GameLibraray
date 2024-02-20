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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace GameLibrary
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

            services.AddDbContext<GameLibrary.Model.GameLibraryContext>(option =>
                        option.UseMySql(Configuration.GetConnectionString("mysqlconnection"),sqloptions => {
                            sqloptions.EnableRetryOnFailure(maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(3),
                            errorNumbersToAdd:null);
                        })
                        .EnableSensitiveDataLogging());
            //services.AddScoped<Fixit.Controllers.ValuesController>();
            services.AddDirectoryBrowser();
            // Add framework services.
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();

            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession();
            /*Adding swagger generation with default settings*/

           

            services.AddCors(options =>
    {
        options.AddPolicy("AllowAllHeaders",
              builder =>
          {
              builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
          });
    });








        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            // Shows UseCors with named policy.
            app.UseCors("AllowAllHeaders");

            // app.UseHttpsRedirection();

            app.UseMvc();

        }
    }
}
