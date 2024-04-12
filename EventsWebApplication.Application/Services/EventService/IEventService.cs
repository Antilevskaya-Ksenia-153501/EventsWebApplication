using EventsWebApplication.Domain.Entities;
using EventsWebApplication.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace EventsWebApplication.Application.Services.EventService;
public interface IEventService
{
    public Task<ResponseModel<PaginationModel<Event>>> GetEventListAsync (int page = 1,  int pageSize = 3);
    public Task<ResponseModel<Event>> GetEventByIdAsync(Guid id);
    public Task<ResponseModel<Event>> GetEventByNameAsync(string name);
    public Task<ResponseModel<Event>> CreateEventAsync(Event eventItem);
    public Task UpdateEventAsync(Event eventItem);
    public Task<ResponseModel<PaginationModel<Event>>> GetEventListByDateAsync(DateTime date, int page = 1, int pageSize = 3);
    public Task<ResponseModel<PaginationModel<Event>>> GetEventListByLocationAsync(string location, int page = 1, int pageSize = 3);
    public Task<ResponseModel<PaginationModel<Event>>> GetEventListByCategoryAsync(string category, int page = 1, int pageSize = 3);
    public Task DeleteEventAsync(Guid id);
    public Task<ResponseModel<string>> SaveImageAsync(Guid id, IFormFile formFile);
}
