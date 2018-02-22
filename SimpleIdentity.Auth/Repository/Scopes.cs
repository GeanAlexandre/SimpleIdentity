using IdentityServer3.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleIdentity.Auth.Repository
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            var scopes = new List<Scope>
        {
                new Scope
            {
    Enabled = true,
    DisplayName = "Sample API",
    Name = "api",
    Description = "Access to a sample API",
    Type = ScopeType.Resource,
}
        };

            scopes.AddRange(StandardScopes.All);

            return scopes;
        }
    }
}