using FluentAssertions;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using TaskApp.Controllers;
using TaskApp.Data;
using TaskApp.Models.DTO;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace TaskApp.Tests.Controller
{
    public class MyTaskControllerTests
    {
        private readonly MyTaskStore _myTaskStore;

        public MyTaskControllerTests()
        {
            _myTaskStore= A.Fake<MyTaskStore>();
        }
        [Fact]
        public void MyTaskController_GetAllTasks_ReturnOK()
        {
            // Arrange
            var Tasks = A.Fake<List<MyTaskDTO>>();

            var controller = new MyTaskController();
                      // Act
            var result= controller.GetAllTasks();
            // Assert
            result.Should().NotBeNull();
            

        }
        
    }
}
