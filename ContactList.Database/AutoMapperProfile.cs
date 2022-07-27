using AutoMapper;
using ContactList.Database.Models;
using ContactList.Domain.Models;

namespace ContactList.Database
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Contact, ContactDisplayListDto>().ReverseMap();
            CreateMap<ApplicationUser, CreateApplicationUserDto>().ReverseMap();
            CreateMap<ApplicationUser, LoginApplicationUserDto>().ReverseMap();
        }
    }
}
