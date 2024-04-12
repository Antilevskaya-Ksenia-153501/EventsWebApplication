namespace EventsWebApplication.Domain.Models;
public class ResponseModel<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}
