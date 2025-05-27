using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.Dtos;
using ProdutosAPI.Services.Abstract;
using ProdutosAPI.Utils;

namespace ProdutosAPI.Controllers
{
    [ApiController]
    [Route("api/v1/produto")]
    [BasicAuth]
    public class ProdutoCtrl : ControllerBase
    {
        private readonly IProdutoServ _produtoServ;

        public ProdutoCtrl(IProdutoServ produtoServ)
        {
            _produtoServ = produtoServ;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProdutoDTO produtoDTO)
        {
            await _produtoServ.AddAsync(produtoDTO);
            return Ok(new
            {
                produtoId = produtoDTO.ProdutoId,
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _produtoServ.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _produtoServ.GetByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProdutoDTO produtoDTO)
        {
            try
            {
                await _produtoServ.UpdateAsync(id, produtoDTO);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] float preco)
        {
            try
            {
                await _produtoServ.PatchAsync(id, preco);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtoServ.DeleteAsync(id);
            return NoContent();
        }
    }
}
