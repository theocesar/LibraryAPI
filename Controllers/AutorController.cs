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

        [HttpPut("byId/{Id}")]
        public List<Autor> AtualizarAutor(int Id, string novoNome) {

            try {
                Autor ?autor = autores.Find(l => l.Id == Id);

                if (autor != null) {
                    autor.Nome = novoNome;
                    return autores;
                } else {
                    throw new AutorException("O autor não foi encontrado.");
                }
            } catch (AutorException e) {
                Console.WriteLine($"Erro: {e.alternativa}");
                return autores; 
            } catch (Exception ex) {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                return autores; 
            }
        }

        [HttpDelete("{id:int}")]
        public List<Autor> RemoverAutor(int Id) {

            try {
                Autor ?autor = autores.Find(l => l.Id == Id);
                if (autor != null) {
                    autores.Remove(autor);
                    return autores;
                    
                }
                else {
                    throw new AutorException("O autor não foi encontrado");
                }
            } 
            catch(AutorException l) {
                System.Console.WriteLine($"Erro: {l.alternativa}");
                return autores;
            }
            catch(Exception e) {
                Console.WriteLine($"Erro inesperado: {e.Message}");
                return autores;
            }
                
        }
    }
}