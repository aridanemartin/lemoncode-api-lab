using Microsoft.AspNetCore.Mvc;
using Lemoncode.Lab.Api.Entities;

namespace Lemoncode.Lab.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParticipantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Participant>> GetParticipants()
        {
            return _context.Participants.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Participant> GetParticipantById(int id)
        {
            var targetParticipant = _context.Participants.Find(id);

            if (targetParticipant == null)
            {
                return NotFound();
            }

            return targetParticipant;
        }

        [HttpPost]
        public ActionResult<Participant> CreateParticipant(Participant newParticipant)
        {
            _context.Participants.Add(newParticipant);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetParticipantById), new { id = newParticipant.Id }, newParticipant);
        }

        [HttpPut("{id}")]
        public ActionResult<Participant> UpdateParticipant(int id, Participant updatedParticipant)
        {
            if (id != updatedParticipant.Id)
            {
                return BadRequest();
            }

            var existingParticipant = _context.Participants.Find(id);

            if (existingParticipant == null)
            {
                return NotFound();
            }

            existingParticipant.FirstName = updatedParticipant.FirstName;
            existingParticipant.LastName = updatedParticipant.LastName;
            existingParticipant.Email = updatedParticipant.Email;
            existingParticipant.Events = updatedParticipant.Events;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Participant> DeleteParticipant(int id)
        {
            var targetParticipant = _context.Participants.Find(id);

            if (targetParticipant == null)
            {
                return NotFound();
            }

            _context.Participants.Remove(targetParticipant);
            _context.SaveChanges();

            return targetParticipant;
        }
    }
}
