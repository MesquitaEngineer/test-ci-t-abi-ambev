using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

/// <summary>
/// API response model for GetUser operation
/// </summary>
public class GetUserResponse
{
    /// <summary>
    /// The unique identifier of the User
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The User's full name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The User's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The User's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// The User's role in the system
    /// </summary>
    public UserRole Role { get; set; }

    /// <summary>
    /// The current status of the User
    /// </summary>
    public UserStatus Status { get; set; }
}
