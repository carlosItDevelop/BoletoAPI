using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SDTEC.GestorEducacional.Controllers
{
    public class FormaDePagamentoController : Controller
    {
        // GET: FormaDePagamentoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FormaDePagamentoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FormaDePagamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormaDePagamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FormaDePagamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FormaDePagamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FormaDePagamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FormaDePagamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
