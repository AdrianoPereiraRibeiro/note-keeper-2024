using FluentValidation;
using NoteKeeper.Dominio.ModuloNota;

public class ValidadorNota : AbstractValidator<Nota>
{
    public ValidadorNota()
    {
        RuleFor(x => x.Titulo)
            .NotEmpty()
            .WithMessage("O título é obrigatório.")
            .MinimumLength(3).WithMessage("Mínimo 3 caracteres.")
            .MinimumLength(30).WithMessage("Máximo 30 caracteres.");

        RuleFor(x => x.Conteudo)
            .MaximumLength(100).WithMessage("Máximo 100 caracteres");






    }


}