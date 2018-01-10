using System.Collections.Generic;

namespace ProjetoCidades.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public int Habitantes { get; set; }

        public List<Cidade> ListarCidades(){
            
            List<Cidade> cidade = new List<Cidade>(){
                new Cidade{Id = 10, Nome = "Curitiba", Estado = "PR", Habitantes = 1545},
                new Cidade{Id = 15, Nome = "Leme", Estado = "SP", Habitantes = 1678},
                new Cidade{Id = 20, Nome = "Porto Alegre", Estado = "RS", Habitantes = 1345},
                new Cidade{Id = 25, Nome = "Campinas", Estado = "SP", Habitantes = 1222},
                new Cidade{Id = 30, Nome = "São Paulo", Estado = "SP", Habitantes = 1845},
                new Cidade{Id = 35, Nome = "Vitória", Estado = "ES", Habitantes = 1922}
            };

            return cidade;
        }
    }
}