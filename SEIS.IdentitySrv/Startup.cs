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

namespace SEIS.IdentitySrv
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
            // Added when we add the IS4 UI 
            services.AddMvc(option => option.EnableEndpointRouting = false);

            // Plug-in our identity server middleware
            services.AddIdentityServer()
                // Create a Temporary Key in Development environment tempkey.rsa
                .AddDeveloperSigningCredential()
                //Client will have access to the WebAPI Resource RegistrationAPI
                .AddInMemoryApiResources(Config.GetAllApiResources())
                //What are the clients that need to be registered in IdentityServer
                //for which IdentityServer needs to provide permissions to access resources.
                .AddInMemoryClients(Config.GetClients())
                // Add the in-memory test users for testing 
                .AddTestUsers(Config.GetTestUsers())
                // Add the Open-ID Connect Identity scope
                .AddInMemoryIdentityResources(Config.GetidentityResources());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // We are going to plug-in the pipeline and use the identity service
            app.UseIdentityServer();

            // We are going to allow for static files for the wwwroot (css, js, lib, html)
            app.UseStaticFiles();

            // Use MVC with default route
            app.UseMvcWithDefaultRoute();
        }
    }
}
