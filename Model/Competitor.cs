﻿namespace SurvivorAPI.Model
{
    public class Competitor : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
