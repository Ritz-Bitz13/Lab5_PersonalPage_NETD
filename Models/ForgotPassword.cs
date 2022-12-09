using System.ComponentModel.DataAnnotations;

namespace Lab5_PersonalPage.Models
{
    public class ForgotPassword
    {
        [Required]
        [EmailAddress]
        [Key]
        public string Email { get; set; }
    }
}
