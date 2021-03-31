using EBlogger.DTO;
using EBlogger.DTO.BlogDTO;
using EBlogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBlogger.Repo
{
    public interface IBlogRepository
    {
        List<BlogDto> GetAllBlogs();
        Task<BlogDto> GetSingleBlog(int id);
        Task CreateAsync(BlogCreateDto blogCreateDto);
        Task UpdateBlog(BlogUpdateDto blogUpdateDto);
        Task DeleteBlog(int id);

    }
}
