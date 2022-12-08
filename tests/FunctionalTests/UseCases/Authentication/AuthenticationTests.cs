using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using SocialCommerce.Contracts.Authentication;

namespace SocialCommerce.FunctionalTests.UseCases.Authentication;

[TestFixture]
public class AuthenticationTests
{
    private readonly TestApp<Program> TestApp;

    public AuthenticationTests()
    {
        TestApp = new TestApp<Program>();
    }

    [Test]
    public async Task Login()
    {
        // Arrange
        var client = TestApp.CreateClient();
        var requestObj = new LoginRequest("username", "password");
        var resquestContent = new StringContent(JsonSerializer.Serialize(requestObj), Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("auth/login", resquestContent);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var responseObj = JsonSerializer.Deserialize<LoginRequest>(content);

        // Assert
        Assert.AreEqual(requestObj.Username, responseObj?.Username);
        Assert.AreEqual(requestObj.Password, responseObj?.Password);
    }

    [Test]
    public async Task Register()
    {
        // Arrange
        var client = TestApp.CreateClient();
        var requestObj = new RegisterRequest("username", "password");
        var resquestContent = new StringContent(JsonSerializer.Serialize(requestObj), Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("auth/register", resquestContent);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var responseObj = JsonSerializer.Deserialize<RegisterRequest>(content);

        // Assert
        Assert.AreEqual(requestObj.Username, responseObj?.Username);
        Assert.AreEqual(requestObj.Password, responseObj?.Password);
    }
}