using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Avaliacao.Models;

namespace Avaliacao.Controllers;

public class LojasController : Controller {
    public static List<LojasViewModel> lojas = new List<LojasViewModel>();

    public IActionResult Index()
    {
        return View(lojas);
    }

    public IActionResult Gerenciamento()
    {
        return View(lojas);
    }

    public IActionResult Excluir(int id)
    {
        lojas.RemoveAt(id-1);
        return View();
    }

    public IActionResult Detalhe(int id)
    {
        return View(lojas[id-1]);
    }

    public IActionResult Cadastro([FromForm] string piso, [FromForm] string nome, [FromForm] string descricao, [FromForm] string tipo, [FromForm] string email)
    {
        int id = 1;

        foreach(var loja in lojas)
        {
            if(nome == loja.Nome) 
            {
                ViewData["Mensagem"] = "Não foi possivel completar o cadastro!";
                ViewData["Motivo"] = "Loja já cadastrada!";
                return View();
            }
        }

        for(int i = 0; i < lojas.Count; i++) {
            id++;
        }
       
        lojas.Add(new LojasViewModel(id, piso, nome, descricao, tipo, email));

        ViewData["Mensagem"] = "Cadastro completo!";
        ViewData["Motivo"] = "Loja cadastrada com sucesso!";
        return View();
    }
    
    public IActionResult Cadastrar()
    {
        return View();
    }
}