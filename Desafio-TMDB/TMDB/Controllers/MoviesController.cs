using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using TMDB.Models;

namespace TMDB.Controllers;

public class MoviesController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public MoviesController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClient = httpClientFactory.CreateClient();
        _configuration = configuration;
    }

    public async Task<IActionResult> Index()
    {
        var apiKey = _configuration["TMDB:ApiKey"];
        var request = new HttpRequestMessage(HttpMethod.Get, 
            "https://api.themoviedb.org/3/movie/popular?language=pt-BR&page=1");
        
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var movieResponse = JsonSerializer.Deserialize<MovieResponse>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return View(movieResponse?.Results ?? new List<Movie>());
    }
}
