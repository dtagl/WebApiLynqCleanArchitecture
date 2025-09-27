using Application.Abstractions;
using Domain.DTOS;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepo : IUserRepo
{
    private readonly WebApiDbContext _context;

    public UserRepo(WebApiDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<bool> Create(CreateUserDTO user)
    {
        var res = new User
        {
            Name = user.Name,
            Email = user.Email,
            RegistrationDate = user.RegistrationDate
        };

        _context.Users.Add(res);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(UpdateUserDto user)
    {
        var existing = await _context.Users.FindAsync(user.Id);
        if (existing == null)
            return false;

        existing.Name = user.Name;
        existing.Email = user.Email;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}