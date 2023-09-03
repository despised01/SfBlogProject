using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using BlogApp.BlogAppLib.Models;

namespace BlogApp.BlogAppLib.Repository.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAll();
        Task<Post> Get(Guid id);
        Task Create(Post item);
        Task Update(Post item);
        Task Delete(Post item);
        Task<IEnumerable<Post>> GetAllByAuthorId(Guid authorGuid);
    }
}
