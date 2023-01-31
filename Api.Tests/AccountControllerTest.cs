using Api.Controllers;
using MediatR;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Api.Tests;

public class AccountControllerTest
{
    [Fact]
    public async Task DeleteAccount_ShouldReturnBadRequest()
    {
        // Arrange
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7101/");

        // Act
        var response = await client.DeleteAsync($"api/account/{Guid.NewGuid()}");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}