using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoCidades.Models;
using ProjetoCidades.Repositorio;

namespace ProjetoCidades.Controllers
{
    public class CidadesController : Controller
    {
        Cidade cidade = new Cidade();
        CidadeRep cidadeRep = new CidadeRep();
        public IActionResult Index()
        {
            var lista = cidadeRep.Listar();
            return View(lista);
        }

        public IActionResult CidadesEstados()
        {
            var lista = cidadeRep.Listar();
            return View(lista);
        }

        public IActionResult TodosOsDados()
        {
            var lista = cidadeRep.Listar();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([Bind]Cidade cidade)
        {
            cidadeRep.Cadastrar(cidade);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int? Id)
        {
            Cidade cidade = cidadeRep.Listar().Where(c => c.Id == Id).FirstOrDefault();
            return View(cidade);
        }

        [HttpPost]
        public IActionResult Editar([Bind]Cidade cidade)
        {
            cidadeRep.Editar(cidade);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(Cidade cidade)
        {
            cidadeRep.Excluir(cidade);
            return RedirectToAction("Index");
        }

        public IActionResult Voltar()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Detalhes(int Id)
        {
            var cidade = cidadeRep.Listar(Id);
            return View(cidade);
        }

    }
}