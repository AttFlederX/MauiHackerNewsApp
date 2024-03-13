namespace HackerNewsApp.Services;

public class ApiService
{
    private const string BaseUrl = "https://hacker-news.firebaseio.com/v0";
    private readonly HttpClient _client = new();

    public async Task<List<int>> GetFeedStoryIds()
    {
        var response = _client.GetAsync($"{BaseUrl}/beststories.json");
        var list = await response.Result.Content.ReadAsStringAsync();

        return list
            .Trim(['[', ']'])
            .Split(',')
            .Select(int.Parse)
            .ToList();
    }
}