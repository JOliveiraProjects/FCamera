using FCamera.Application.Automapper;
using FCamera.Autentica.API.Middleware;
using FCamera.Infra.CrossCutting.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ConsigaMais.Autentica.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddGlobalExceptionHandlerMiddleware();      

            // Ajustes relacionados à GDPR
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // habilita a gravacao de sessao.
            services.AddSession(opts =>
            {
                opts.Cookie.IsEssential = true; // make the session cookie Essential
            }); 
            services.AddResponseCompression(); // Comprimir todas as requisicoes.
            services.AddHttpContextAccessor();

            new NativeDependencyInjection().Configure(services, Configuration);
            AutoMapperConfig.RegisterMappings();

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Info
                {
                    Title = "Autentica HTTP API",
                    Version = "v1",
                    Description = "Serviço Autentica HTTP API"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var pathBase = Configuration["PATH_BASE"];
            if (!string.IsNullOrEmpty(pathBase))
            {
                app.UsePathBase(pathBase);
            }

            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty) }/swagger/v1/swagger.json", "Autentica.API V1");
               });

            app.UseHsts();
            app.UseGlobalExceptionHandlerMiddleware();
            app.UseResponseCompression(); // Comprimir todas as requisicoes.
            app.UseHttpsRedirection(); // Redireciona todas as chamadas para HTTPS
            app.UseCookiePolicy(); // Ajuste relacionado à GDPR
            app.UseMvc();
        }
    }
}
