using Application.Abstractions;
using Domain.DTOS;
using Domain.Entities;

namespace Application.Services;

public interface IUserService
{
    public Task<List<User>> GetAllService();
    public Task<bool> UpdateUser(UpdateUserDto user);
    public Task<bool> Create(CreateUserDTO user);
    public Task<bool> Delete(int id);





}

public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;

    public UserService(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<List<User>> GetAllService()
    {
        return await _userRepo.GetAll();
    }

    public async Task<bool> UpdateUser(UpdateUserDto user)
    {
        return await _userRepo.Update(user);
    }

    public async Task<bool> Create(CreateUserDTO user)
    {
        return await _userRepo.Create(user);
    }

    public async Task<bool> Delete(int id)
    {
        return await _userRepo.Delete(id);
    }
}