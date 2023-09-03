using BlogApp.BlogAppLib.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BlogApp.BlogAppLib.Repository.Interfaces
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAll();
        Task<Tag> Get(Guid id);
        Task Create(Tag item);
        Task Update(Tag item);
        Task Delete(Tag item);
    }
}
