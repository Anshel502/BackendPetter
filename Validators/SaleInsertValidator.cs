using Backend.DTOs;
using Backend.Models;
using Backend.Repository;
using FluentValidation;

namespace Backend.Validators;

public class SaleInsertValidator : AbstractValidator<SaleInsertDto>
{
    private readonly IRepository<Inventory> _inventoryRepository;

    public SaleInsertValidator(IRepository<Inventory> inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
        RuleFor(x => x.InventoryId).MustAsync(InventoryExists).WithMessage("El lote de inventario especificado no existe.");
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("La cantidad debe ser mayor a 0.");
        RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("La cantidad debe ser mayor a 0.");
        RuleFor(x => x.SaleDate).NotEmpty().WithMessage("La fecha de venta es obligatoria.");
        RuleFor(x => x.ClientName).NotEmpty().WithMessage("El nombre es obligatorio.");


        


    }

    private async Task<bool> InventoryExists(int inventoryId, CancellationToken cancellationToken)
    {
        var inventory = await _inventoryRepository.GetById(inventoryId);
        return inventory != null;
    }
}