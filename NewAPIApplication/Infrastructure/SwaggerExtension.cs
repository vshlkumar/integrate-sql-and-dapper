using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace APIApplication.Infrastructure
{
    public static class SwaggerExtension
    {
        static readonly string DEFAULT_SCHEME = "Bearer";
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition(DEFAULT_SCHEME, new OpenApiSecurityScheme
                {
                    Description = "Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = DEFAULT_SCHEME,
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = DEFAULT_SCHEME
                            },
                         },
                         new string[] {}
                    }
                });

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                // To enable this you have to go to the properties of your API project 
                // Check mark the checkbox of XML Documentation file and leave the xml path default for a while
                // Add 1591 in the Suppress Warning, it will give the warning for class where we do not add the 
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);               
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c=> {
                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer>();
                });
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.DefaultModelsExpandDepth(-1);
                c.DisplayRequestDuration();
                c.DocExpansion(DocExpansion.List);
            });
            return app;
        }
    }
}
