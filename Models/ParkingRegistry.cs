namespace Parky_backend.Models
{
    public class ParkingRegistry
    {
        public Guid Id { get; set; }
        public required Guid VehicleId { get; set; }
        public required Guid ParkingSpaceId { get; set; }
        public required DateTime EntryDateTime { get; set; }
        public required DateTime ExitDateTime { get; set; }
        public required decimal TotalValue { get; set; }
    }
}