using System.Collections.Generic;

namespace ProjetoAeC_main.Apresentacao
{
    public class HomeView
    {
        public string Mensagem
        {
            get{ return "dadhjahd vindo a minha API";}
        }
        public List<string> Endpoints
        {
            get
            { 
                return new List<string>() 
             {
                "/vagas",
                "/candidatos",
                "/swagger"
             };
            
            }
        }
    }
}