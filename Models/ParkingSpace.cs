namespace Parky_backend.Models
{
    public class ParkingSpace
    {
        public Guid Id { get; set; }
        public required string Location { get; set; }
        public required bool Available { get; set; }
    }
}