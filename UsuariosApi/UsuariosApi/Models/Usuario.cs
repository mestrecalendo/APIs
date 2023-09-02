using Microsoft.AspNetCore.Identity;

namespace UsuariosApi.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime DataDeNascimento { get; set; }

        public Usuario() : base()
        {

        }
    }
}
