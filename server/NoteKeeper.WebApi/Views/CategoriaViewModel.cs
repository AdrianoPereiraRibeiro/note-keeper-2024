namespace NoteKeeper.WebApi.Views
{
    public class InserirCategoriaViewModel
    {
        public required string Titulo { get; set; }
    }

    public class EditarCategoriaViewModel
    {
        public required string Titulo { get; set; }
    }

    public class ListarCategoriaViewModel
    {
        public required Guid Id { get; set; }

        public required string Titulo { get; set; }
    }


    public class VisualizarCategoriaViewModel
    {
        public required Guid id { get; set; }
        public  required string Titulo { get; set; }
        public required List<NotaViewModel> Notas { get; set; }

    }
}