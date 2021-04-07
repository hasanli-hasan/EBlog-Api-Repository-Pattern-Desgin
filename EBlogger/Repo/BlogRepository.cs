using AutoMapper;
using EBlogger.DAL;
using EBlogger.DTO;
using EBlogger.DTO.BlogDTO;
using EBlogger.Interface;
using EBlogger.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace EBlogger.Repo
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IUserAccessor _userAccessor;
        private readonly UserManager<AppUser> _userManager;

        public BlogRepository(
            IMapper mapper, 
            AppDbContext context, 
            IWebHostEnvironment env,
            IUserAccessor userAccessor,
            UserManager<AppUser> userManager
           )
        {
            _mapper = mapper;
            _context = context;
            _env = env;
            _userAccessor = userAccessor;
            _userManager = userManager;
        }

        public async Task CreateAsync(BlogCreateDto blogCreateDto)
        {

            Blog newBlog = _mapper.Map<Blog>(blogCreateDto);
            newBlog.Image = Guid.NewGuid().ToString() + newBlog.Photo.FileName;
            string path = Path.Combine(_env.WebRootPath,"blogImages");
            string resultPath = Path.Combine(path,newBlog.Image);
            FileStream fileStream = new FileStream(resultPath,FileMode.Create);
            await newBlog.Photo.CopyToAsync(fileStream);

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
            var user = await _userManager.FindByNameAsync(_userAccessor.GetCurrentUsername());
            Blog blog =await _context.Blogs.Include(x=>x.Commets).FirstOrDefaultAsync(x => x.Id == id);
            blog.WriteCount++;
            await _context.SaveChangesAsync();

            return _mapper.Map<BlogDto>(blog);
        }

        public async Task UpdateBlog(int id,BlogUpdateDto blogUpdateDto)
        {
            Blog blog = _context.Blogs.Find(id);
            string filePath = Path.Combine(_env.WebRootPath, "blogImages", blog.Image);
            if (filePath !=null)
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

           
            string path = Path.Combine(_env.WebRootPath, "blogImages");
            string resultPath = Path.Combine(path, blog.Image);
            FileStream fileStream = new FileStream(resultPath, FileMode.Create);
            await blogUpdateDto.Photo.CopyToAsync(fileStream);

            blog.Image = Guid.NewGuid().ToString() + blogUpdateDto.Photo.FileName;
            blog.Id = blogUpdateDto.Id;
            blog.Title = blogUpdateDto.Title;
            blog.Body = blogUpdateDto.Body;
            await _context.SaveChangesAsync();

        }
    }
}
