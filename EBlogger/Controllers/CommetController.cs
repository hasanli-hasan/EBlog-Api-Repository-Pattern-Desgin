using EBlogger.DTO;
using EBlogger.DTO.CommetDTO;
using EBlogger.Repo.CommetRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBlogger.Controllers
{
    [Route("api/commet")]
    [ApiController]

    public class CommetController : ControllerBase
    {
        private readonly ICommetRepository _commetRepository;
        public CommetController(ICommetRepository commetRepository)
        {
            _commetRepository = commetRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CommetCreateDto commetCreateDto)
        {
            try
            {
                await _commetRepository.CreateCommet(commetCreateDto);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CommetUpdateDto commetUpdateDto)
        {
            try
            {
                await _commetRepository.UpdateCommet(id,commetUpdateDto);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _commetRepository.DeleteCommet(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
