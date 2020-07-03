using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Controllers;
using Api.DataFiles;
using Microsoft.AspNetCore.Mvc;
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
            const string testId = "OCCAECAT";

            var result = await _controller.GetFund(testId);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetFund_WhenCalled_ReturnsFundDetails()
        {
            const string testId = "OCCAECAT";
            var result = await _controller.GetFund(testId);
            var okResult = result as OkObjectResult;

            Assert.IsType<FundDetails>(okResult?.Value);
        }

        [Fact]
        public async Task GetFund_WhenCalled_ReturnsCorrectResult()
        {
            const string testId = "OCCAECAT";
            var result = await _controller.GetFund(testId);
            var okResult = result as OkObjectResult;

            var item = Assert.IsType<FundDetails>(okResult?.Value);
            Assert.Equal("Pivitol 9034", item.Name);
        }

        #endregion
    }
}
