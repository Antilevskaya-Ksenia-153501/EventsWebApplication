using EventsWebApplication.Application.Services.EventService;
using EventsWebApplication.Domain.Entities;
using EventsWebApplication.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventsWebApplication.Presentation.Controllers;

[ApiController]
public class EventController : Controller
{
    private readonly IEventService _eventService;
    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet("{pageNo:int?}")]
    public async Task<ActionResult<ResponseModel<List<Event>>>> GetEvents(int pageNo = 1, int pageSize = 3)
    {
        return Ok(await _eventService.GetEventListAsync(pageNo, pageSize));
    }

    [HttpGet("getById/{id}")]
    public async Task<ActionResult<ResponseModel<Event>>> GetExhibitById(Guid id)
    {
        return Ok(await _eventService.GetEventByIdAsync(id));
    }

    [HttpGet("getByName/{name}")]
    public async Task<ActionResult<ResponseModel<Event>>> GetExhibitByName(string name)
    {
        return Ok(await _eventService.GetEventByNameAsync(name));
    }

    [HttpGet("delete/{id}")]
    public async Task<ActionResult<ResponseModel<Event>>> DeleteExhibitById(Guid id)
    {
        try
        {
            await _eventService.DeleteEventAsync(id);
        }
        catch (Exception ex)
        {
            return NotFound(new ResponseModel<Event>()
            {
                Data = null,
                Success = false,
                ErrorMessage = ex.Message
            });
        }
        return NoContent();
    }
}  