using Microsoft.AspNetCore.Mvc;
using ProjetoAeC_main.Apresentacao;

namespace ProjetoAeC_main.Controllers
{
    [ApiController]
    
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public HomeView Get()
        {
            return new HomeView();
        }
        
    }
}