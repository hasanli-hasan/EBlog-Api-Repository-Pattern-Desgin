using AutoMapper;
using EBlogger.DAL;
using EBlogger.DTO;
using EBlogger.DTO.BlogDTO;
using EBlogger.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBlogger.Repo
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public BlogRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateAsync(BlogCreateDto blogCreateDto)
        {
            Blog newBlog = _mapper.Map<Blog>(blogCreateDto);

              await _context.Blogs.AddAsync(newBlog);
              await _context.SaveChangesAsync();
        }

        public async Task DeleteBlog(int id)
        {
            Blog blog = await _context.Blogs.FindAsync(id);
            if (blog !=null)
            {
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
            }

            List<Commet> commets =  _context.Commets.Where(x => x.BlogId == id).ToList();
            foreach (Commet commet in commets)
            {
                _context.Commets.Remove(commet);
                await _context.SaveChangesAsync();
            }
        }

        public List<BlogDto> GetAllBlogs()
        {
            List<Blog> dbBlogs = _context.Blogs.Include(x => x.Commets).ToList();
            return _mapper.Map<List<BlogDto>>(dbBlogs);
        }

        public async Task<BlogDto> GetSingleBlog(int id)
        {
            Blog blog =await _context.Blogs.Include(x=>x.Commets).FirstOrDefaultAsync(x => x.Id == id);
           
            return _mapper.Map<BlogDto>(blog);
        }

        public async Task UpdateBlog(BlogUpdateDto blogUpdateDto)
        {
            Blog blog = _context.Blogs.Find(blogUpdateDto.Id);
            _context.Entry(blog).CurrentValues.SetValues(blogUpdateDto);

           await _context.SaveChangesAsync();

        }
    }
}
