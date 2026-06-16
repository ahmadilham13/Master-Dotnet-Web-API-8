using System.Globalization;
using System.Reflection;
using Api.Configs;
using Api.Helpers;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "AllowAll", builder =>
    {
        builder
            .SetIsOriginAllowed(origin => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

// Register localization service for supporting multiple language
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


builder.Services.Configure<RequestLocalizationOptions>(
options =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new("id-ID"),
        new("en-US"),
    };

    options.DefaultRequestCulture = new RequestCulture("id-ID");
    // Formatting numbers, dates, etc.
    options.SupportedCultures = supportedCultures;
    // UI strings that we have localized.
    options.SupportedUICultures = supportedCultures;

    options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
    {
        var languages = context.Request.Headers.AcceptLanguage.ToString();
        var currentLanguage = languages.Split(',').FirstOrDefault();
        var defaultLanguage = string.IsNullOrEmpty(currentLanguage) ? "id-ID" : currentLanguage;

        if (defaultLanguage != "id-ID" && defaultLanguage != "en-US")
        {
            defaultLanguage = "id-ID";
        }

        return Task.FromResult(new ProviderCultureResult(defaultLanguage, defaultLanguage));
    }));
});

builder.Services.AddControllers();

string dbConfig = builder.Configuration.GetConnectionString("ApiDatabase");

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(dbConfig, ServerVersion.AutoDetect(dbConfig), x => x.UseNetTopologySuite());
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Api Web API",
        Description = ".NET Web API for Api App",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "John Doe",
            Email = string.Empty,
            Url = new Uri("https://google.com/"),
        },
        License = new OpenApiLicense
        {
            Name = "Use under LICX",
            Url = new Uri("https://example.com/license"),
        }
    });
    c.SwaggerDoc("internal-v1", new OpenApiInfo
    {
        Version = "internal-v1",
        Title = "Api Internal API",
        Description = ".NET Internal API for Others App",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "John Doe",
            Email = string.Empty,
            Url = new Uri("https://google.com/"),
        },
        License = new OpenApiLicense
        {
            Name = "Use under LICX",
            Url = new Uri("https://example.com/license"),
        }
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        Array.Empty<string>()
                    }
                });

    c.DocumentFilter<SwaggerDocumentFilter>();
    c.OperationFilter<HeaderForInternalApiFilter>();

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


// Redis

// Repositories

// Services

builder.Services.AddHttpContextAccessor();

// Config
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


// HSTS
builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(60);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x => {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", ".NET Web API for Api App");
        x.SwaggerEndpoint("/swagger/internal-v1/swagger.json", ".NET Internal API for Others App");
    });
}

else
{
    // app.UseHttpsRedirection();
    app.UseHsts();
}

app.MapControllers();

app.UseCors("AllowAll");

// app.UseMiddleware<ErrorHandlerMiddleware>();
// app.UseMiddleware<JwtMiddleware>();
// app.UseMiddleware<TimeLimitMiddleware>();
// app.UseMiddleware<CronMiddleware>();

app.Run();