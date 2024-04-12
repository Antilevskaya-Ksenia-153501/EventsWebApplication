using EventsWebApplication.Application.Services.EventService;
using EventsWebApplication.Domain.Entities;
using EventsWebApplication.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsWebApplication.Presentation.Controllers;

[Route("api/event")]
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

    [HttpPost("create/")]
    public async Task<ActionResult<ResponseModel<Event>>> CreateExhibit(Event eventItem)
    {
        if (eventItem is null)
        {
            return BadRequest(new ResponseModel<Event>()
            {
                Data = null,
                Success = false,
                ErrorMessage = "Event is null"
            });
        }
        var response = await _eventService.CreateEventAsync(eventItem);
        if (!response.Success)
        {
            return BadRequest(response.ErrorMessage);
        }

        return CreatedAtAction("GetExhibitById", new { id = eventItem.Id }, new ResponseModel<Event>()
        {
            Data = eventItem,
            Success = true,
            ErrorMessage = null
        });
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<ResponseModel<Event>>> UpdateExhibit(Event newEvent)
    {
        try
        {
            await _eventService.UpdateEventAsync(newEvent);
        }
        catch (Exception ex)
        {
            return new ResponseModel<Event>()
            {
                Data = null,
                Success = false,
                ErrorMessage = ex.Message
            };
        }
        return Ok(new ResponseModel<Event>()
        {
            Data = newEvent,
            Success = true,
            ErrorMessage = null
        });
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

    [HttpGet("category/{category}/{pageNo:int?}")]
    public async Task<ActionResult<ResponseModel<List<Event>>>> GetEventsByCategory (string category, int pageNo = 1, int pageSize = 3)
    {
        return Ok(await _eventService.GetEventListByCategoryAsync(category, pageNo, pageSize));
    }

    [HttpGet("location/{location}/{pageNo:int?}")]
    public async Task<ActionResult<ResponseModel<List<Event>>>> GetEventsByLocation(string location, int pageNo = 1, int pageSize = 3)
    {
        return Ok(await _eventService.GetEventListByLocationAsync(location, pageNo, pageSize));
    }
}  