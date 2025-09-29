using Application.Abstractions;
using Application.Services;
using Domain.DTOS;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WebApiController: ControllerBase
{
    
    ////////USER///////////////////
    private readonly IUserService _userService;

    public WebApiController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet("GetAll")]
    public async Task<List<User>> GetAllAsync()
    {
        return await _userService.GetAllService();
    }

    [HttpPut("Update")]
    public async Task<bool> UpdateAsync([FromBody]UpdateUserDto user)
    {
        return await _userService.UpdateUser(user);
    }

    [HttpPost("Create")]
    public async Task<bool> CreateAsync([FromBody]CreateUserDTO user)
    {
        return await _userService.Create(user);
    }

    [HttpDelete("Delete")]
    public async Task<bool> DeleteAsync([FromQuery] int id)
    {
        return await _userService.Delete(id);
    }

    [HttpGet("GetUsersWithMostTasks")]
    public async Task<User> GetUsersWithMostTasks()
    {
        return await _userService.GetUsersWithMostTasks();
    }
}