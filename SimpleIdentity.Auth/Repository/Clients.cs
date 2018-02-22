using IdentityServer3.Core;
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
                    ClientName = "The API client",
                    ClientId = "client",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256()),

                    },
                    Flow = Flows.ResourceOwner,
                    AccessTokenType = AccessTokenType.Reference,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:8082/"
                    },

                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:8082/"
                    },

                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        "api"
                    },
                }
        };
    }
}