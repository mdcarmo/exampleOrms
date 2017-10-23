using CrossCutting;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Swashbuckle.Application;
using System.Web.Http;
using Unity;

[assembly: OwinStartup(typeof(Api.Startup))]

namespace Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //to remove XML format
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            //modifies the indentation
            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //setting up routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );

            //configure swagger to show your services
            config.EnableSwagger(c =>
            {
                c.IncludeXmlComments(string.Format(@"{0}\bin\Api.XML", System.AppDomain.CurrentDomain.BaseDirectory));
                c.SingleApiVersion("V1", "Exemplo Orms -  Layer Services")
                    .Description("Serviços para integração com o Exemplo ORMS")
                    .TermsOfService("None")
                    .Contact(cc => cc.Name("Marcelo Dias")
                        .Email("marc29dias@yahoo.com.br"));
            })
                .EnableSwaggerUi(c =>
                {
                    c.DisableValidator();
                    c.InjectStylesheet(typeof(Startup).Assembly,
                        "Api.SwaggerExtensions.theme-override.css");
                });
            
            //configure UNITY for DI
            var container = new UnityContainer();
            DependencyRegister.Register(container);
            config.DependencyResolver = new UnityResolver(container);
            
            app.UseWebApi(config);
        }
    }
}
