using Infrastructore.Response;
using Infrastructore.Context;
using Domain.Models;
namespace Infrastructore.Interfaces;

public interface IUserService
{
    public Task<Response<List<User>>> GetUsers();
    public Task<Response<bool>> AddUser(User user);
    public Task<Response<bool>> UpdateUser(User user);
    public Task<Response<bool>> DeleteUser(int id);
    public Task<Response<User>> GetUserById(int id);
    public Task<Response<List<User>>> GetUserBySkill(User user);
    public Task<Response<List<User>>> GetUserByDate(DateTime date);
}