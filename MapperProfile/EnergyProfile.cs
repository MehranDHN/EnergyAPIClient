using AutoMapper;
using EnergyApiClient.DomainModels.DTO;
using EnergyApiClient.DomainModels.Models;
using EnergyAPIClient.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyAPIClient.MapperProfile
{
    public class EnergyProfile : Profile
    {

        public EnergyProfile()
        {
            CreateMap<PowerSrcInfo, PowerSrcInfoDto>().ForMember(dest => dest.buildingId, opt => opt.MapFrom(src => src.TargetCounter != null ? src.TargetCounter.LocationID : 0));
        }

    }
}
