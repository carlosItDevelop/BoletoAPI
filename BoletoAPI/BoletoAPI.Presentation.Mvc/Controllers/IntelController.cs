using Microsoft.AspNetCore.Mvc;

namespace SDTEC.GestorEducacional.Controllers
{
    public class IntelController : Controller
    {
        public IActionResult AnalyticsDashboard() => View();
        public IActionResult Introduction() => View();
        public IActionResult MarketingDashboard() => View();
        public IActionResult Privacy() => View();
    }
}
