﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBlogger.DTO
{
    public class BlogCreateDto
    {
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }
        public string Body { get; set; }
        public virtual ICollection<CommetDto> CommetDtos { get; set; }
    }
}
