namespace httpClient_5_Ways_ToUse.Services
{
    public class JokeService(HttpClient httpClient)
    {
        public async Task<JokeModel?> GetJokeAsync()
        {
           return await httpClient.GetFromJsonAsync<JokeModel>($"random_joke");
        }

    }
}
