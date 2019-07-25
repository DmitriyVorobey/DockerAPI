using System;
using System.Net.Http;
using Xunit;

namespace DockerAPI.Tests
{
    public class UnitTest1
    {
        private const string Address = "https://localhost:5001";
        private const string Route = "item";



        [Fact]
        public async void Test1()
        {
            var client = new HttpClient { BaseAddress = new Uri(Address) };

            Console.WriteLine(client.BaseAddress);

            var response = await client.GetAsync(Route);
            var result = response.Content.ReadAsStringAsync().Result;

            Assert.Equal(result, $"item");
        }
    }
}
