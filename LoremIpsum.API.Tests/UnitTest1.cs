using System.Collections.Generic;
using System.Linq;
using LoremIpsumService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Xunit;

namespace LoremIpsum.API.Tests
{
    public class UnitTest1
    {
        private LoremIpsumController controller;
        private LoremIpsumServiceFake service;

        public UnitTest1()
        {
            service = new LoremIpsumServiceFake();
            controller = new LoremIpsumController(service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = controller.Get("Dynamic", 1, 1);
 
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsDynamicText()
        {
            // Act
            var okResult = controller.Get("Dynamic", 1, 1).Result as OkObjectResult;
 
            // Assert
            var items = Assert.IsAssignableFrom<IEnumerable<string>>(JsonConvert.DeserializeObject<IEnumerable<string>>(okResult.Value.ToString()));
            Assert.Equal("Dynamic", items.ElementAt(0));
        }

        [Fact]
        public void Get_WhenCalled_ReturnsStaticText()
        {
            // Act
            var okResult = controller.Get("Dynamic", 1, 1).Result as OkObjectResult;
 
            // Assert
            var items = Assert.IsAssignableFrom<IEnumerable<string>>(JsonConvert.DeserializeObject<IEnumerable<string>>(okResult.Value.ToString()));
            Assert.Equal("Dynamic", items.ElementAt(0));
        }
    }
}
