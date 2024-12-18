using Infrastructore.Response;
using Infrastructore.Context;
using Domain.Models;
namespace Infrastructore.Interfaces;

public interface IRequestService
{
    public Task<Response<List<Request>>> GetRequests();
    public Task<Response<bool>> AddRequest(Request request);
    public Task<Response<bool>> UpdateRequestStatus(string status,int id);
    public Task<Response<Request>> GetRequestById(int id);
}