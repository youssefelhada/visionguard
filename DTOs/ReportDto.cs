namespace visionguard.DTOs
{
    /// <summary>
    /// RESPONSE: Aggregated report data for HR
    /// Justification: HR needs compliance/audit-ready summaries, not real-time data
    /// </summary>
    public class ViolationsByWorkerReportDto
    {
        public int WorkerId { get; set; }
        public string WorkerName { get; set; } = string.Empty;
        public string EmployeeId { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        
        /// <summary>
        /// Total violations in the selected period
        /// Used for disciplinary review
        /// </summary>
        public int TotalViolations { get; set; }
        
        /// <summary>
        /// Breakdown by PPE type
        /// HR evaluates which safety rules are most violated
        /// </summary>
        public int HelmetViolations { get; set; }
        public int VestViolations { get; set; }
        public int MaskViolations { get; set; }
        public int GlovesViolations { get; set; }
        
        /// <summary>
        /// Violation trend
        /// </summary>
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
    }

    /// <summary>
    /// RESPONSE: Violations grouped by PPE type
    /// Justification: Safety policy evaluation - identifies systemic PPE issues
    /// </summary>
    public class ViolationsByTypeReportDto
    {
        public string ViolationType { get; set; } = string.Empty;  // "HELMET", "VEST", "MASK", "GLOVES"
        public int TotalViolations { get; set; }
        
        /// <summary>
        /// Top violating workers for this PPE type
        /// HR focuses training on problem areas
        /// </summary>
        public List<WorkerViolationCountDto> TopViolators { get; set; } = new();
        
        /// <summary>
        /// Top violating cameras/zones for this PPE type
        /// Helps identify problematic areas (e.g., assembly line lacks training)
        /// </summary>
        public List<CameraViolationCountDto> TopZones { get; set; } = new();
        
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
    }

    public class WorkerViolationCountDto
    {
        public int WorkerId { get; set; }
        public string WorkerName { get; set; } = string.Empty;
        public int ViolationCount { get; set; }
    }

    public class CameraViolationCountDto
    {
        public int CameraId { get; set; }
        public string CameraZone { get; set; } = string.Empty;
        public int ViolationCount { get; set; }
    }

    /// <summary>
    /// REQUEST: Report generation filter
    /// HR generates monthly/quarterly reports with filters
    /// </summary>
    public class ReportFilterRequest
    {
        /// <summary>
        /// Month-based reporting for HR (justification: HR works with monthly cycles)
        /// </summary>
        public int Year { get; set; }
        public int Month { get; set; }
        
        /// <summary>
        /// Optional zone filter for department-level analysis
        /// </summary>
        public string? CameraZone { get; set; }
        
        /// <summary>
        /// Optional violation type focus
        /// </summary>
        public string? ViolationType { get; set; }
    }

    /// <summary>
    /// RESPONSE: Export-ready violation data
    /// Used for Excel/PDF generation
    /// </summary>
    public class ExportViolationDto
    {
        public int ViolationId { get; set; }
        public string WorkerName { get; set; } = string.Empty;
        public string WorkerEmployeeId { get; set; } = string.Empty;
        public string CameraZone { get; set; } = string.Empty;
        public string ViolationType { get; set; } = string.Empty;
        public DateTime DetectedAt { get; set; }
        public int ConfidenceScore { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Notes { get; set; }
    }
}
