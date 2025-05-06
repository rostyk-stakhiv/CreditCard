using CreditCardApi.Contracts;
using CreditCardApi.Controllers;
using CreditCardApi.DataProcessing;
using CreditCardApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;

using Xunit;

namespace CreditCardTests
{
    public class GetByIdTest
    {
        [Fact]
        public void GetByIdOkTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uofw => uofw.GetCreditCardRepository.GetById(It.IsAny<int>())).Returns(GetData);
            var controller = new CreditCardsController(mockUnitOfWork.Object);

            var data = controller.GetById(1);

            var result = Assert.IsType<OkObjectResult>(data);
            var model = Assert.IsAssignableFrom<CreditCard>(
                result.Value);
            Assert.NotNull(model);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public void GetById_ReturnsNotFoundResult()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uofw => uofw.GetCreditCardRepository.GetById(It.IsAny<int>())).Returns((CreditCard)null);

            var controller = new CreditCardsController(mockUnitOfWork.Object);

            var data = controller.GetById(1);

            Assert.IsType<NotFoundObjectResult>(data);
        }
        private CreditCard GetData()
        {
            return new CreditCard
            {
                Bank = "monobank",
                CardNumber = "1111 1111 1111 1111",
                DateOfIssue = new DateTime(2020, 3, 3),
                DateOfExpire = new DateTime(2021, 3, 3),
                CVC = 111,
                OwnerName = "Rostyk Stakhiv",
                Id = 1

            };
        }
    }
}