using SDTEC.GestorEducacional.BoletoMvc.Models;
using SDTEC.GestorEducacional.Models;
using System.Threading.Tasks;

namespace SDTEC.GestorEducacional.BoletoMvc.Services.Boleto
{
    public interface IBoletoService
    {
        Task<ResponseResult> GerarBoletoService(BoletoViewModel viewModel);
    }
}
