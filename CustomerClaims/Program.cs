using CustomerClaims.Data;
using CustomerClaims.Interfaces;
using CustomerClaims.Models;
using CustomerClaims.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    // builder.Services.AddDeveloperExceptionPage();
}

// Add appsetting.json support including environmental option
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

ConfigureServices(builder.Services, configuration);
var app = builder.Build();
Configure(app);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();

    // Add JWT configuration here.
    services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));

    // Add the services and interfaces
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<JwtService>();

    // Add JWT Authentication
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:Secret"])),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero // Set this to zero to account for clock differences between the server and the token issuer
            };
        });


    // Register DataLoader as a singleton service
    // This service loads data into memory on application startup
    // and provides access to the loaded data throughout the application
    var dataLoader = new DataLoader();
    dataLoader.LoadData(); // Call the LoadData method here
    services.AddSingleton(dataLoader);

    // Add Swagger documentation generation
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer Claim API", Version = "v1" });

        // Define the security scheme for JWT Bearer token
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme. Enter your token in the text input below without the quotes.",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT"
        });

        // Add the security requirement for JWT Bearer token to all operations
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });
    });
}

void Configure(IApplicationBuilder app)
{
    app.UseRouting();

    // Add JWT Authentication middleware
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Claims API v1");
    });
}
