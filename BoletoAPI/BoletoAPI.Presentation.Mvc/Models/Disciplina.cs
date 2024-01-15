using System.ComponentModel.DataAnnotations;
using SDTEC.GestorEducacional.Models.Base;

namespace SDTEC.GestorEducacional.Models
{
    public class Disciplina : EntityBase
    {
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        public int Ordem { get; set; }
        public int CargaHoraria { get; set; }
        public decimal ValorCobrado { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
