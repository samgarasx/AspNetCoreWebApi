using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebApi.Data.Repositories;
using System.Text;

namespace AspNetCoreWebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
                builder.AddUserSecrets<Startup>();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionStringBuilder = new StringBuilder(
                "Server=SERVER;Database=DATABASE;Username=USERNAME;Password=PASSWORD");

            connectionStringBuilder.Replace("SERVER", Configuration["Database:Server"]);
            connectionStringBuilder.Replace("DATABASE", Configuration["Database:Name"]);
            connectionStringBuilder.Replace("USERNAME", Configuration["db.user"]);
            connectionStringBuilder.Replace("PASSWORD", Configuration["db.password"]);
            
            services.AddDbContext<FruitContext>(options => 
                options.UseNpgsql(connectionStringBuilder.ToString()));    

            services.AddMvc();

            services.AddScoped<IFruitRepository, FruitRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
