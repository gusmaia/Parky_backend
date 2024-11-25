namespace Parky_backend.Models
{
    public class Client
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required char[] Type { get; set; } = new char[1];
        public string? CPF { get; set; }
        public string? CNPJ { get; set; }
        public required string Phone { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Vehicle> Vehicle { get; set; } = [];
        public ICollection<ParkingRegistry> ParkingRegistry { get; set; } = [];
    }
}