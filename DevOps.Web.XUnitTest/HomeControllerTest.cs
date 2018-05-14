using DevOps.Web.Controllers;
using System;
using Xunit;

namespace DevOps.Web.XUnitTest
{
    public class HomeControllerTest
    {
        [Fact]
        public void Test1()
        {
            Moq.Mock<HomeController> mock = new Moq.Mock<HomeController>();
        }
    }
}
