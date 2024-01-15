using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI {

    [ApiController]
    [Route("[controller]")]
    public class EditoraController : ControllerBase {
        
        static private List<Editora> editoras;

        public EditoraController() {

            editoras ??= [];
            // carga inicial
        }

        [HttpGet]
        public List<Editora> GetEditoras() {
            return editoras;
        }

        [HttpPost("{Id}/{Nome}")]
        public List<Editora> InserirEditora(int Id, string Nome) {
            Editora e = new(Id, Nome);
            editoras.Add(e);
            return editoras;
        }

        [HttpPost("byId/{Id}")]
        public List<Editora> AtualizarEditora(int Id, string novoNome) {

            foreach(Editora e in editoras) {
                if (e.Id == Id) {
                    e.Nome = novoNome;
                    return editoras;
                }
            }
            throw new EditoraException("A editora não existe");
        }
    }
}