namespace MonarchsChallenge;

internal interface IHttpClient
{
    public Task<HttpResponseMessage> GetAsync(string url);
}

public class CustomClient : IHttpClient
{
    private static readonly HttpClient _httpClient = new HttpClient();

    // Cauisng issue while injecting mock data, because this method is non-overidable member, so to make it work. virtual keyword is used to modify/override a method.
    public virtual Task<HttpResponseMessage> GetAsync(string url) => _httpClient.GetAsync(url);
}