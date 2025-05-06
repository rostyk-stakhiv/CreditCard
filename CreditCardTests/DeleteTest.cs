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
    public class DeleteTest
    {
        [Fact]
        public void Delete_ReturnsBadRequestResult()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uofw => uofw.GetCreditCardRepository.Delete(It.IsAny<int>())).Throws<ArgumentNullException>();

            var controller = new CreditCardsController(mockUnitOfWork.Object);


            var data = controller.Delete(100);

            Assert.IsType<NotFoundObjectResult>(data);
        }
        [Fact]
        public void DeleteOkResult()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uofw => uofw.GetCreditCardRepository.Delete(It.IsAny<int>()));

            var controller = new CreditCardsController(mockUnitOfWork.Object);

            var data = controller.Delete(1);

            Assert.IsType<OkObjectResult>(data);
        }

        

       
    }
}