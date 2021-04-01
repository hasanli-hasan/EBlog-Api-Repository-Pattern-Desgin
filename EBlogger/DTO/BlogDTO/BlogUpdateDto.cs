using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EBlogger.DTO.BlogDTO
{
    public class BlogUpdateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public IFormFile Photo { get; set; }
    }
}
