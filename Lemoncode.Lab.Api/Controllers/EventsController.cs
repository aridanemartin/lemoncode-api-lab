using Microsoft.AspNetCore.Mvc;
using Lemoncode.Lab.Api.Entities;

namespace Lemoncode.Lab.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetEvents()
        {
            return _context.Events.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Event> GetEventById(int id)
        {
            var targetEvent = _context.Events.Find(id);

            if (targetEvent == null)
            {
                return NotFound();
            }

            return targetEvent;
        }

        [HttpPost]
        public ActionResult<Event> CreateEvent(Event newEvent)
        {
            _context.Events.Add(newEvent);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEventById), new { id = newEvent.Id }, newEvent);
        }

        [HttpPut("{id}")]
        public ActionResult<Event> UpdateEvent(int id, Event updatedEvent)
        {
            if (id != updatedEvent.Id)
            {
                return BadRequest();
            }

            var existingEvent = _context.Events.Find(id);

            if (existingEvent == null)
            {
                return NotFound();
            }

            existingEvent.Name = updatedEvent.Name;
            existingEvent.StartDate = updatedEvent.StartDate;
            existingEvent.EndDate = updatedEvent.EndDate;
            existingEvent.Description = updatedEvent.Description;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Event> DeleteEvent(int id)
        {
            var targetEvent = _context.Events.Find(id);

            if (targetEvent == null)
            {
                return NotFound();
            }

            _context.Events.Remove(targetEvent);
            _context.SaveChanges();

            return targetEvent;
        }
    }
}
