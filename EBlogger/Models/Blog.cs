using EBlogger.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EBlogger.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }
        public string Body { get; set; }
        public int WriteCount { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public virtual ICollection<Commet> Commets { get; set; }
    }
}
