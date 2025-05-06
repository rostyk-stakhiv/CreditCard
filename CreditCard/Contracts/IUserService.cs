using CreditCardApi.DTO;
using CreditCardApi.Models;
using System.Collections.Generic;

namespace CreditCardApi.Contracts
{
    public interface IUserService
    {
        void Register(User user);
        UserAuthenticate Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
