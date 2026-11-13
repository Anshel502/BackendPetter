using System;
using System.Xml;
using Backend.DTOs;
using Backend.Models;
using Backend.Repository;

namespace Backend.Services;

public class SaleService : ICommonService<SaleDto, SaleInsertDto, SaleUpdateDto>
{

    private IRepository<Sale> _saleRepository;
    private IRepository<Beer> _beerRepository;

    public SaleService(IRepository<Sale> saleRepository, IRepository<Beer> beerRepository)
    {
        _saleRepository = saleRepository;
        _beerRepository = beerRepository;
    }
    public async Task<IEnumerable<SaleDto>> Get()
    {
        var sales = await _saleRepository.Get();
        return sales.Select(i => new SaleDto
        {
            InventoryId = i.InventoryId,
            Quantity = i.Quantity,
            UnitPrice=i.UnitPrice,
            SaleDate=i.SaleDate,
            ClientName=i.ClientName
            
        });
    }
    public async Task<SaleDto> GetById(int id)
    {
        var sale = await _saleRepository.GetById(id);
        var result = new SaleDto
        {
            SaleId = sale.SaleId,
            Quantity = sale.Quantity,
            UnitPrice=sale.UnitPrice,
            SaleDate=sale.SaleDate,
            ClientName=sale.ClientName
           
        };

        if (result == null)
        {
            return null;
        }
        return result;
    }

    public async Task<SaleDto> Add(SaleInsertDto dto)
    {

        var sale = new Sale
        {
            Quantity = dto.Quantity,
            UnitPrice=dto.UnitPrice,
            SaleDate=dto.SaleDate,
            ClientName=dto.ClientName
            
        };

        await _saleRepository.Add(sale);
        await _saleRepository.Save();

        var result = new SaleDto
        {
            SaleId = sale.SaleId,
            Quantity = sale.Quantity,
            UnitPrice=sale.UnitPrice,
            SaleDate=sale.SaleDate,
            ClientName=sale.ClientName
           
        };

        return result;

    }
    public async Task<SaleDto> Update(int id, SaleUpdateDto dto)
    {
        var sale = await _saleRepository.GetById(id);

        if (sale == null)
        {
            return null;
        }

        sale.Quantity = dto.Quantity;
          sale.UnitPrice=dto.UnitPrice;
            sale.SaleDate=dto.SaleDate;
            sale.ClientName=dto.ClientName;

        _saleRepository.Update(sale);
        await _saleRepository.Save();

        var saleDto = new SaleDto
        {
            /* public int SaleId { get; set; }
    public int InventoryId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime SaleDate { get; set; }
    public string ClientName { get; set; } = null!;
    public decimal Total { get; set; } */
            SaleId = sale.SaleId,
           
            InventoryId = sale.InventoryId,
             Quantity = sale.Quantity,
            UnitPrice = sale.UnitPrice,
            SaleDate = sale.SaleDate,
            ClientName = sale.ClientName,
        };

        return saleDto;

    }

    public async Task<SaleDto> Delete(int id)
    {
        var sale = await _saleRepository.GetById(id);

        if (sale == null)
        {
            return null;
        }

        _saleRepository.Delete(sale);
        await _saleRepository.Save();

        var saleDto = new SaleDto
        {
            SaleId = sale.SaleId,
              InventoryId = sale.InventoryId,
             Quantity = sale.Quantity,
            UnitPrice = sale.UnitPrice,
            SaleDate = sale.SaleDate,
            ClientName = sale.ClientName,
            
        };

        return saleDto;
    }


    public Task<IEnumerable<BeerDto>> GetBeersByBrand(int brandId)
    {
        throw new NotImplementedException();
    }
    


    public Task<bool> HasBeers(int brandId)
    {
        throw new NotImplementedException();
    }



}
