namespace visionguard.Models
{
    /// <summary>
    /// Represents a factory worker being monitored by AI
    /// Workers do NOT login to the system
    /// Violations are tracked against workers
    /// </summary>
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string EmployeeId { get; set; } = string.Empty;
        
        /// <summary>
        /// Department/team the worker belongs to (for filtering by zone)
        /// </summary>
        public string Department { get; set; } = string.Empty;
        
        public string? ProfilePictureUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public ICollection<Violation> Violations { get; set; } = new List<Violation>();
    }
}
