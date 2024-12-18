using Infrastructore.Interfaces;
using Infrastructore.Response;
using Infrastructore.Context;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService):ControllerBase
{
 [HttpPost]
 public async Task<Response<bool>> Add(User user)
 {
    var response= await userService.AddUser(user);
    return response;
 }
 [HttpGet]
 public async Task<Response<List<User>>> GetAll()
 {
    var response=await userService.GetUsers();
    return response;
 }
 [HttpPut]
 public async Task<Response<bool>> Update(User user)
 {
    var response= await userService.UpdateUser(user);
    return response;
 }
 [HttpGet("get-by-id")]
 public async Task<Response<User>> GetById(int id)
 {
    var response= await userService.GetUserById(id);
    return response;
 }
 [HttpDelete]
 public async Task<Response<bool>> Delete(int id)
 {
    var response=await userService.DeleteUser(id);
    return response;
 }
 [HttpGet("get-by-skill")]
 public async Task<Response<List<User>>> GetBySkill(Skill skill,User user)
 {
    var response= await userService.GetUserBySkill(user);
    return response;
 }
  [HttpGet]
  public async Task<Response<List<User>>> GetByDate(DateTime date)
  {
    var response= await userService.GetUserByDate(date);
    return response;
  }
}