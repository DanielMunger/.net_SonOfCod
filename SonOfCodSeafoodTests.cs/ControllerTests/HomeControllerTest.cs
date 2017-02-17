using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SonOfCodSeafood.Models;
using SonOfCodSeafood.Controllers;
using Xunit;
namespace SonOfCodSeafoodTests.cs.ControllerTests
{
    public class HomeControllerTest
    {

        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            HomeController controller = new HomeController();

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }
    }
}
