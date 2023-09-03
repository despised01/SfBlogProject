using BlogApp.BlogAppLib.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BlogApp.BlogAppLib.Repository.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAll();
        Task<Comment> Get(Guid id);
        Task Create(Comment item);
        Task Update(Comment item);
        Task Delete(Comment item);
    }
}
