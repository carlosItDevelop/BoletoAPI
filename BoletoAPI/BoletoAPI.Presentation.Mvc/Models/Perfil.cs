using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SDTEC.GestorEducacional.Models
{
    public class Perfil : IdentityRole
    {
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres!")]
        public string Descricao { get; set; }
    }
}
