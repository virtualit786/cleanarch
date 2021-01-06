using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Threading.Tasks;
using Api;
using Application.TodoLists.Commands;
using Xunit;
using System.Net;
using FluentAssertions;
using Newtonsoft.Json;
using System.Text;
using System;

namespace Todo.Integration.Tests
{
    public class TodoControllerTests
    {
        private TestServer _server;
        protected readonly HttpClient TestClient;

        public TodoControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            TestClient = _server.CreateClient();
        }

        [Fact]
        public async Task GetPublicHealthEndpoint()
        {            
            var apiResponse = await TestClient.GetAsync($"/Todo/{Guid.NewGuid()}");
            apiResponse.EnsureSuccessStatusCode();
            Assert.True(apiResponse.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK, apiResponse.StatusCode);
            apiResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task CreateTodo()
        {
            var response = await TestClient.PostAsync("/Todo"
                , new StringContent(
                    JsonConvert.SerializeObject(
                        new CreateTodoCommand
                        (
                            "task title 1",
                            "Description of title 1",
                            false
                            )
                        ),
                    Encoding.UTF8,
                    "application/json"));

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
