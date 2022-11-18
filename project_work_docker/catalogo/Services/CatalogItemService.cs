using catalogo.Repositories;
using catalogo.Models;

namespace catalogo.Service;

public class CatalogItemService
{

    private CatalogItemRepository catalogItemRepository = new CatalogItemRepository();

    public IEnumerable<CatalogItem> GetCatalogItems()
    {
        return catalogItemRepository.GetCatalogItems();
    }

    public CatalogItem GetCatalogItem(int sku)
    {
        return catalogItemRepository.GetCatalogItem(sku);
    }
}