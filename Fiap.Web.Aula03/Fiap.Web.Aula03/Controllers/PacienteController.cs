using Fiap.Web.Aula03.Models;
using Fiap.Web.Aula03.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Aula03.Controllers
{
    public class PacienteController : Controller
    {
        private HospitalContext _context;

        //Recebe o DbContext por injeção de dependência
        public PacienteController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Pacientes.ToList());
        }
        //Tarefa é criar o CRUD com o Banco
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            TempData["msg"] = "Paciente cadastrado com sucesso";
            return RedirectToAction("cadastrar");
        }

        [HttpPost]
        public IActionResult Editar(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
            TempData["msg"] = "Paciente atualizado com sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            return View(_context.Pacientes.Find(id));
        }

        [HttpPost]
        public IActionResult Excluir(int id) 
        {
            _context.Pacientes.Remove(_context.Pacientes.First(p => p.PacienteId == id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
