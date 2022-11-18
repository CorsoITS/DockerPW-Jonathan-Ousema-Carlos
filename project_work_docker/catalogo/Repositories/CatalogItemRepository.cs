using catalogo.Context;
using MySql.Data.MySqlClient;
using catalogo.Models;

namespace catalogo.Repositories;

public class CatalogItemRepository
{

    private AppDb appDb = new AppDb();

    public IEnumerable<CatalogItem> GetCatalogItems()
    {
        var result = new List<CatalogItem>();

        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select sku,descrizione,prezzo from catalog";
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var catalog_item = new CatalogItem()
            {
                sku = reader.GetInt16("sku"),
                descrizione = reader.GetString("descrizione"),
                prezzo = reader.GetInt16("prezzo")
            };
            result.Add(catalog_item);
        }
        appDb.Connection.Close();

        return result;
    }

    public CatalogItem GetCatalogItem(int? sku)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select sku,descrizione,prezzo from catalog where sku=@sku";
        var parameter = new MySqlParameter()
        {
            ParameterName = "sku",
            DbType = System.Data.DbType.Int16,
            Value = sku
        };
        command.Parameters.Add(parameter);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
             var catalog_item = new CatalogItem()
            {
                sku = reader.GetInt16("sku"),
                descrizione = reader.GetString("descrizione"),
                prezzo = reader.GetInt16("prezzo")
            };
            appDb.Connection.Close();
            return catalog_item;
        }

        appDb.Connection.Close();
        return null;
    }
}