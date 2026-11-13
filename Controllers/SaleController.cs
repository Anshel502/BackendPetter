using Backend.DTOs;
using Backend.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly ICommonService<SaleDto, SaleInsertDto, SaleUpdateDto> _saleService;
    private readonly IValidator<SaleInsertDto> _insertValidator;

    public SaleController(
        [FromKeyedServices("saleService")] ICommonService<SaleDto, SaleInsertDto, SaleUpdateDto> saleService,
        IValidator<SaleInsertDto> insertValidator)
    {
        _saleService = saleService;
        _insertValidator = insertValidator;
    }

    [HttpPost]
    public async Task<ActionResult<SaleDto>> Add(SaleInsertDto dto)
    {
        var validationResult = await _insertValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var saleDto = await _saleService.Add(dto);
        return CreatedAtAction(nameof(GetById), new { id = saleDto.SaleId }, saleDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SaleDto>> GetById(int id)
    {
        var sale = await _saleService.GetById(id);
        return sale == null ? NotFound() : Ok(sale);
    }
    
}