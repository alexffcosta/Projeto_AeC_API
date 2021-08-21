using System.Collections.Generic;

namespace ProjetoAeC_main.Apresentacao
{
    public class HomeView
    {
        public string Mensagem
        {
            get{ return "Olá sejam muito bem vindo a minha API";}
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