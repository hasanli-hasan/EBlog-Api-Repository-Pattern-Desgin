using AutoMapper;
using EBlogger.DTO;
using EBlogger.DTO.BlogDTO;
using EBlogger.DTO.CommetDTO;
using EBlogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBlogger.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            //blogMapping
            CreateMap<BlogCreateDto, Blog>();
            CreateMap<Blog, BlogDto>().ReverseMap();
            CreateMap<BlogUpdateDto, Blog>().ReverseMap();

            //commetMapping
            CreateMap<Commet, CommetDto>();
            CreateMap<CommetCreateDto,Commet>();
            CreateMap<CommetUpdateDto,Commet>();
        }
    }
}
