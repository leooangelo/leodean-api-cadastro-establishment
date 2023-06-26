using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS.Establishment.Config;
using MS.Establishment.Domain.Middlewares;
using MS.Establishment.Infra;
using MS.Establishment.Infra.DataAccess.Context;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers()
    .AddNewtonsoftJson(j =>
    {
        j.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        j.SerializerSettings.Formatting = Formatting.Indented;
        j.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

builder.Services.AddHttpContextAccessor();


builder.Services.AddDbContext<EstablishmentContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("EstablishmentContext")),
    ServiceLifetime.Transient);

//builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();

//builder.Services.AddAsymmetricAuthentication(configuration);

builder.Services.AddAutoMapperConfiguration();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

DependencyInjector.RegisterServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();