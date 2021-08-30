using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using web_api_course_.net_5._0.Models;
using web_api_course_.net_5._0.Services.CharacterService;
using web_api_course_.net_5._0.Controllers;
using web_api_course_.net_5._0.Data;
using Microsoft.EntityFrameworkCore;

namespace web_api_course_.net_5._0
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
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "web_api_course_.net_5._0", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<ICharacterService, CharacterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "web_api_course_.net_5._0 v1"));
            }

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var feature = context.Features.Get<IExceptionHandlerFeature>();
                var exception = feature.Error;

                var result = ErrorHandlerController.HandleError(exception.Message, exception.StackTrace);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));

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
