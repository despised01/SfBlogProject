using BlogApp.BlogAppLib.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BlogApp.BlogAppLib.Repository.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAll();
        Task<Role> Get(Guid id);
        Task Create(Role item);
        Task Update(Role item);
        Task Delete(Role item);
        Task<Role> GetByName(string name);
    }
}
