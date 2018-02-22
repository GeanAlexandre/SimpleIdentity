using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace SimpleIdentity.Auth.Repository
{
    public class Clients
    {
        public static IEnumerable<Client> Get() => new[] {
            new Client
            {
                Enabled = true,
                ClientName = "Client",
                ClientId = "client",
                Flow = Flows.Implicit,
                AllowAccessToAllScopes = true,
                RedirectUris = new List<string> { "http://localhost:8082/" }
            }
        };
    }
}