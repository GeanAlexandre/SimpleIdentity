using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(SimpleIdentity.Client.Startup))]

namespace SimpleIdentity.Client
{

    public class Startup
    {

        public static void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://localhost:8081",
                RequiredScopes = new[] { "api" }
            });

            var config = new HttpConfiguration();
            Register(config);
            app.UseWebApi(config);
        }

        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new AuthorizeAttribute());
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

    }
}
