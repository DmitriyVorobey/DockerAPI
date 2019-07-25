using System;
using System.Net.Http;
using Xunit;

namespace DockerAPI.Tests
{
    public class UnitTest1
    {
        private const string Address = "localhost";
        private const string Port = ":5001";

        [Fact]
        public async void Test1()
        {
            var client = new HttpClient {BaseAddress = new Uri("http://" + Address + Port)};

            var response = await client.GetAsync("/item");
            var result = response.Content.ReadAsStringAsync().Result;

            Assert.Equal(result, $"item");




        }
    }
}
