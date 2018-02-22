using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace SimpleIdentity.Auth.Repository
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
        {
            new InMemoryUser
            {
                Subject = Guid.NewGuid().ToString(),
                Username = "gean",
                Password = "alexandre",
                Enabled = true,
                
            }
        };
        }
    }
}