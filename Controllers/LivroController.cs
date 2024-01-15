using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI {

    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase {

        static private List<Livro> livros;

        public LivroController() {

            livros ??= [];
            // carga inicial
        }

        [HttpGet]
        public List<Livro> GetLivros() {
            return livros;
        }

        [HttpPost("{Id}/{Titulo}/{AnoPublicacao}/{AutorId}/{EditoraId}")]
        public List<Livro> InserirLivro(int Id, string Titulo, int AnoPublicacao, int AutorId, int EditoraId) {
            Livro l = new(Id, Titulo, AnoPublicacao, AutorId, EditoraId);
            livros.Add(l);
            return livros;
        }

        [HttpPost("byId/{Id}")]
        public List<Livro> AtualizarLivro(int Id, string atualização, int novoAno) {

            foreach(Livro l in livros) {
                if (l.Id == Id) {
                    l.Titulo = atualização;
                    l.AnoPublicacao = novoAno;
                    return livros;
                }
            }
            throw new LivroException("O livro não existe");
        }
    }
}