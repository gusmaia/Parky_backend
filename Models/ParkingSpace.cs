namespace Parky_backend.Models
{
    public class ParkingSpace
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Location { get; set; }
        public required char Available { get; set; } = 'T';
        public required Guid VehicleTypeId { get; set; }
        public required VehicleType VehicleType { get; set; }
        public ICollection<ParkingRegistry> ParkingRegistry { get; set; } = [];
    }
}