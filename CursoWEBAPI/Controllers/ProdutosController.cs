using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoWEBAPI.Models;
using Dominio.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CursoWEBAPI.Controllers
{
    [Route("api/v1/[Controller]")]
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _iprodutoRepository;

        private readonly IcategoryRepository _icategoryRepository;

        public ProdutosController(IProdutoRepository iprodutoRepository, IcategoryRepository icategoryRepository)
        {
            _iprodutoRepository = iprodutoRepository;
            this._icategoryRepository = icategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dados = (await _iprodutoRepository.GetAllWithCategoryAsync()).Select(p => p.toProductGet());
            return Ok(dados);
        }

        [HttpGet("{id}", Name = "GetProdutoByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            var dados = (await _iprodutoRepository.GetByIdWithCategoryAsync(id));
            if (dados == null)
            {
                return NotFound();
            }
            return Ok(dados.toProductGet());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductsAddEdit model)
        {
            var categoria = await _icategoryRepository.GetAsync(model.category_Id);
            if (categoria == null)
            {
                ModelState.AddModelError("category_Id", "Categoria Invalida");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = model.toProducts();
            _iprodutoRepository.Add(data);

            var produto = data.toProductGet();
            produto.category_Name = categoria.Name;

            return CreatedAtRoute("GetProdutoByID", new { produto.Id }, produto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductsAddEdit model)
        
        {
            var categoria = await _icategoryRepository.GetAsync(model.category_Id);
            if (categoria == null)
            {
                ModelState.AddModelError("category_Id", "Categoria Invalida");
            }

            var produto = await _iprodutoRepository.GetAsync(id);
            if(produto == null)
            {
                ModelState.AddModelError("Id", "Produto não encontrado.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            produto.update(model.category_Id, model.price, model.name);
            _iprodutoRepository.Update(produto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _iprodutoRepository.GetAsync(id);
            if(produto == null)
            {
                return BadRequest(new { Produto = new string[] { "Produto não localizado."} });
            }
            _iprodutoRepository.Delete(produto);
            return Ok();
        }
    }
}
