using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.Services;

internal class UsersService : IUsersService
{
    private readonly IUsersRepository usersRepository;
    private readonly IMapper mapper;

    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        this.usersRepository = usersRepository;
        this.mapper = mapper;
    }

    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await this.usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }

        return mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        // write automapper
        ApplicationUser user = mapper.Map<ApplicationUser>(registerRequest);

        ApplicationUser? registeredUser = await this.usersRepository.AddUser(user);
        if (registeredUser == null)
        {
            return null;
        }

        return mapper.Map<AuthenticationResponse>(registeredUser) with { Success = true, Token = "token" };
    }
}