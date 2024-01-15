using System.ComponentModel.DataAnnotations;
using SDTEC.GestorEducacional.Models.Base;

namespace SDTEC.GestorEducacional.Models
{
    public class Documento : EntityBase
    {
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
