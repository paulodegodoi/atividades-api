using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Atividades.Domain.Models;

namespace Atividades.APP.Controllers;

public class AtividadesController : Controller
{
    private readonly string baseApiUrl = "http://localhost:5153/api";
    // GET
    public async Task<IActionResult> Index()
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"{baseApiUrl}/atividades");

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var atividadesList = JsonSerializer.Deserialize<List<Atividade>>(data);

                    return View(atividadesList);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return View();
    }
}