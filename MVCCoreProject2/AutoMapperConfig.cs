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
        }
    }
}
