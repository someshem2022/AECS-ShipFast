namespace AECS.Auth.Services.Contract
{
    using SO = AECS.Auth.Services.Models;

    public interface IUserService
    {
        //Task<SO.UserProfileInfoModel> GetUserInfoAsync(SO.UserModel user);

        Task<bool> SignInAsync(string userName, string password);

        Task<bool> Register(SO.UserModel user, bool isAdmin = false);

       
    }
}