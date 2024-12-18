using Npgsql;
using Dapper;
using System.Net;
using Infrastructore.Context;
using Infrastructore.Interfaces;
using Infrastructore.Response;
using Domain.Models;

namespace Infrastructore.Services;


public class RequestService(DapperContext _context) : IRequestService
{
    public async Task<Response<bool>> AddRequest(Request Request)
    {
        using var context=_context.Connection();
        string cmd="insert into Requests(fromuserid,touserid,requestedSkillId,offeredSkillId,status,createdat,updatedat)values(@FromUserId,@ToUserId,@RequestedSkillId,@OfferedSkillId,@CreatedAt,@UpdatedAt)";
        var res= await context.ExecuteAsync(cmd,Request);
        if(Request==null) return new Response<bool>(HttpStatusCode.NotFound,"Client Eror");
        return new Response<bool>(res>0);
    }


    public async Task<Response<Request>> GetRequestById(int id)
    {
        using var context=_context.Connection();
        string cmd="select * from Requests where requestid=@RequestId";
        var res=await context.QueryFirstOrDefaultAsync<Request>(cmd,new {requestid=id});
        if(res==null) return new Response<Request>(HttpStatusCode.NotFound,"Cannot found Request!");
        return new Response<Request>(res);
    }

    public async Task<Response<List<Request>>> GetRequests()
    {
         using var context=_context.Connection();
        string cmd="select * from Requests ";
        var res=(await context.QueryAsync<Request>(cmd)).ToList();
        if(res==null) return new Response<List<Request>>(HttpStatusCode.InternalServerError,"Server Eror");
        return new Response<List<Request>>(res);
    }

    public async Task<Response<bool>> UpdateRequestStatus(string status,int id)
    {
        using var context=_context.Connection();
        string cmd="Update requests set Status=@Status where RequestId=@RequestId";
        var res=await context.ExecuteAsync(cmd,new {RequestId=id,Status=status});
        if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Cannot found Request!");
        return new Response<bool>(res>0);
    }

}