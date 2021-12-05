using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc.Razor;
using DevMarcos.UI.Site.Modulos.Vendas.Interfaces;
using DevMarcos.UI.Site.Modulos.Vendas.Data;
using DevMarcos.UI.Site.Servicos;
using DevMarcos.UI.Site.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DevMarcos.UI.Site.Modulos.Identity.Data;
using Microsoft.AspNetCore.Identity;
using DevMarcos.UI.Site.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace DevMarcos.UI.Site
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Configura o novo repositório de Area apontandop para pasta Modulos 
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            services.AddDbContext<MeuDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("MeuDbContext"))
                );

            services.AddDbContext<AspNetCoreIdentityContext>(options =>
                  options.UseSqlite(
                      Configuration.GetConnectionString("AppIdentityContext")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<AspNetCoreIdentityContext>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("PodeExcluir", policy => policy.RequireClaim("PodeExcluir"));

                options.AddPolicy("PodeLer", policy => policy.Requirements.Add(new PermissaoNecessaria("PodeLer")));
                options.AddPolicy("PodeEscrever", policy => policy.Requirements.Add(new PermissaoNecessaria("PodeEscrever")));

            });  

            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<IPedidoRepository, PedidoRepository>();

            services.AddTransient<IOperacaoTransient, Operacao>();
            services.AddScoped<IOperacaoScoped, Operacao>();
            services.AddSingleton<IOperacaoSingleton, Operacao>();
            services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty));

            services.AddSingleton<IAuthorizationHandler, PermissaoNecessariaHandler>(); // Registra classe que controla permissão

            services.AddTransient<OperacaoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc( routes =>
            {
               
             //   routes.MapRoute(
             //        name: "areas",
             //        template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
             //      );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                 name: "AreaProdutos",
                 areaName: "Produtos",
                 template: "Produtos/{controller=Cadastro}/{action=Index}/{id?}"
                 );
                routes.MapAreaRoute(
                    name: "AreaVendas",
                    areaName: "Vendas",
                    template: "Vendas/{controller=Pedidos}/{action=Index}/{id?}"
                    );


            });
        }
    }
}
