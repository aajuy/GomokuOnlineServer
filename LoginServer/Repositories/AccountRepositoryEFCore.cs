﻿using LoginServer.Data;
using LoginServer.Data.Entities;
using LoginServer.Data.Models;
using LoginServer.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LoginServer.Repositories
{
    public class AccountRepositoryEFCore : IAccountRepository
    {
        private readonly AppDbContext dbContext;

        public AccountRepositoryEFCore(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(string username, string encodedPassword)
        {
            var user = new User()
            {
                Username = username,
                EncodedPassword = encodedPassword,
                LastStaminaUpdateTime = DateTime.UtcNow,
                Stamina = 120
            };

            try
            {
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DuplicateUsernameException();
            }
        }

        public async Task<UserModel?> Find(string username)
        {
            return dbContext.Users.AsNoTracking()
                .Where(u => u.Username == username)
                .Select(u => new UserModel()
                {
                    UserId = u.UserId,
                    EncodedPassword = u.EncodedPassword
                })
                .FirstOrDefault();
        }
    }
}
