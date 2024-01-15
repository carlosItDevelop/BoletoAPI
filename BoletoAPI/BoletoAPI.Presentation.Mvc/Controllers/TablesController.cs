using Microsoft.AspNetCore.Mvc;

namespace SDTEC.GestorEducacional.Controllers
{
    public class TablesController : Controller
    {
        public IActionResult Basic() => View();
        public IActionResult GenerateStyle() => View();
    }
}
