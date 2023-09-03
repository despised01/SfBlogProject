﻿using BlogApp.BlogAppLib.Models;
using BlogApp.BlogAppLib.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System;
using BlogApp.BlogAppLib.Context;

namespace BlogApp.BlogAppLib.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogDB _db;

        public TagRepository(BlogDB db)
        {
            _db = db;
        }

        public async Task Create(Tag item)
        {
            var entry = _db.Entry(item);
            if (entry.State == EntityState.Detached)
                _db.Tags.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Tag item)
        {
            _db.Tags.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<Tag> Get(Guid id)
        {
            return await _db.Tags.FindAsync(id);
        }

        public async Task<IEnumerable<Tag>> GetAll()
        {
            return await _db.Tags.ToListAsync();
        }

        public async Task Update(Tag item)
        {
            var oldItem = Get(item.Id);

            if (!string.IsNullOrEmpty(item.TagName))
                oldItem.Result.TagName = item.TagName;

            var entry = _db.Entry(oldItem.Result);

            if (entry.State == EntityState.Detached)
                _db.Tags.Update(item);
            await _db.SaveChangesAsync();

        }
    }
}
