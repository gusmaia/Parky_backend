namespace Parky_backend.Models
{
    public class ParkingRegistry
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required DateTime EntryDateTime { get; set; }
        public required DateTime ExitDateTime { get; set; }
        public required decimal TotalValue { get; set; }
        public required Guid ClientId { get; set; }
        public required Client Client { get; set; }
        public required Guid VehicleId { get; set; }
        public required Vehicle Vehicle { get; set; }
        public required Guid ParkingSpaceId { get; set; }
        public required ParkingSpace ParkingSpace { get; set; }
        public required Guid FeeId { get; set; }
        public required Fee Fee { get; set; }
    }
}