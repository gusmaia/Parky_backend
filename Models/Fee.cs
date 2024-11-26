namespace Parky_backend.Models
{
    public class Fee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Description { get; set; }
        public required decimal HourlyRate { get; set; }
        public required Guid VehicleTypeId { get; set; }
        public required VehicleType VehicleType { get; set; }
        public ICollection<ParkingRegistry> ParkingRegistry { get; set; } = [];
    }
}