using System;
using System.ComponentModel.DataAnnotations;

namespace BlogMe.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [StringLength(200)]
        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
