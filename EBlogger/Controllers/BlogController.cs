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
    [Authorize]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepo;
        public BlogController(IBlogRepository blogRepo)
        {
            _blogRepo = blogRepo;
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
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> Post([FromForm] BlogCreateDto blogCreateDto)
        {
            if (!blogCreateDto.Photo.ContentType.Contains("image/"))
            {
                return BadRequest("Please Select Image Type");
            }

            if (blogCreateDto.Photo.Length/1024 >500)
            {
                return BadRequest("Image Max Size be 200 KB");
            }


            if (!ModelState.IsValid) return BadRequest();
            await _blogRepo.CreateAsync(blogCreateDto);
            return NoContent();
        }

        // PUT api/blog/5
        [HttpPut("{id}")]
      [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put(int id,[FromForm] BlogUpdateDto blogUpdateDto)
        {
           await _blogRepo.UpdateBlog(id,blogUpdateDto);
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
