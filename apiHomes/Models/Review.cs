﻿namespace apiHomes.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int HousingId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
