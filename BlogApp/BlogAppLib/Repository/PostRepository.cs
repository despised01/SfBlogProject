using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System;
using BlogApp.BlogAppLib.Repository.Interfaces;
using BlogApp.BlogAppLib.Models;
using BlogApp.BlogAppLib.Context;
using System.Linq;

namespace BlogApp.BlogAppLib.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDB _db;

        public PostRepository(BlogDB db)
        {
            _db = db;
        }

        public async Task Create(Post item)
        {
            var entry = _db.Entry(item);
            if (entry.State == EntityState.Detached)
                _db.Posts.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Post item)
        {
            _db.Posts.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<Post> Get(Guid id)
        {
            return await _db.Posts.FindAsync(id);
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _db.Posts.ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetAllByAuthorId(Guid id)
        {
            return await _db.Posts.Where(x => x.Author_Id == id).ToListAsync();
        }

        public async Task Update(Post item)
        {
            var oldItem = Get(item.Id);

            if (!string.IsNullOrEmpty(item.Title))
                oldItem.Result.Title = item.Title;
            if (!string.IsNullOrEmpty(item.BodyText))
                oldItem.Result.BodyText = item.BodyText;

            var entry = _db.Entry(oldItem.Result);

            if (entry.State == EntityState.Detached)
                _db.Posts.Update(item);
            await _db.SaveChangesAsync();
        }
    }
}
