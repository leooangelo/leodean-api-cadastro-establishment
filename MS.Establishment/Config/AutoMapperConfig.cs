using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MS.Establishment.Domain.DTO;
using MS.Establishment.Domain.Entities;
using MS.Establishment.Domain.ViewModel;
using System;

namespace MS.Establishment.Config
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EstablishmentDTO, EstablishmentDomain>().ReverseMap();
                cfg.CreateMap<EstablishmentUpdateDTO, EstablishmentDomain>().ReverseMap();

                cfg.CreateMap<EstablishmentDomain, ResponseEstablishmentDTO>().ReverseMap();

                cfg.CreateMap<EstablishmentViewModel, EstablishmentDTO>().ReverseMap();
                cfg.CreateMap<EstablishmentUpdateViewModel, EstablishmentUpdateDTO>().ReverseMap();
                cfg.CreateMap<EstablishmentUpdateEmailViewModel, EstablishmentUpdateEmailDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());
        }
    }
}