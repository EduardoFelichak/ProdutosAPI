using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.Dtos;
using ProdutosAPI.Services.Abstract;

namespace ProdutosAPI.Controllers
{
    [ApiController]
    [Route("api/v1/usuario")]
    public class UsuarioCtrl : ControllerBase
    {
        private readonly IUsuarioServ _usuarioServ;

        public UsuarioCtrl(IUsuarioServ usuarioServ)
        {
            _usuarioServ = usuarioServ;
        }

        [HttpPost]
        public async Task<IActionResult> Add(UsuarioDTO usuarioDTO)
        {
            await _usuarioServ.AddAsync(usuarioDTO);
            return Ok(new
            {
                usuarioId = usuarioDTO.UsuarioId,
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _usuarioServ.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _usuarioServ.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UsuarioDTO usuarioDTO)
        {
            await _usuarioServ.UpdateAsync(id, usuarioDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _usuarioServ.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            var usuario = await _usuarioServ.LoginAsync(loginDto.Email, loginDto.Senha);

            if (usuario == null)
                return Unauthorized(new { message = "Email ou senha inválidos" });

            return Ok();
        }
    }
}
