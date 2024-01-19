using Microsoft.AspNetCore.Mvc;
using SistemaNotasImperio.Models.Data;

namespace SistemaNotasImperio.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpresaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var empresas = _context.Empresas.ToList();
            return View(empresas);
        }

        public IActionResult Details(int id)
        {
            var empresa = _context.Empresas.FirstOrDefault(e => e.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }
    }
}
