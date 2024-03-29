﻿namespace Lemoncode.Lab.Api.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public ICollection<Participant> Participants { get; set; }
    }
}
