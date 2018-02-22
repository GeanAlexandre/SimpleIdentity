using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Validation;
using Microsoft.Owin;
using Owin;
using Serilog;
using SimpleIdentity.Auth.Repository;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(SimpleIdentity.Auth.Startup))]

namespace SimpleIdentity.Auth
{
    public class Startup
    {

        public static void Configuration(IAppBuilder app)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace()
                .CreateLogger();

            var factory = new IdentityServerServiceFactory()
                         .UseInMemoryUsers(Users.Get())
                         .UseInMemoryClients(Clients.Get())
                         .UseInMemoryScopes(Scopes.Get());

            app.UseIdentityServer(new IdentityServerOptions
            {
                SiteName = "Simple Identity",
                SigningCertificate = GetCertificate(),
                RequireSsl = false,
                Factory = factory,
                AuthenticationOptions = new AuthenticationOptions
                {
                    EnablePostSignOutAutoRedirect = true,
                    EnableSignOutPrompt = false,
                },
            });

        }
        static X509Certificate2 GetCertificate()
        {
            var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            var certPath = Path.Combine(baseDir, "idsrv3test.pfx");
            return new X509Certificate2(certPath, "idsrv3test");
        }

    }
}
