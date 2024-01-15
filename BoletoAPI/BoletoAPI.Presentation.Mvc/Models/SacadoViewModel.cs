using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SDTEC.GestorEducacional.BoletoMvc.Models
{
    public class SacadoViewModel
    {

        #region Propriedades



        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Nome")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("CPF")]
        public string CPF { get; set; } = string.Empty;

        #endregion Propriedades

        #region Propriedades de navegação

        public EnderecoViewModel EnderecoViewModel { get; set; } = new EnderecoViewModel();

        #endregion Propriedades de navegação

    }
}
