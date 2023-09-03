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
    public class UserRepository : IUserRepository
    {
        private readonly BlogDB _db;

        public UserRepository(BlogDB db)
        {
            _db = db;
        }

        public async Task Create(User item)
        {
            var entry = _db.Entry(item);
            if (entry.State == EntityState.Detached)
                _db.Users.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(User item)
        {
            _db.Users.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<User> Get(Guid id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> GetByLogin(string login)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task Update(User item)
        {
            var oldItem = Get(item.Id);

            if (!string.IsNullOrEmpty(item.FirstName))
                oldItem.Result.FirstName = item.FirstName;
            if (!string.IsNullOrEmpty(item.LastName))
                oldItem.Result.LastName = item.LastName;
            if (!string.IsNullOrEmpty(item.Password))
                oldItem.Result.Password = item.Password;
            if (!string.IsNullOrEmpty(item.Login))
                oldItem.Result.Login = item.Login;
            if (!string.IsNullOrEmpty(item.Email))
                oldItem.Result.Email = item.Email;

            var entry = _db.Entry(oldItem.Result);

            if (entry.State == EntityState.Detached)
                _db.Users.Update(item);
            await _db.SaveChangesAsync();
        }
    }
}
