using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CustomerClaims.Filters
{
    // OperationFilter to add the "Authorize" button to the Swagger UI
    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        private bool _hasAddedSecurityRequirements = false;

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (!_hasAddedSecurityRequirements)
            {
                var authAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                    .Union(context.MethodInfo.GetCustomAttributes(true))
                    .OfType<AuthorizeAttribute>();

                if (authAttributes.Any())
                {
                    operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
                    operation.Security = new List<OpenApiSecurityRequirement>
                    {
                        new OpenApiSecurityRequirement
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    }
                                },
                                new List<string>()
                            }
                        }
                    };
                }

                _hasAddedSecurityRequirements = true;
            }
        }
    }
}
