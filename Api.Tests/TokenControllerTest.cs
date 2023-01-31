using HapChats.Domain.Persistence.Dtos;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Api.Tests;

public class TokenControllerTest
{
    private HttpClient _client;

    public TokenControllerTest() {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://localhost:7101/");
    }

    [Theory]
    [InlineData("admin", "admin")]
    [InlineData("Lewan24", "test1234")]
    public async Task HttpPost_ShouldReturnTokenAsString(string username, string password)
    {
        // Arrange

        // Act
        var user = new UserDto()
        {
            Username = username,
            Password = password
        };
        var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("api/Token", content);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(response);
        Assert.NotEmpty(response.Content.ToString());
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData(null, "admin")]
    [InlineData("admin", null)]
    [InlineData("", "")]
    [InlineData("", null)]
    [InlineData(null, "")]
    public async Task HttpPost_ShouldReturnInvalidTokenString(string username, string password)
    {
        // Arrange

        // Act
        var user = new UserDto()
        {
            Username = username,
            Password = password
        };
        var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("api/Token", content);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
