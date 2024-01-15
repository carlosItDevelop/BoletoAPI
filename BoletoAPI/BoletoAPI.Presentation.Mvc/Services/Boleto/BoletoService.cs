using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SDTEC.GestorEducacional.BoletoMvc.Extensions;
using SDTEC.GestorEducacional.BoletoMvc.Models;
using SDTEC.GestorEducacional.Models;

namespace SDTEC.GestorEducacional.BoletoMvc.Services.Boleto
{
    public class BoletoService : Service, IBoletoService
    {
        private readonly HttpClient _httpClient;

        public BoletoService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.BoletoApiUrl);

            _httpClient = httpClient;
        }


        public async Task<ResponseResult> GerarBoletoService(BoletoViewModel viewModel)
        {
            return await ApplyRequest<BoletoViewModel>(viewModel, "/boleto/obterboleto/");
        }


        private async Task<ResponseResult> ApplyRequest<T>(T modelo, string rota) where T : class
        {
            var content = ObterConteudo(modelo);
            var response = await _httpClient.PostAsync($"{rota}", content);
            if (!TratarErrosResponse(response))
                return await DeserializarObjetoResponse<ResponseResult>(response);

            return new ResponseResult();
        }


    }
}
