namespace LibraryAPI;

class LivroException : ApplicationException {
    public string alternativa{get;}

    public LivroException(string texto) {
        alternativa = texto;
    }
}


public class Livro {
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int AnoPublicacao { get; set; }
    public int AutorId { get; set; }
    public int EditoraId { get; set; }

    public Livro() {

    }

    public Livro(int Id, string Titulo, int AnoPublicacao, int AutorId, int EditoraId) {
        this.Id = Id;
        this.Titulo =  Titulo;
        this.AnoPublicacao = AnoPublicacao;
        this.AutorId = AutorId;
        this.EditoraId = EditoraId;
    }
}