using System.ComponentModel.DataAnnotations;

namespace AECS.Auth.Api.Models
{
    public class ApiTokenModel
    {
        [Required]
        public string Token { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}
