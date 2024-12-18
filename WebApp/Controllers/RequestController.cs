using Infrastructore.Interfaces;
using Infrastructore.Response;
using Infrastructore.Context;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class RequestController(IRequestService RequestService):ControllerBase
{
 [HttpPost]
 public async Task<Response<bool>> Add(Request Request)
 {
    var response= await RequestService.AddRequest(Request);
    return response;
 }
 [HttpGet]
 public async Task<Response<List<Request>>> GetAll()
 {
    var response=await RequestService.GetRequests();
    return response;
 }
 [HttpPut("update-status")]
 public async Task<Response<bool>> Update(string status,int id)
 {
    var response= await RequestService.UpdateRequestStatus(status,id);
    return response;
 }
 [HttpGet("get-by-id")]
 public async Task<Response<Request>> GetById(int id)
 {
    var response= await RequestService.GetRequestById(id);
    return response;
 }
}