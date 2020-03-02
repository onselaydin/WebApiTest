﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiTest.Data;

namespace WebApiTest
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
            //services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddEntityFrameworkNpgsql().AddDbContext<DataContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("PostConn")));
            services.AddAutoMapper();
            //services.AddMvc().AddJsonOptions(opt=> {
            //    opt.SerializerSettings.ReferanceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //});
            services.AddControllers();
            services.AddCors();
            services.AddScoped<IAppRepository,AppRepository>(); //olurda bir controller senden bu Interfacei isterse onun karışılığı AppRepositorydir.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
