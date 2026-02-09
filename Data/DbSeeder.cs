using Microsoft.EntityFrameworkCore;
using visionguard.Models;

namespace visionguard.Data
{
    /// <summary>
    /// Database seeder for initial admin users
    /// Creates default SAFETY_SUPERVISOR and HR admin accounts
    /// </summary>
    public static class DbSeeder
    {
        public static async Task SeedAsync(VisionGuardDbContext context)
        {
            // Ensure database is created
            await context.Database.MigrateAsync();

            // Check if users already exist
            if (await context.Users.AnyAsync())
            {
                return; // Database already seeded
            }

            // Create default admin users
            var users = new List<User>
            {
                new User
                {
                    Username = "SUP-001",
                    Email = "supervisor@visionguard.local",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("1234"),
                    FirstName = "Safety",
                    LastName = "Supervisor",
                    EmployeeId = "SUP-001",
                    Department = "Safety & Compliance",
                    Role = UserRole.SAFETY_SUPERVISOR,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    Username = "HR-001",
                    Email = "hr@visionguard.local",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("1234"),
                    FirstName = "Human",
                    LastName = "Resources",
                    EmployeeId = "HR-001",
                    Department = "Human Resources",
                    Role = UserRole.HR,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();

            Console.WriteLine("✓ Database seeded with default admin users:");
            Console.WriteLine("  - SUP-001 (Safety Supervisor)");
            Console.WriteLine("  - HR-001 (HR)");
        }
    }
}
