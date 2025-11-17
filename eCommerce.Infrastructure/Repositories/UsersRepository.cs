using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository : IUsersRepository
{
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();
        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        return new ApplicationUser
        {
            UserID = Guid.NewGuid(),
            Email = email,
            Password = password,
            PersonName = "John Doe",
            Gender = GenderOptions.Male.ToString()
        };
    }
}
