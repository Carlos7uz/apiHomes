namespace apiHomes.Models
{
    public class Inscription
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int HomeId { get; set; }
        public string? Message { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
