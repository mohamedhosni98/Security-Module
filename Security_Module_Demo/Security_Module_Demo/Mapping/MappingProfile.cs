using AutoMapper;
using Security_Module_Demo.Dtos;
using Security_Module_Demo.Models;

namespace Security_Module_Demo.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, ApplicationUser>().ReverseMap();
        }
    }
}
