using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_LibraryManagementProject.Models
{
    public class Book
    {
        [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string Genre { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public int ActualStock { get; set; }
        public int CurrentStock { get; set; }
    }
}