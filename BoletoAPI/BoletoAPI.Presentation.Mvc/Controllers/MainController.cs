using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SDTEC.GestorEducacional.Models;

namespace SDTEC.GestorEducacional.BoletoMvc.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult resposta)
        {
            if (resposta != null && resposta.Errors != null && resposta.Errors.Mensagens.Any())
            {
                foreach (var mensagem in resposta.Errors.Mensagens)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }

                return true;
            }

            return false;
        }

        public void AdicionarErroValidacao(string mensagem)
        {
            ModelState.AddModelError(string.Empty, mensagem);
        }

        protected bool OperacaoValida()
        {
            return ModelState.ErrorCount == 0;
        }
    }
}
