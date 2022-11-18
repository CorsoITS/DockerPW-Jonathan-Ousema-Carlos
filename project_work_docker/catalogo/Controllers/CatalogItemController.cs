using Microsoft.AspNetCore.Mvc;
using catalogo.Service;
using catalogo.Models;


namespace catalogo.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogItemController : ControllerBase
{
    private CatalogItemService catalogItemService = new CatalogItemService();
    
    [HttpGet]
    public IEnumerable<CatalogItem> GetCatalogItems()
    {
        return catalogItemService.GetCatalogItems();
    }

    [HttpGet("{sku}")]
    public CatalogItem GetCatalogItem(int sku)
    {
        return catalogItemService.GetCatalogItem(sku);
    }
}