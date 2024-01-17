using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using BoletoAPI.Application.DTOs;
using BoletoAPI.Application.Interfaces;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SDTEC.GestorEducacional.BoletoMvc.Controllers
{
    public class BoletosController : MainController
    {
        private readonly IBoletoService _boletoService;
        private readonly IConverter _converter;

        public BoletosController(IBoletoService boletoService,
                                 IConverter converter)
        {
            _boletoService = boletoService;
            _converter = converter;
        }

        [HttpGet]
        public IActionResult GetBoleto()
        {
            return View();
        }

        /// <summary>
        /// Essa endpoint tem como finalidade de processar o layout do boleto do banco por tipo do banco.
        /// </summary>
        /// <param name="dadosBoletoDTO">Propriedades DTOs que devem ser preenchidas para consumo do boleto</param>
        /// <returns>Retorna o layout do boleto.</returns>
        //[ProducesResponseType(typeof(DadosBoletoDTO), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetBoleto(DadosBoletoDTO dadosBoletoDTO)
        {

            if (!ModelState.IsValid)
            {
                TempData ["Erros"] =
                    ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return View(dadosBoletoDTO);
            }


            if (!OperacaoValida())
                return View(dadosBoletoDTO);


            var gerarHTMLBoleto = await _boletoService.GerarHTMLBoleto(dadosBoletoDTO);

            if (gerarHTMLBoleto == null)
                return BadRequest("O Objeto está Null");


            byte [] pdfBytes = _converter.Convert(new HtmlToPdfDocument
            {
                GlobalSettings = {
                    ColorMode = DinkToPdf.ColorMode.Color,
                    PaperSize = DinkToPdf.PaperKind.A4,
                    Margins = new MarginSettings { Top = 10, Bottom = 10 }
                },
                Objects = {
                    new ObjectSettings {
                        HtmlContent = gerarHTMLBoleto,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            });

            // Armazene o PDF como um array de bytes na TempData
            TempData ["BoletoPDF"] = pdfBytes;

            // Redirecione para a Action "MostrarBoleto" com uma mensagem
            TempData ["BoletoMessage"] = "PDF do boleto pronto para visualização.";
            return RedirectToAction("MostrarBoleto");

        }

        [HttpGet]
        public IActionResult MostrarBoleto()
        {
            // Obtenha o PDF da TempData
            byte [] pdfBytes = TempData ["BoletoPDF"] as byte [];

            if (pdfBytes == null)
            {
                return BadRequest("O PDF do boleto não está disponível.");
            }

            // Retorne o PDF como um arquivo para download
            return File(pdfBytes, "application/pdf", "boleto.pdf");
        }


    }
}
