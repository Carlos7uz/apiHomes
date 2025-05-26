using apiHomes.Enums;

namespace apiHomes.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int HomeId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public VisitStatus Status { get; set; } = VisitStatus.Pending;

        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
