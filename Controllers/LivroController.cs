using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI {

    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase {

        static private List<Livro> livros;

        public LivroController() {

            livros ??= [];
            CargaInicial();
        }

        void CargaInicial() {
            livros.Add(new Livro(1, "Hello", 2000, 1001, 505));
            livros.Add(new Livro(2, "World", 2001, 1002, 506));
        }

        [HttpGet]   
        public List<Livro> GetLivros() {
            return livros;
        }

        [HttpGet("byId/{Id}")]
        public IActionResult GetLivroID(int Id) {
            foreach(Livro l in livros)
            {
                if(l.Id == Id)
                    return Ok(l);
            }

            return NotFound("Livro não encontrado");
        }

        [HttpGet("byTitle/{Titulo}")]
        public IActionResult GetLivroTitulo(string Titulo) {
            foreach(Livro l in livros) {
                if(l.Titulo == Titulo) {
                    return Ok(l);
                }
            }

            return NotFound("Livro não encontrado");
        }

        [HttpPost("{Id}/{Titulo}/{AnoPublicacao}/{AutorId}/{EditoraId}")]
        public List<Livro> InserirLivro(int Id, string Titulo, int AnoPublicacao, int AutorId, int EditoraId) {
            Livro l = new(Id, Titulo, AnoPublicacao, AutorId, EditoraId);
            livros.Add(l);
            return livros;
        }

        [HttpPut("byId/{Id}")]
        public List<Livro> AtualizarLivro(int Id, string atualizacao, int novoAno) {

            try {
                // Finding the book by the ID
                Livro ?livro = livros.Find(l => l.Id == Id);

                if (livro != null) {
                    livro.Titulo = atualizacao;
                    livro.AnoPublicacao = novoAno;
                    return livros;
                } else {
                    throw new LivroException("O livro não foi encontrado.");
                }
            } catch (LivroException e) {
                Console.WriteLine($"Erro: {e.alternativa}");
                return livros;
            } catch (Exception ex) {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                return livros;
            }
        }

        [HttpDelete("{id:int}")]
        public List<Livro> RemoverLivro(int Id) {

            try {
                // Finding the book by the ID
                Livro ?livro = livros.Find(l => l.Id == Id);
                if (livro != null) {
                    livros.Remove(livro);
                    return livros;

                }
                else {
                    throw new LivroException("O livro não foi encontrado");
                }
            }
            catch(LivroException l) {
                System.Console.WriteLine($"Erro: {l.alternativa}");
                return livros;
            }
            catch(Exception e) {
                Console.WriteLine($"Erro inesperado: {e.Message}");
                return livros;
            }

        }
    }
}