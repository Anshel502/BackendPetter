using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators;

public class SaleUpdateValidator : AbstractValidator<SaleUpdateDto>
{
    public SaleUpdateValidator()
    {
        RuleFor(x => x.SaleId).NotNull().WithMessage("El Id es obligatorio ");
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("La cantidad debe ser mayor a 0.");
        RuleFor(x => x.ClientName).Length(2, 50).WithMessage("El nombre del cliente debe medir entre 2 y 50 caracteres.");
    }
}