using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication_LibraryManagementProject.Models
{
    public class BookIssue
    {
        [Key, Column(Order = 0)]
        public string MemberId { get; set; }
        [Key, Column(Order = 1)]
        public string BookId { get; set; }

        public string IssueDate { get; set; }

        /*public string DueDate { get; set; }*/
        /*public virtual Member Member { get; set; }*/
        public virtual Book Book { get; set; }
    }
}