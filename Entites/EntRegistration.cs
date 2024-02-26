using System.ComponentModel.DataAnnotations;

namespace Entites
{
    public class EntRegistration
    {
        public string? UserId { get; set; }
        public string? Role { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "First Name length can't be more than 20.")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Last Name length can't be more than 20.")]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 4)]
        public string? Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string? Password2 { get; set; }
    }
}