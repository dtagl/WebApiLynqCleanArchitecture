using Domain.DTOS;
using Domain.Entities;

namespace Application.Abstractions;

public interface IUserRepo
{
    public Task<List<User>> GetAll();
    public Task<bool> Update(UpdateUserDto user);
    public Task<bool> Create(CreateUserDTO user);
    public Task<bool> Delete(int id);
    public Task<User> GetUsersWithMostTasks();



}