using Npgsql;
using Dapper;
using System.Net;
using Infrastructore.Context;
using Infrastructore.Interfaces;
using Infrastructore.Response;
using Domain.Models;

namespace Infrastructore.Services;


public class SkillService(DapperContext _context) : ISkillService
{
    public async Task<Response<bool>> AddSkill(Skill skill)
    {
        using var context=_context.Connection();
        string cmd="insert into Skills(userid,title,description,createdat)values(@UserId,@Title,@Description,@CreatedAt)";
        var res= await context.ExecuteAsync(cmd,skill);
        if(skill==null) return new Response<bool>(HttpStatusCode.NotFound,"Client Eror");
        return new Response<bool>(res>0);
    }

    public async Task<Response<bool>> DeleteSkill(int id)
    {
         using var context=_context.Connection();
        string cmd="delete from Skills where Skillid=@SkillId";
        var res= await context.ExecuteAsync(cmd,new {Skillid=id});
        if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Natnot found Skill!");
        return new Response<bool>(res>0);
    }

    public async Task<Response<Skill>> GetSkillById(int id)
    {
        using var context=_context.Connection();
        string cmd="select * from Skills where Skillid=@SkillId";
        var res=await context.QueryFirstOrDefaultAsync<Skill>(cmd,new {Skillid=id});
        if(res==null) return new Response<Skill>(HttpStatusCode.NotFound,"Cannot found Skill!");
        return new Response<Skill>(res);
    }

    public async Task<Response<List<Skill>>> GetSkills()
    {
         using var context=_context.Connection();
        string cmd="select * from Skills ";
        var res=(await context.QueryAsync<Skill>(cmd)).ToList();
        if(res==null) return new Response<List<Skill>>(HttpStatusCode.InternalServerError,"Server Eror");
        return new Response<List<Skill>>(res);
    }

    public async Task<Response<bool>> UpdateSkill(Skill skill)
    {
        using var context=_context.Connection();
        string cmd="Update Skills set skillid=@SkillId , userId=@UserId, title=@Title , description=@Description,createdat=@CreatedAt";
        var res=await context.ExecuteAsync(cmd,skill);
        if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Cannot found Skill!");
        return new Response<bool>(res>0);
    }
}