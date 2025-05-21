namespace apiHomes.Models
{
    public class Home
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ImageUrl { get; set; }
        public int AvailableUnits { get; set; }
        public Boolean Wifi { get; set; }
        public Boolean Laundry { get; set; }
        public string CreateBy { get; set; }
        public string? EditedBy {  get; set; }
        public string? DeletedBy { get; set; }

    }
}
