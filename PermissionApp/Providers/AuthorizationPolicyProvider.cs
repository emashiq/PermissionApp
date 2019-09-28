using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionApp.Providers
{
    public class AuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        public AuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
            : base(options)
        {
        }

        public override Task<AuthorizationPolicy> GetPolicyAsync()
        {
            //if (!policyName.StartsWith(PermissionAuthorizeAttribute.PolicyPrefix, StringComparison.OrdinalIgnoreCase))
            //{
            //    return base.GetPolicyAsync(policyName);
            //}

            //var permissionNames = policyName.Substring(PermissionAuthorizeAttribute.PolicyPrefix.Length).Split(',');

            var policy = new AuthorizationPolicyBuilder()
                .RequireClaim("TestClaims", "")
                .Build();

            return Task.FromResult(policy);
        }
    }
}
