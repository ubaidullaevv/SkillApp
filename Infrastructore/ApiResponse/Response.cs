using System.Net;
namespace Infrastructore.Response;


public class Response<T>
{
    public int StatusCode { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }

    public Response(T data)
    {
       StatusCode=200;
       Data=data;
       Message="Succsess"; 
    }
    public Response(HttpStatusCode statusCode,string message)
    {
        StatusCode=(int)statusCode;
        Data=default;
        Message=message;
    }
}