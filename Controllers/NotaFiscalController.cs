using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaNotasImperio.Models.Data;

namespace SistemaNotasImperio.Controllers
{
    public class NotaFiscalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotaFiscalController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var notasFiscais = _context.NotasFiscais.ToList();  // Remova o Include
            return View(notasFiscais);
        }

        public IActionResult Details(int id)
        {
            var notaFiscal = _context.NotasFiscais.FirstOrDefault(n => n.Id == id);  // Remova o Include
            if (notaFiscal == null)
            {
                return NotFound();
            }
            return View(notaFiscal);
        }

        public IActionResult Create()
        {
            ViewBag.Empresas = _context.Empresas.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NotaFiscal notaFiscal)
        {
            if (ModelState.IsValid)
            {
                var nota = new NotaFiscal
                {
                    Nome = notaFiscal.Nome,
                    Valor = notaFiscal.Valor,
                    Descricao = notaFiscal.Descricao,
                    DataCompra = notaFiscal.DataCompra,
                    EmpresaId = notaFiscal.EmpresaId
                };

                _context.NotasFiscais.Add(nota);  // Corrigido para adicionar 'nota'
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Empresas = _context.Empresas.ToList();
            return View(notaFiscal);
        }

    }
}
