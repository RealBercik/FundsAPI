using Api.Controllers;
using Api.DataFiles;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ApiTest
{
    public class FundsControllerTest
    {
        private readonly FundsController _controller;

        public FundsControllerTest()
        {
            _controller = new FundsController();
        }

        #region GetFunds

        [Fact]
        public async Task GetFunds_WhenCalled_ReturnsOkResult()
        {
            var result = await _controller.GetFunds();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetFunds_WhenCalled_ReturnsListOfFundDetails()
        {
            var result = await _controller.GetFunds();
            var okResult = result as OkObjectResult;

            Assert.IsType<List<FundDetails>>(okResult?.Value);
        }

        [Fact]
        public async Task GetFunds_WhenCalled_ReturnsAllItems()
        {
            var result = await _controller.GetFunds();
            var okResult = result as OkObjectResult;

            var items = Assert.IsType<List<FundDetails>>(okResult?.Value);
            Assert.Equal(15, items.Count);
        }

        #endregion

        #region GetFund

        [Fact]
        public async Task GetFund_WhenCalled_ReturnsOkResult()
        {
            const string testCode = "OCCAECAT";

            var result = await _controller.GetFund(testCode);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetFund_WhenCalled_ReturnsFundDetails()
        {
            const string testCode = "OCCAECAT";
            var result = await _controller.GetFund(testCode);
            var okResult = result as OkObjectResult;

            Assert.IsType<FundDetails>(okResult?.Value);
        }

        [Fact]
        public async Task GetFund_WhenCalled_ReturnsCorrectResult()
        {
            const string testCode = "OCCAECAT";
            var result = await _controller.GetFund(testCode);
            var okResult = result as OkObjectResult;

            var item = Assert.IsType<FundDetails>(okResult?.Value);
            Assert.Equal("Pivitol 9034", item.Name);
        }

        #endregion

        #region GetManagerFunds

        [Fact]
        public async Task GetManagerFunds_WhenCalled_ReturnsOkResult()
        {
            const string managerCode = "Medcom";
            var result = await _controller.GetManagerFunds(managerCode);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetManagerFunds_WhenCalled_ReturnsListOfFundDetails()
        {
            const string managerCode = "Medcom";
            var result = await _controller.GetManagerFunds(managerCode);
            var okResult = result as OkObjectResult;

            Assert.IsType<List<FundDetails>>(okResult?.Value);
        }

        [Fact]
        public async Task GetManagerFunds_WhenCalled_ReturnsCorrectResult()
        {
            const string managerCode = "Medcom";
            var result = await _controller.GetManagerFunds(managerCode);
            var okResult = result as OkObjectResult;

            var items = Assert.IsType<List<FundDetails>>(okResult?.Value);
            Assert.NotEmpty(items.Where(x => x.Name == "Corecom 9122"));
        }

        #endregion
    }
}
