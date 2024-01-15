using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI {

    [ApiController]
    [Route("[controller]")]
    public class EditoraController : ControllerBase {
        
        static private List<Editora> editoras;

        public EditoraController() {

            editoras ??= [];
            CargaInicial();
        }

        void CargaInicial() {
            editoras.Add(new Editora(505, "Hrecords"));
            editoras.Add(new Editora(506, "Wrecords"));
        }

        [HttpGet]
        public List<Editora> GetEditoras() {
            return editoras;
        }

        [HttpGet("byId/{Id}")]
        public IActionResult GetEditoraID(int Id) {
            foreach(Editora e in editoras)
            {
                if(e.Id == Id)
                    return Ok(e);
            }

            return NotFound("Editora não encontrada");
        }

        [HttpGet("byName/{Nome}")]
        public IActionResult GetEditoraNome(string Nome) {
            foreach(Editora e in editoras) {
                if(e.Nome == Nome) {
                    return Ok(e);
                }
            }

            return NotFound("Editora não encontrada");
        }

        [HttpPost("{Id}/{Nome}")]
        public List<Editora> InserirEditora(int Id, string Nome) {
            Editora e = new(Id, Nome);
            editoras.Add(e);
            return editoras;
        }

        [HttpPut("byId/{Id}")]
        public List<Editora> AtualizarEditora(int Id, string novoNome) {

             try {
                Editora ?editora = editoras.Find(l => l.Id == Id);

                if (editora != null) {
                    editora.Nome = novoNome;
                    return editoras;
                } else {
                    throw new EditoraException("A editora não foi encontrada.");
                }
            } catch (EditoraException e) {
                Console.WriteLine($"Erro: {e.alternativa}");
                return editoras; 
            } catch (Exception ex) {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                return editoras; 
            }
        }

        [HttpDelete("{id:int}")]
        public List<Editora> RemoverEditora(int Id) {

            try {
                Editora ?editora = editoras.Find(l => l.Id == Id);
                if (editora != null) {
                    editoras.Remove(editora);
                    return editoras;
                    
                }
                else {
                    throw new EditoraException("A editora não foi encontrada");
                }
            } 
            catch(EditoraException l) {
                System.Console.WriteLine($"Erro: {l.alternativa}");
                return editoras;
            }
            catch(Exception e) {
                Console.WriteLine($"Erro inesperado: {e.Message}");
                return editoras;
            }
                
        }
    }
}