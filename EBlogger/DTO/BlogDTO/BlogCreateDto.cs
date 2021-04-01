using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBlogger.DTO
{
    public class BlogCreateDto
    {
       // [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }
        public string Body { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Image { get; set; }
        public virtual ICollection<CommetDto> CommetDtos { get; set; }
    }
}
