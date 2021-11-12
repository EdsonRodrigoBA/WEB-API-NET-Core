using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Repository;
using Microsoft.AspNetCore.Mvc;
using CursoWEBAPI.Models;

namespace CursoWEBAPI.Controllers
{
    [Route("api/v1/[Controller]")]
    public class CategoriaController : Controller
    {
        private readonly IcategoryRepository _icategoryRepository;
        public CategoriaController(IcategoryRepository icategoryRepository)
        {
            this._icategoryRepository = icategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GettAll()
        {
            var data = (await _icategoryRepository.GetAsync()).Select(c => c.ToCategoryGet());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var data = await _icategoryRepository.GetAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.ToCategoryGet());
        }


        [HttpPost]
        public  IActionResult Add([FromBody] CategoryAddEdit model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = model.toCategory();
            _icategoryRepository.Add(data);
            return CreatedAtRoute("GetCategoryById", new { data.Id }, data);
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] CategoryAddEdit model)
        {

            var data = await _icategoryRepository.GetAsync(id);
            if(data == null)
            {
                ModelState.AddModelError("Id", "Categoria não encontrada");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             data.Update(model.Name, model.Description);
            _icategoryRepository.Update(data);
            return Ok();
         
          

        }


    }
}
