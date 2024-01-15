using Microsoft.AspNetCore.Mvc;

namespace SDTEC.GestorEducacional.Controllers
{
    public class NotificationsController : Controller
    {
        public IActionResult Sweetalert2() => View();
        public IActionResult Toastr() => View();
    }
}
