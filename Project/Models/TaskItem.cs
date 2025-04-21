using Project.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Display(Name = "Task Title")]
        [Required(ErrorMessage = "Task title is required")]
        public string Title { get; set; }

        [Display(Name = "Task Description")]
        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Due date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Remarks")]

        public string Remarks { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Display(Name = "Last Updated On")]
        public DateTime LastUpdatedOn { get; set; } = DateTime.Now;

        [Display(Name = "Created By")]
        public int CreatedById { get; set; }

        [Display(Name = "Last Updated By")]
        public int LastUpdatedById { get; set; }

        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("LastUpdatedById")]
        public virtual User LastUpdatedBy{ get; set; }
    }
}