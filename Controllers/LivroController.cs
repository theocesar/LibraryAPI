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
    }
}