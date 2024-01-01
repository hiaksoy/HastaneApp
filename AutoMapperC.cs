using AutoMapper;
using HastaneApp.Entity;
using HastaneApp.Models;

namespace HastaneApp
{
    public class AutoMapperC:Profile
    {
        public AutoMapperC()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, CreateUserModel>().ReverseMap();
            CreateMap<User, EditUserModel>().ReverseMap();

        }
    }
}
