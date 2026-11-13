using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators;

public class SupplierInsertValidator : AbstractValidator<SupplierInsertDto>
{
    public SupplierInsertValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre del proveedor es obligatorio.");
        RuleFor(x => x.Country).NotEmpty().WithMessage("El pais debe de ser Obligatorio");
        RuleFor(x => x.Phone).MaximumLength(15).WithMessage("El teléfono no puede exceder los 20 caracteres.");
    }
}