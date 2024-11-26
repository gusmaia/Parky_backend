namespace Parky_backend.Models
{
    public class VehicleType
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Description { get; set; }
        public required char IsActive { get; set; } = 'T';
        public ICollection<Vehicle> Vehicle { get; set; } = [];
        public ICollection<Fee> Fee { get; set; } = [];
        public ICollection<ParkingSpace> ParkingSpace { get; set; } = [];
    }
}