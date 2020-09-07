using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LojaVirtual
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
            services.AddControllersWithViews();
            services.AddMvc().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            //app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCookiePolicy();

            /*
             *Ex: https://www.site.com.br -> para qual controlador? (Função da gestão das requisições) -> quem define isso são as rotas, caminhos que nos leva a determinado controlador
             *Ex2: https://www.site.com.br/{caminho}?{querystring}#{fragmento}
             * O caminho é um parâmetro personalisável e o sistema interpreta e acha o caminho de fato.
             * Entendendo a URL no MVC -> https://www.site.com.br/Produto/Visualizar/MouseRazorzk
             * ou https://www.site.com.br/Produto/Visualizar/10
             * ou https://www.site.com.br/Produto/Visualizar/ -> listagem de todos os parâmetros.
             * Explicação: no link acima "Produto" será uma classe e "Visualizar" será um método e o código seria exatamente o id do produto ou pelo nome (é opcional).
             *
             * Ex3: https://www.site.com.br/Produto/ -> neste caso se eu não passar a função do controlador ele vai chamar o índex de produto, ou seja, https://www.site.com.br/Produto/Index
             * Da mesma forma se eu não passar controlador nenhum, ele vai chamar o índex da minha página, ou seja https://www.site.com.br/Home/Index
             */

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
