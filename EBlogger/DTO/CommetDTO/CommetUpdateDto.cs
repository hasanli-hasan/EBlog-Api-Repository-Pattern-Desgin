using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBlogger.DTO.CommetDTO
{
    public class CommetUpdateDto
    {
        public string Message { get; set; }
        public int BlogId { get; set; }
        public BlogDto Blog { get; set; }
    }
}
