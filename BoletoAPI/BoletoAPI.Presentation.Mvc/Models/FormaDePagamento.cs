using System.ComponentModel.DataAnnotations;
using SDTEC.GestorEducacional.Models.Base;

namespace SDTEC.GestorEducacional.Models
{
    public class FormaDePagamento : EntityBase
    {
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Descricao { get; set; }
    }
}
