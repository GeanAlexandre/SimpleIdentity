using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(SimpleIdentity.Client.Startup))]

namespace SimpleIdentity.Client
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = "http://localhost:8081/",
                ClientId = "client",
                ResponseType = "id_token",
                Scope = "openid",
                SignInAsAuthenticationType = "Cookies",
                RedirectUri = "http://localhost:8082/",
                UseTokenLifetime = false,

            });


            var config = new HttpConfiguration();
            Register(config);
            app.UseWebApi(config);

        }

        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

    }
}
