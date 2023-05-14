namespace AECS.Auth.Repository
{
    using AutoMapper;
    using DO = AECS.Auth.Data.Models;
    using IO = AECS.Auth.Data.Models.Identity;
    using SO = AECS.Auth.Services.Models;

    public class RepositoryMapProfile : Profile
    {
        public RepositoryMapProfile()
        {
            

            CreateMap<SO.UserModel, IO.User>(MemberList.None)
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.ProfileImage, opt => opt.MapFrom(s => s.ProfileImage))
               .ReverseMap();
           

           
        }
    }
}