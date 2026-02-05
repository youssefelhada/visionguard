using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using visionguard.DTOs;

namespace visionguard.Controllers
{
    /// <summary>
    /// Authentication Controller
    /// Handles user login and token generation
    /// 
    /// JUSTIFICATION:
    /// - Frontend login page needs JWT token for subsequent requests
    /// - Token embedded with role (SAFETY_SUPERVISOR or HR)
    /// - Token used for authorization on all other endpoints
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// POST /api/auth/login
        /// Authenticates user and returns JWT token
        /// 
        /// BUSINESS LOGIC:
        /// 1. Validate credentials against User table
        /// 2. Generate JWT token with user role embedded
        /// 3. Return token + user profile for dashboard initialization
        /// 
        /// FRONTEND USAGE:
        /// - Login page submits username/password
        /// - Receives token, stores in localStorage/sessionStorage
        /// - Frontend includes token in Authorization header for all requests
        /// </summary>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // TODO: Implement login logic
            // 1. Find user by username
            // 2. Verify password hash
            // 3. Generate JWT token with role
            // 4. Update LastLoginAt timestamp
            // 5. Return token + user profile
            
            return Ok(new ApiResponse<LoginResponse>
            {
                Success = true,
                Message = "Login successful",
                Data = new LoginResponse()
            });
        }

        /// <summary>
        /// GET /api/auth/profile
        /// Returns current authenticated user's profile
        /// 
        /// JUSTIFICATION:
        /// - Profile page displays user info
        /// - Dashboard header shows user name and role
        /// - Used to initialize app state on page load
        /// </summary>
        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            // TODO: Extract user from JWT claim
            // Return current user's profile
            
            return Ok(new ApiResponse<UserProfileDto>
            {
                Success = true,
                Data = new UserProfileDto()
            });
        }

        /// <summary>
        /// PUT /api/auth/profile
        /// Updates current user's profile (name, email, department)
        /// 
        /// JUSTIFICATION:
        /// - Profile page allows editing name and email
        /// - Password change handled separately for security
        /// </summary>
        [HttpPut("profile")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromBody] UserProfileDto request)
        {
            // TODO: Validate input
            // Update current user record
            // Return updated profile
            
            return Ok(new ApiResponse<UserProfileDto>
            {
                Success = true,
                Message = "Profile updated successfully"
            });
        }

        /// <summary>
        /// PUT /api/auth/change-password
        /// Changes password for current user
        /// 
        /// SECURITY CONSIDERATIONS:
        /// - Requires current password for verification
        /// - Never return sensitive data
        /// - Log password change for audit trail
        /// </summary>
        [HttpPut("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            // TODO: Validate current password
            // TODO: Hash new password
            // TODO: Update password in database
            // TODO: Invalidate existing tokens (optional: force re-login)
            
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Password changed successfully"
            });
        }

        /// <summary>
        /// POST /api/auth/refresh
        /// Refreshes JWT token (if implementation uses refresh tokens)
        /// 
        /// JUSTIFICATION:
        /// - Long-lived JWT prevents re-login on every page load
        /// - Refresh token validates legitimacy before issuing new JWT
        /// </summary>
        [HttpPost("refresh")]
        [Authorize]
        public async Task<IActionResult> RefreshToken()
        {
            // TODO: Validate refresh token
            // TODO: Issue new access token
            
            return Ok(new ApiResponse<LoginResponse>
            {
                Success = true,
                Message = "Token refreshed"
            });
        }

        /// <summary>
        /// POST /api/auth/logout
        /// Logs out user (if needed for invalidation)
        /// 
        /// NOTE: With JWT, logout is client-side (token deletion)
        /// This endpoint could be used to:
        /// - Blacklist tokens (if using token blacklist strategy)
        /// - Log logout event for audit
        /// - Invalidate refresh tokens
        /// </summary>
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            // TODO: Optional: blacklist token, log event
            
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Logged out successfully"
            });
        }
    }
}
