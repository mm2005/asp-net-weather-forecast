using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services;
using WeatherApp.WebSite.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WeatherApp.WebSite
{
    public class Startup
    {
        private string Config = null;
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                                  });
            });
            Config = Configuration["ConnectionStrings"];
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(Config));
            services.AddTransient<ICurrentWeatherService, CurrentWeatherService>();
            services.AddTransient<WeatherForecastService, WeatherForecastService>();
            services.AddTransient<AutocompleteService, AutocompleteService>();
            services.AddSingleton<FavoriteContext, FavoriteContext>();
            services.AddTransient<IUserRepository, SQLUserRepository>();
            services.AddControllers();
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

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
