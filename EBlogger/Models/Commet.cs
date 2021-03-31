using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBlogger.Models
{
    public class Commet
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
