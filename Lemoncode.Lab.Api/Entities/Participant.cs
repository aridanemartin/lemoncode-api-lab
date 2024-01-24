﻿namespace Lemoncode.Lab.Api.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
