namespace LibraryAPI;

class EditoraException : ApplicationException {
    public string alternativa{get;}

    public EditoraException(string texto) {
        alternativa = texto;
    }
}

public class Editora {
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Livro> Livros { get; set; }

    public Editora() {

    }

    public Editora(int Id, string Nome) {
        this.Id = Id;
        this.Nome = Nome;
        Livros = [];
    }
}