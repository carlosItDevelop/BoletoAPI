using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using SDTEC.GestorEducacional.BoletoMvc.Services.Boleto;
using SDTEC.GestorEducacional.BoletoMvc.Models;

namespace SDTEC.GestorEducacional.BoletoMvc.Controllers
{
    public class MvcBoletoController : MainController
    {
        private readonly IBoletoService _boletoService;

        public MvcBoletoController(IBoletoService boletoService)
        {
            _boletoService = boletoService;
        }

        [HttpGet("gerar-boleto")]
        public IActionResult AdicionarCriador()
        {
            return View();
        }

        [HttpPost]
        [Route("gerar-boleto")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarCriador([FromForm] BoletoViewModel viewModel)
        {

            //viewModel.Id = // gerar Id

            if (!ModelState.IsValid)
            {
                TempData ["Erros"] =
                    ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return View(viewModel);
            }

            if (!OperacaoValida())
                return View(viewModel);


            if (ResponsePossuiErros(await _boletoService.GerarBoletoService(viewModel)))
            {
                TempData ["Erros"] =
                    ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();

                return View(viewModel);
            }

            return RedirectToAction("Index", "MvcBoleto");

        }

    }
}
