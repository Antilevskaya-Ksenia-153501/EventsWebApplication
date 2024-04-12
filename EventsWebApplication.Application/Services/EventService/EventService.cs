using EventsWebApplication.Application.Repositories;
using EventsWebApplication.Domain.Entities;
using EventsWebApplication.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace EventsWebApplication.Application.Services.EventService;
public class EventService : IEventService
{
    private readonly IUnitOfWork _unitOfWork;
    public EventService(IUnitOfWork unitOfWork) 
    { 
        _unitOfWork = unitOfWork;
    }
    public Task<ResponseModel<Event>> CreateEventAsync(Event eventItem)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteEventAsync(Guid id)
    {
        var entity = _unitOfWork.EventRepository.GetByIdAsync(id);
        if (entity == null)
            throw new ArgumentException($"Event with id = {id} was not found");
        await _unitOfWork.EventRepository.DeleteAsync(entity.Result);
    }

    public Task<ResponseModel<Event>> GetEventByIdAsync(Guid id)
    {
        var query = _unitOfWork.EventRepository.GetByIdAsync(id);
        if (query.Result == null)
        {
            return Task.FromResult(new ResponseModel<Event>()
            {
                Data = null,
                Success = false,
                ErrorMessage = $"Event with id = {id} was not found"
            });
        }
        return Task.FromResult(new ResponseModel<Event>()
        {
            Data = query.Result,
            Success = true,
            ErrorMessage = null
        });

    }
    public Task<ResponseModel<Event>> GetEventByNameAsync(string name)
    {
        var query = _unitOfWork.EventRepository.FirstOrDefaultAsync(obj => obj.Name == name);
        if (query.Result == null)
        {
            return Task.FromResult(new ResponseModel<Event>()
            {
                Data = null,
                Success = false,
                ErrorMessage = $"Event with name = {name} was not found"
            });
        }
        return Task.FromResult(new ResponseModel<Event>()
        {
            Data = query.Result,
            Success = true,
            ErrorMessage = null
        });
    }
    public Task<ResponseModel<PaginationModel<Event>>> GetEventListAsync(int page = 1, int pageSize = 3)
    {
        var query = _unitOfWork.EventRepository.ListAllAsync();
        var dataList = new PaginationModel<Event>();
        int totalPages = (int)Math.Ceiling(query.Result.Count / (double)pageSize);
        if (page > totalPages)
        {
            return Task.FromResult(new ResponseModel<PaginationModel<Event>>()
            {
                Data = null,
                Success = false,
                ErrorMessage = "There is no such page"
            });
        }
        dataList.Items = query.Result.Skip((page-1)*pageSize).Take(pageSize).ToList();
        dataList.CurrentPage = page;
        dataList.TotalPages = totalPages;
        return Task.FromResult(new ResponseModel<PaginationModel<Event>>()
        {
            Data = dataList,
            Success = true,
            ErrorMessage = null
        });
    }

    public Task<ResponseModel<PaginationModel<Event>>> GetEventListByCategoryAsync(string category, int page = 1, int pageSize = 3)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<PaginationModel<Event>>> GetEventListByDateAsync(DateTime date, int page = 1, int pageSize = 3)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<PaginationModel<Event>>> GetEventListByLocationAsync(string location, int page = 1, int pageSize = 3)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<string>> SaveImageAsync(Guid id, IFormFile formFile)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<Event>> UpdateEventAsync(Guid id, Event eventItem)
    {
        throw new NotImplementedException();
    }
}
