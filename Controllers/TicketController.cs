using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Projeto_Claro.Data;
using Projeto_Claro.Models;


namespace Projeto_Claro.Controllers
{
    public class TicketController : Controller
    {
   

        private readonly DatabaseContext _databaseContext;
        public TicketController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        static async Task<string> ApiConnection()
        {
            string apiUrl = "https://api.ipify.org?format=json";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        
                        using var jsonDoc = System.Text.Json.JsonDocument.Parse(responseBody);
                        var ip = jsonDoc.RootElement.GetProperty("ip").GetString();
                        return ip ?? "IP não encontrado";
                    }
                    else
                    {
                        return $"Erro: {response.StatusCode}";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Erro: {ex.Message}";
            }
        }
        [Route("metrics-ticket_abertos")]
        public async Task<IActionResult> Metricas()
        {
            int count = await _databaseContext.Ticket.CountAsync();
            return View("Metricas",count);
        }

        [HttpGet]
        public IActionResult Historico()
        {
            return View(new HistoricoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> HistoricoTicket(HistoricoViewModel model)
        {
            if (string.IsNullOrEmpty(model.MyCPF))
            {
                ModelState.AddModelError("MyCPF", "Informe um CPF válido.");
                return View("Historico", model);
            }

            var viewTicket = await _databaseContext.Ticket
                .Where(t => t.CPF == model.MyCPF)
                .ToListAsync();

            model.Tickets = viewTicket;

            return View("Historico", model);
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            
            return View("Index");
        }
        public IActionResult Create()
        {
            var createTicket = new ticketModel();
            return View(createTicket);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ticketModel ticket)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    ticket.IPlocal = await ApiConnection();
                    Console.WriteLine(ticket);
                    _databaseContext.Add(ticket);
                }
                else
                {
                    var erros = ModelState.Values.SelectMany(v => v.Errors)
                                                 .Select(e => e.ErrorMessage)
                                                 .ToList();
                    ViewBag.ModelErrors = erros;
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message;
            }
            await _databaseContext.SaveChangesAsync();
            return View("Index", ticket);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}









