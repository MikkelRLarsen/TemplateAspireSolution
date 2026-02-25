using Aspire.Hosting;
using Aspire.Integrationtest;
using Dapr.Client;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace Aspire.IntegrationTest.Tests;

[Collection("AspireApp")]
public class DefaultAspireTest
{

    private readonly AspireAppFixture _fixture;

    public DefaultAspireTest(AspireAppFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetWebResourceRootReturnsOkStatusCode()
    {
        // Arrange
        HttpClient sut = _fixture.TemplateApi;

        // Act
        var response = await sut.GetAsync("/weatherforecast", _fixture.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }


    ///// <summary>
    ///// Needs testing still. 
    ///// </summary>
    ///// <param name="app"></param>
    ///// <param name="serviceName"></param>
    ///// <returns></returns>
    //public async Task<DaprClient> GetDaprClient(this DistributedApplication app, string serviceName)
    //{
    //    var endpoint = app.GetEndpoint($"{serviceName}-dapr-http");

    //    return new DaprClientBuilder()
    //        .UseHttpEndpoint(endpoint.ToString())
    //        .Build();
    //}
}
