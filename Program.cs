using Microsoft.EntityFrameworkCore;
using visionguard.Data;

namespace visionguard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ============================================================
            // DEPENDENCY INJECTION & MIDDLEWARE CONFIGURATION
            // ============================================================
            
            // Add services to the container.
            builder.Services.AddControllers();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                // TODO: Configure Swagger documentation
                // - Add JWT Bearer security definition
                // - Document each controller and endpoint
                // - Add example responses and models
            });

            // ============================================================
            // AUTHENTICATION & AUTHORIZATION
            // ============================================================
            // TODO: Add JWT Bearer Authentication
            // builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //     .AddJwtBearer(options =>
            //     {
            //         options.Authority = ...;
            //         options.Audience = ...;
            //         // Configure JWT validation
            //     });

            // TODO: Add role-based authorization policies
            // builder.Services.AddAuthorizationBuilder()
            //     .AddPolicy("SupervisorOnly", policy => 
            //         policy.RequireRole("SAFETY_SUPERVISOR"))
            //     .AddPolicy("HROnly", policy => 
            //         policy.RequireRole("HR"))
            //     .AddPolicy("AllAuthenticated", policy => 
            //         policy.RequireAuthenticatedUser());

            // ============================================================
            // DATABASE & ENTITY FRAMEWORK
            // ============================================================
            // Add DbContext for SQL Server
            builder.Services.AddDbContext<VisionGuardDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // ============================================================
            // BUSINESS SERVICES (TO IMPLEMENT)
            // ============================================================
            // TODO: Register application services
            // builder.Services.AddScoped<IViolationService, ViolationService>();
            // builder.Services.AddScoped<ICameraService, CameraService>();
            // builder.Services.AddScoped<IUserService, UserService>();
            // builder.Services.AddScoped<IWorkerService, WorkerService>();
            // builder.Services.AddScoped<IReportService, ReportService>();
            // builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            // ============================================================
            // CACHING
            // ============================================================
            // TODO: Add distributed cache for report caching
            // builder.Services.AddStackExchangeRedisCache(options =>
            //     options.Configuration = builder.Configuration.GetConnectionString("Redis"));

            // ============================================================
            // CORS (Cross-Origin Resource Sharing)
            // ============================================================
            // TODO: Configure CORS for frontend application
            // builder.Services.AddCors(options =>
            // {
            //     options.AddPolicy("AllowFrontend", policy =>
            //         policy.WithOrigins("https://frontend.visionguard.local")
            //               .AllowAnyHeader()
            //               .AllowAnyMethod()
            //               .AllowCredentials());
            // });

            var app = builder.Build();

            // ============================================================
            // HTTP REQUEST PIPELINE
            // ============================================================

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    // TODO: Configure Swagger UI
                    // - Add security definition
                    // - Configure authentication flow for testing
                });
            }

            app.UseHttpsRedirection();

            // TODO: Enable CORS
            // app.UseCors("AllowFrontend");

            // ============================================================
            // AUTHENTICATION & AUTHORIZATION MIDDLEWARE
            // ============================================================
            // TODO: Add authentication middleware
            // app.UseAuthentication();
            
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
