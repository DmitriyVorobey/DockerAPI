using System;
using System.Net.Http;
using System.Text;
using DockerAPI.Models;
using DockerAPI.Tests.Utils;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace DockerAPI.Tests
{
    public class UnitTest1
    {
        private const string Address = "https://localhost:5001";

        [Fact]
        public async void WhenItemIsSaved_ThenItemExists()
        {
            // Arrange
            var client = new HttpClient { BaseAddress = new Uri(Address) };

            var requestBody = new Item
            {
                Value = StringGenerator.RandomString(5)
            };

            // Act
            var response = await client.PostAsync("item", new StringContent(JsonConvert.SerializeObject(requestBody), 
                                                                Encoding.UTF8, "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();

            var getItem = await client.GetAsync("item");
            var content = getItem.Content.ReadAsStringAsync().Result;
            var actualResult = JsonConvert.DeserializeObject<Item>(content);

            actualResult.Should().BeEquivalentTo(requestBody);
        }
    }
}
