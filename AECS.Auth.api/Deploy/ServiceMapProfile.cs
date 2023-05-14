using AutoMapper;
using AECS.Auth.Api.Models;

namespace AECS.Auth.Api
{
    using SO = AECS.Auth.Services.Models;

    public class ServiceMapProfile : Profile
    {
        public ServiceMapProfile()
        {
            CreateMap<UserModel, SO.UserModel>(MemberList.None)
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
                .ForMember(d => d.ProfileImage, opt => opt.MapFrom(s => s.ProfileImage))
                .ReverseMap();
           
        }
    }
}
