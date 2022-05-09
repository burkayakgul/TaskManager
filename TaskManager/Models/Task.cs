using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace TaskManager.Models
{   

    public enum TaskStatus
    {
        notStarted,
        started,
        finished
    }

    public enum Priority
    {
        High,
        Medium,
        Low
    }
    public class Task
    {
        [Key]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string header { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string content { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime taskDate { get; set; }
        public TaskStatus status { get; set; }

        public Priority priority { get; set; }

    }
}
