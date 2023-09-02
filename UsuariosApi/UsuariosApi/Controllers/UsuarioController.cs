using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using AutoMapper;
using UsuariosApi.Models;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Service;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto dto)
        {
            await _usuarioService.Cadastra(dto);
            return Ok("Usuario Criado!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
        {
            await _usuarioService.LoginAsync(dto);

            return Ok("Usuario Autenticado!");
        }

    }
}
