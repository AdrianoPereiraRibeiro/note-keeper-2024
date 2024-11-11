using FluentValidation;
using NoteKeeper.Dominio.ModuloCategoria;

public class ValidadorCategoria : AbstractValidator<Categoria>
{
    public ValidadorCategoria()
    {
        RuleFor(x => x.Titulo)
            .NotEmpty().WithMessage("O título é obrigatório")
            .MaximumLength(30).WithMessage("O título deve conter no máximo 30 caracteres.")
            .MinimumLength(3).WithMessage("O título deve conter no mínimo 30 caracteres.")
            ;
    }

}