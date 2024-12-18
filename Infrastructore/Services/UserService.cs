using Npgsql;
using Dapper;
using System.Net;
using Infrastructore.Context;
using Infrastructore.Interfaces;
using Infrastructore.Response;
using Domain.Models;

namespace Infrastructore.Services;


public class UserService(DapperContext _context) : IUserService
{
    public async Task<Response<bool>> AddUser(User user)
    {
        using var context=_context.Connection();
        string cmd="insert into users(fullname,email,phone,city,createdat)values(@FullName,@Email,@Phone,@City,@CreatedAt)";
        var res= await context.ExecuteAsync(cmd,user);
        if(user==null) return new Response<bool>(HttpStatusCode.NotFound,"Client Eror");
        return new Response<bool>(res>0);
    }

    public async Task<Response<bool>> DeleteUser(int id)
    {
         using var context=_context.Connection();
        string cmd="delete from users where userid=@UserId";
        var res= await context.ExecuteAsync(cmd,new {userid=id});
        if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Natnot found User!");
        return new Response<bool>(res>0);
    }

    public async Task<Response<List<User>>> GetUserByDate(DateTime date)
    {
        using var context=_context.Connection();
        string cmd="select * from users as u join skills as s on u.userid=s.userid where Date=@CreatedAt";
        var res=( await context.QueryAsync<User>(cmd,new {Date=date})).ToList();
        if(res==null) return new Response<List<User>>(HttpStatusCode.InternalServerError,"Server Eror!");
        return new Response<List<User>>(res);
    }

    public async Task<Response<User>> GetUserById(int id)
    {
        using var context=_context.Connection();
        string cmd="select * from users where userid=@UserId";
        var res=await context.QueryFirstOrDefaultAsync<User>(cmd,new {userid=id});
        if(res==null) return new Response<User>(HttpStatusCode.NotFound,"Cannot found User!");
        return new Response<User>(res);
    }

    public async Task<Response<List<User>>> GetUserBySkill( User user)
    {
        using var context=_context.Connection();
        string cmd="select * from users as u  join skills as s on u.userid=s.userid where u.userid=s.userid";
        var res=( await context.QueryAsync<User>(cmd, user)).ToList();
        if(res==null) return new Response<List<User>>(HttpStatusCode.NotFound,"Cannot found User!");
        return new Response<List<User>>(res);  
    }

    public async Task<Response<List<User>>> GetUsers()
    {
         using var context=_context.Connection();
        string cmd="select * from users ";
        var res=(await context.QueryAsync<User>(cmd)).ToList();
        if(res==null) return new Response<List<User>>(HttpStatusCode.InternalServerError,"Server Eror");
        return new Response<List<User>>(res);
    }

    public async Task<Response<bool>> UpdateUser(User user)
    {
        using var context=_context.Connection();
        string cmd="Update users set userid=@UserId , fullname=@FullName, phone=@Phone , city=@City,createdat=@CreatedAt";
        var res=await context.ExecuteAsync(cmd,user);
        if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Cannot found User!");
        return new Response<bool>(res>0);
    }
}