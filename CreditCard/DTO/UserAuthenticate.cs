using CreditCardApi.Models;

namespace CreditCardApi.DTO
{
    public class UserAuthenticate
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public Role Role { get; set; }
    }
}
