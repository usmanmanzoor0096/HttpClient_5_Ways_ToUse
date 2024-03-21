using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace httpClient_5_Ways_ToUse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpClientController(IHttpClientFactory _httpClientFactory) : ControllerBase
    {
        [HttpGet("{country}")]
        public async Task<IActionResult> GetUniversities([FromRoute] string country)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://universities.hipolabs.com/");
            var response = await httpClient.GetAsync($"http://universities.hipolabs.com/search?country={country}");
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                return Ok(res);
            }
            return BadRequest(); 
        }

        [HttpGet("v2/{country}")]
        public async Task<IActionResult> GetUniversities2([FromRoute] string country)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var httpRequestMessag = new HttpRequestMessage(HttpMethod.Get, $"http://universities.hipolabs.com/search?country={country}");

            var response = await httpClient.SendAsync(httpRequestMessag);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                return Ok(res);
            }
            return BadRequest(); 
        }

        [HttpGet("v3/{country}")]
        public async Task<IActionResult> GetUniversities3([FromRoute] string country)
        {
            var httpClient = _httpClientFactory.CreateClient("universities");

            var response = await httpClient.GetAsync($"search?country={country}");
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                return Ok(res);
            }
            return BadRequest(); 
        }
        [HttpGet("jokes")]
        public async Task<IActionResult> GetJokes()
        {
            var httpClient = _httpClientFactory.CreateClient("jokes");
            
            // One way 
            //var response = await httpClient.GetAsync($"random_joke");
            //if (response.IsSuccessStatusCode)
            //{
            //    var res = await response.Content.ReadFromJsonAsync<JokeModel>();
            //    return Ok(res);
            //}
            //  return BadRequest(); 


            // another way 
            var response = await httpClient.GetFromJsonAsync<JokeModel>($"random_joke");
            return Ok(response);
           
        } 


    }
}
