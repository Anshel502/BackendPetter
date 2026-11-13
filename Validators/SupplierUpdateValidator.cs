using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators;

public class SupplierUpdateValidator : AbstractValidator<SupplierUpdateDto>
{
    public SupplierUpdateValidator()
    {
        RuleFor(x => x.SupplierId).NotNull().WithMessage("El Id es obligatorio ");
        RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre del proveedor es obligatorio");
        RuleFor(x => x.Country).NotEmpty().WithMessage("EL pais debe de ser obligatorio");
        RuleFor(x => x.Phone).MaximumLength(20).WithMessage("El teléfono no puede exceder los 20 caracteres.");
    }
}