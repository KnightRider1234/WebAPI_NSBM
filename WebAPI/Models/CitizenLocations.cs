namespace WebAPI.Models
{
    public class CitizenLocations
    {
        public int CitizenId { get; set; }
        public Citizen Citizen { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }

}
