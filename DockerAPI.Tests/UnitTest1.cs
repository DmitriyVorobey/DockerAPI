using System;
using System.Net.Http;
using Xunit;

namespace DockerAPI.Tests
{
    public class UnitTest1
    {
        private const string Address = "http://localhost:8080";
        private const string Route = "item";



    [Fact]
        public async void Test1()
        {
            var client = new HttpClient {BaseAddress = new Uri(Address+Route)};

            Console.WriteLine(client.BaseAddress);

            var response = await client.GetAsync("");
            var result = response.Content.ReadAsStringAsync().Result;

            Assert.Equal(result, $"item");




        }
    }
}
