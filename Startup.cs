using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using InterviewAPI.Models;

namespace InterviewAPI
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
            //add mvc vs add mvc core  ( mvc core metohd has not output format and we have to add formmater as chain method )
            //services.AddMvcCore().AddJsonFormatters();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc();

            // ConfigureServices  method to register our ApplicationContext as a service for EF DI 
            services.AddDbContext<InterviewAPIContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("InterviewAPIContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //to get the static files to browser in in wwwroot folder / need to enable this property 
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}
