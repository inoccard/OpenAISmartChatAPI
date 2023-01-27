using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using System.Text;

namespace OpenAI.SmartChat.API.Configs.Swagger;

public static class SwaggerConfiguration
{
    public static void AddVersionedSwagger(this IServiceCollection services)
    {
        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        services.AddApiVersioning();

        //add swagger json generation
        services.AddSwaggerGen(options =>
        {
            options.CustomSchemaIds(p => p.FullName);

            var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

            foreach (var description in provider.ApiVersionDescriptions)
            {
                var version = typeof(SwaggerConfiguration).Assembly.GetName().Version;

                var apiInfoDescription = new StringBuilder("OpenAI.SmartChat.API");
                //describe the info
                var info = new OpenApiInfo
                {
                    Title = $"{apiInfoDescription} {description.GroupName}",
                    Version = version?.ToString(),
                    Description = "This WebAPI serves as the basis for openai.com's ChatGPT implementation. Ask questions in any language and Chat will respond.",
                    Contact = new OpenApiContact() { Name = "Inocêncio Cardoso", Email = "inocenciocardoso19@gmail.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                };

                if (description.IsDeprecated)
                {
                    apiInfoDescription.Append(" This API version has been deprecated.");
                    info.Description = apiInfoDescription.ToString();
                }

                options.SwaggerDoc(description.GroupName, info);
                options.OperationFilter<DefaultHeaderFilter>();
            }

            //set default for non body parameters
            options.ParameterFilter<DefaultParametersFilter>();

            var securityDefinition = new OpenApiSecurityScheme
            {
                Description = "Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            };

            options.AddSecurityDefinition(IdentityServerAuthenticationDefaults.AuthenticationScheme, securityDefinition);

            var openApiSecurityScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            };

            options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    openApiSecurityScheme,
                    Array.Empty<string>()
                }});
        });
    }

    public static void UseVersionedSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
    {
        app.UseSwagger();

        //create the UI for swagger
        app.UseSwaggerUI(
            options =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                    options.RoutePrefix = string.Empty;
                }
            });
    }
}