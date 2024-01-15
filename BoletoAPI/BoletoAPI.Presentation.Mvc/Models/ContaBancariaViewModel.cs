using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SDTEC.GestorEducacional.BoletoMvc.Models
{
    public class ContaBancariaViewModel
    {
        #region Propriedades

        [Key]
        [DisplayName("Conta bancária Id")]
        public int ContaBancariaDTOId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Agencia { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Conta { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CarteiraPadrao { get; set; } = string.Empty;

        #endregion Propriedades
    }
}
