
using Microsoft.Extensions.DependencyInjection;
using MS.Establishment.Infra.DataAccess.Context;
using MS.Establishment.Infra.DataAccess.Repositories;
using MS.Establishment.Infra.DataAccess.Repositories.interfaces;
using MS.Establishment.Services;
using MS.Establishment.Services.Interfaces;
using MS.Establishment.Utils.Validator;
using System.IdentityModel.Tokens.Jwt;

namespace MS.Establishment.Infra
{
    public static class DependencyInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<EstablishmentContext>();

            //services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<JwtSecurityTokenHandler>();

            //services.AddScoped<IDateTimeNowProvider, DateTimeNowProvider>();

            //services.AddScoped<ISigningAudienceCertificate, SigningAudienceCertificate>();
            //services.AddScoped<ISigningIssuerCertificate, SigningIssuerCertificate>();


            services.AddScoped<IEstablishmentService, EstablishmentService>();
            services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();

            services.AddScoped<IValidator, CNPJValidator>();
        }
    }
}
