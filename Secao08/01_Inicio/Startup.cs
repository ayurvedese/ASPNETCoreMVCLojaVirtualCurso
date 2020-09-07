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
             *Ex: https://www.site.com.br -> para qual controlador? (Fun��o da gest�o das requisi��es) -> quem define isso s�o as rotas, caminhos que nos leva a determinado controlador
             *Ex2: https://www.site.com.br/{caminho}?{querystring}#{fragmento}
             * O caminho � um par�metro personalis�vel e o sistema interpreta e acha o caminho de fato.
             * Entendendo a URL no MVC -> https://www.site.com.br/Produto/Visualizar/MouseRazorzk
             * ou https://www.site.com.br/Produto/Visualizar/10
             * ou https://www.site.com.br/Produto/Visualizar/ -> listagem de todos os par�metros.
             * Explica��o: no link acima "Produto" ser� uma classe e "Visualizar" ser� um m�todo e o c�digo seria exatamente o id do produto ou pelo nome (� opcional).
             *
             * Ex3: https://www.site.com.br/Produto/ -> neste caso se eu n�o passar a fun��o do controlador ele vai chamar o �ndex de produto, ou seja, https://www.site.com.br/Produto/Index
             * Da mesma forma se eu n�o passar controlador nenhum, ele vai chamar o �ndex da minha p�gina, ou seja https://www.site.com.br/Home/Index
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
