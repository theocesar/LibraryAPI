namespace LibraryAPI;

class AutorException : ApplicationException {
    public string alternativa{get;}

    public AutorException(string texto) {
        alternativa = texto;
    }
}

public class Autor {
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Livro> Livros { get; set; }

    public Autor() {

    }

    public Autor(int Id, string Nome) {
        this.Id = Id;
        this.Nome = Nome;
        Livros = [];
    }
}