using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI {

    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase {

        static private List<Autor> autores;

        public AutorController() {

            autores ??= [];
            // carga inicial
        }

        [HttpGet]
        public List<Autor> GetAutores() {
            return autores;
        }

        [HttpPost("{Id}/{Nome}")]
        public List<Autor> InserirAutor(int Id, string Nome) {
            Autor a = new(Id, Nome);
            autores.Add(a);
            return autores;
        }

        [HttpPost("byId/{Id}")]
        public List<Autor> AtualizarAutor(int Id, string novoNome) {

            foreach(Autor a in autores) {
                if (a.Id == Id) {
                    a.Nome = novoNome;
                    return autores;
                }
            }
            throw new AutorException("O autor não existe");
        }
    }
}