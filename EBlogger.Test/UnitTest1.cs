//using EBlogger.DTO;
//using EBlogger.DTO.BlogDTO;
//using EBlogger.Repo;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Xunit;

//namespace EBlogger.Test
//{
//    public class UnitTest1 : IBlogRepository
//    {
//        private readonly List<BlogDto> _blogDtos;

//        public  BlogDtoFake()
//        {
//            _blogDtos = new List<BlogDto>()
//            {
//                   new BlogDto(){Id=1,Title="Testing Title", Body="Testing Body"}
//            };
//        }

//        public Task CreateAsync(BlogCreateDto blogCreateDto)
//        {
//            return _blogDtos;
//        }

//        public Task DeleteBlog(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public List<BlogDto> GetAllBlogs()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<BlogDto> GetSingleBlog(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task UpdateBlog(int id, BlogUpdateDto blogUpdateDto)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
