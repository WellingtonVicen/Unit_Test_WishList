using API.ViewModels;
using AutoMapper;
using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.DTO;
using Services.Interfaces;
using Services.Services;
using System;
using System.Reflection;

namespace WishList.Domain.Test
{
    public class StartupT
    {
        public StartupT(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddApplicationPart(Assembly.Load("API")).AddControllersAsServices();

            #region AutoMapper
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, ItemDTO>().ReverseMap();
                cfg.CreateMap<CreateViewModel, ItemDTO>().ReverseMap();
                cfg.CreateMap<UpdateViewModel, ItemDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());
            #endregion



            services.AddDbContext<ItemContext>(options =>
            {
                options.UseInMemoryDatabase("MyDataBase-" + Guid.NewGuid());
            });
            services.AddScoped<IitemService, ItemService>();
            services.AddScoped<IitemRepository, ItemRepository>();


           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



        }
    }
}
