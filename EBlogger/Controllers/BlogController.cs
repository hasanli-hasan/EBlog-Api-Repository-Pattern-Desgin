using AutoMapper;
using EBlogger.DAL;
using EBlogger.DTO;
using EBlogger.DTO.BlogDTO;
using EBlogger.Models;
using EBlogger.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Threading.Tasks;



namespace EBlogger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepo;
        private readonly AppDbContext _context;
        public BlogController(IBlogRepository blogRepo, AppDbContext context)
        {
            _blogRepo = blogRepo;
            _context = context;
        }



        // GET: api/blog
        /// <summary>
        /// For get all Blogs with Commets
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<BlogDto>> Get()
        {

            return _blogRepo.GetAllBlogs();
        }

        // GET api/blog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogDto>> Get(int id)
        {
           
            return await _blogRepo.GetSingleBlog(id);
        }

        // POST api/blog
        [HttpPost]
        //[Authorize(Roles ="Admin")]
        public async Task<ActionResult> Post([FromBody] BlogCreateDto blogCreateDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _blogRepo.CreateAsync(blogCreateDto);
            return NoContent();
        }

        // PUT api/blog/5
        [HttpPut("{id}")]
      //  [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put([FromBody] BlogUpdateDto blogUpdateDto)
        {
           await _blogRepo.UpdateBlog(blogUpdateDto);
            return StatusCode(StatusCodes.Status200OK);
        }

        // DELETE api/blog/5
        [HttpDelete("{id}")]
       // [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
             await _blogRepo.DeleteBlog(id);
            return Ok();
        }
    }

   
}
