using Microsoft.AspNetCore.Mvc;
using Atividade_LPV2.Models;

namespace Atividade_LPV2.Controllers;

public class ClientePremiumController : Controller
{
    [HttpGet]
    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(ClientePremiumViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        TempData["Sucesso"] = "Cliente Premium cadastrado com sucesso!";
        return RedirectToAction(nameof(Cadastrar));
    }
}
