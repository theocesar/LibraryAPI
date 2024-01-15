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
    }
}