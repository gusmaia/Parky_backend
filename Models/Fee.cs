namespace Parky_backend.Models
{
    public class Fee
    {
        public Guid Id { get; set; }
        public required string Description { get; set; }
        public required Guid VehicleTypeId { get; set; }
        public required decimal HourlyRate { get; set; }
    }
}