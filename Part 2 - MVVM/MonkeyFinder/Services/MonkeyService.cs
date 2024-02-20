using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public sealed class MonkeyService : IMonkeyService
{
    private List<Monkey> monkeys = new();

    private readonly HttpClient httpClient = new();

    private const string MonkeysUrl = "https://www.montemagno.com/monkeys.json";

    public async Task<IList<Monkey>> GetMonkeysAsync()
    {
        if (monkeys.Count > 0)
        {
            return await Task.FromResult(monkeys);
        }

        monkeys = await httpClient.GetFromJsonAsync(MonkeysUrl, MonkeyContext.Default.ListMonkey);

        return monkeys;
    }
}