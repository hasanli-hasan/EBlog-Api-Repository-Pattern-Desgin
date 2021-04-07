using AutoMapper;
using EBlogger.DAL;
using EBlogger.DTO;
using EBlogger.DTO.CommetDTO;
using EBlogger.Models;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace EBlogger.Repo.CommetRepo
{
    public class CommetRepository : ICommetRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public CommetRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task CreateCommet(CommetCreateDto commetCreateDto)
        {
            Blog blog = _context.Blogs.Find(commetCreateDto.BlogId);

                Commet newCommet = _mapper.Map<Commet>(commetCreateDto);
                await _context.Commets.AddAsync(newCommet);
                await _context.SaveChangesAsync();
      
        }

        public async Task DeleteCommet(int id)
        {
            Commet commet =await _context.Commets.FindAsync(id);
            _context.Commets.Remove(commet);
            await _context.SaveChangesAsync();
        }



        public async Task UpdateCommet(int id,CommetUpdateDto commetUpdateDto)
        {
            Commet commet = _context.Commets.Find(id);
            _context.Entry(commet).CurrentValues.SetValues(commetUpdateDto);

            await _context.SaveChangesAsync();
        }
    }
}
