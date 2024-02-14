using AutoMapper;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            this.CreateMap<PlatformModel, PlatformReadDto>();
            this.CreateMap<PlatformCreateDto, PlatformModel>();
        }
    }
}