using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Test.Novaon.Web.Infrastructure.Data;
using Test.Novaon.Web.Interfaces;
using Test.Novaon.Web.Logging;
using Test.Novaon.Web.Services;

namespace Test.Novaon.Web
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
            services.AddDbContext<AppDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CategoryDbConnection"), b => { b.UseRowNumberForPaging(); b.MigrationsAssembly("Test.Novaon.Web");}));
            services
               .AddMvc()
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
               .AddJsonOptions(opt =>
               {
                   opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                   opt.SerializerSettings.SerializationBinder = new DefaultSerializationBinder();
                   opt.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
               });
            services.AddSingleton(Configuration);
            services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUserSevice, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
