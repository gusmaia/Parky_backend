namespace Parky_backend.Models
{
    public class VehicleType
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}