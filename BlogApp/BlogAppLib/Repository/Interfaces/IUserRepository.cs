using BlogApp.BlogAppLib.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BlogApp.BlogAppLib.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(Guid id);
        Task<User> GetByLogin(string login);
        Task Create(User item);
        Task Update(User item);
        Task Delete(User item);
    }
}
