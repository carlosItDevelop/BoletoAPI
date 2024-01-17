using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SDTEC.GestorEducacional.BoletoMvc.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.CompletedTask;
            return View();
        }
    }
}
