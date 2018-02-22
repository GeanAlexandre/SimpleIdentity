using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using Microsoft.Owin;
using Owin;
using SimpleIdentity.Auth.Repository;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

[assembly: OwinStartup(typeof(SimpleIdentity.Auth.Startup))]

namespace SimpleIdentity.Auth
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseIdentityServer(new IdentityServerOptions
            {
                SiteName = "Simple Identity",
                SigningCertificate = GetCertificate(),
                RequireSsl = false,
                Factory = new IdentityServerServiceFactory()
                             .UseInMemoryUsers(Users.Get())
                             .UseInMemoryClients(Clients.Get())
                             .UseInMemoryScopes(StandardScopes.All)
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
