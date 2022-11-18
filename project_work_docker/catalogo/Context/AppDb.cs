using MySql.Data.MySqlClient;

namespace catalogo.Context;

public class AppDb
{

    public MySqlConnection Connection { get; }

    private const string defaultConnectionString = "server=localhost;database=catalogo_docker;uid=root;pwd=password;";

    public AppDb()
    {
        Connection = new MySqlConnection(defaultConnectionString);
    }
    public AppDb(string connectionString)
    {
        Connection = new MySqlConnection(connectionString);
    }



}