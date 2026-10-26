using Npgsql;

interface IConnection
{
    void Connection();
    string URLId(string urlID);

    string FetchData(string data);
}


namespace Program.SQLCode
{

    public class PGConnector : IConnection
    {
        public async void Connection()
        {
            string url = URLId("Host=localhost;Port=5432;Username=postgres;Password=TheCoolDev;Database=Person");

            await using var connection = new NpgsqlConnection(url);
            await connection.OpenAsync();

            await using var commandInit = new NpgsqlCommand("SELECT name FROM Person");

            await using var readKey = await commandInit.ExecuteReaderAsync();

            while (await readKey.ReadAsync())
            {

                var Id = readKey.GetInt32(0);
                Console.WriteLine(FetchData("Id") + Id);

            }

            await using var command = new NpgsqlCommand("INSERT INTO Persons (name) VALUES (@name)", connection: connection);

        }

        public string FetchData(string data)
        {
            return data.ToLower();
        }

        public string URLId(string urlID)
        {
            return urlID.ToLower();
        }
    }

}