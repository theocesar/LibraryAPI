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
    }
}