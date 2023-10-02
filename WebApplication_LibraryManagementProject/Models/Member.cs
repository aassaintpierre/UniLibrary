using System.ComponentModel.DataAnnotations;

namespace WebApplication_LibraryManagementProject.Models
{
    public class Member
    {
        [Key]
        [Required]
        public string Username { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string AccountStatus { get; set; }

        [Required]
        public string Access { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}