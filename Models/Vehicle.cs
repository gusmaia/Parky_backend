namespace Parky_backend.Models
{
    public class Vehicle
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string LicensePlate { get; set; }
        public required string Model { get; set; }
        public string? Color { get; set; }
        public required Guid VehicleTypeId { get; set; }
        public required VehicleType VehicleType { get; set; }
        public required Guid ClientId { get; set; }
        public required Client Client { get; set; }
        public ICollection<ParkingRegistry> ParkingRegistry { get; set; } = [];
    }
}