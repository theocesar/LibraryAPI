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

        [HttpPut("byId/{Id}")]
        public List<Livro> AtualizarLivro(int Id, string atualizacao, int novoAno) {

            try {
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