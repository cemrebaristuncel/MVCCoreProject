using AutoMapper;
using MVCCoreProject2.Entities;
using MVCCoreProject2.Models;

namespace MVCCoreProject2
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User, CreateUserModel>().ReverseMap();
            CreateMap<User, EditUserModel>().ReverseMap();
        }
    }
}
