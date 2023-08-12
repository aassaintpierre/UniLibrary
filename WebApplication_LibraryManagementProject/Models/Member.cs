using System.ComponentModel.DataAnnotations;

namespace WebApplication_LibraryManagementProject.Models
{
    public class Member
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Username { get; set; }
        public string Access { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string AccountStatus { get; set; }
    }
}