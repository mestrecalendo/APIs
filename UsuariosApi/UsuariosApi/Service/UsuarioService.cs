using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Service
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task Cadastra(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            IdentityResult res = await _userManager.CreateAsync(usuario, dto.Password);

            if (!res.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário");
            }
            
        }

        public async Task LoginAsync(LoginUsuarioDto dto)
        {
            var res = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);

            if (!res.Succeeded)
            {
                throw new ApplicationException("Erro ao autenticar usuário");
            }
        }
    }
}
