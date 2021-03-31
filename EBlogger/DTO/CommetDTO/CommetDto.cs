using EBlogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBlogger.DTO
{
    public class CommetDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int BlogId { get; set; }
        public BlogDto Blog { get; set; }
    }
}
