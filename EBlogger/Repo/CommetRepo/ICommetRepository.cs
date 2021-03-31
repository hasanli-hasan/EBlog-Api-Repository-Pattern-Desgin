using EBlogger.DTO;
using EBlogger.DTO.CommetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBlogger.Repo.CommetRepo
{
    public interface ICommetRepository
    {
        Task CreateCommet(CommetCreateDto commetCreateDto);
        Task UpdateCommet(int id,CommetUpdateDto commetUpdateDto);
        Task DeleteCommet(int id);
    }
}
