using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI {

    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase {

        static private List<Autor> autores;

        public AutorController() {

            autores ??= [];
            CargaInicial();
        }

        void CargaInicial() {
            autores.Add(new Autor(1001, "RR"));
            autores.Add(new Autor(1002, "WW"));
        }

        [HttpGet]
        public List<Autor> GetAutores() {
            return autores;
        }

        [HttpGet("byId/{Id}")]
        public IActionResult GetAutorID(int Id) {
            foreach(Autor a in autores)
            {
                if(a.Id == Id)
                    return Ok(a);
            }

            return NotFound("Autor não encontrado");
        }

        [HttpGet("byName/{Nome}")]
        public IActionResult GetAutorNome(string Nome) {
            foreach(Autor a in autores) {
                if(a.Nome == Nome) {
                    return Ok(a);
                }
            }

            return NotFound("Autor não encontrado");
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