using CreditCardApi.Contracts;
using CreditCardApi.Controllers;
using CreditCardApi.DataProcessing;
using CreditCardApi.Models;
using CreditCardApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;

using Xunit;

namespace CreditCardTests
{
    public class CreateTest
    {
        [Fact]
        public void CreateOkResult()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uofw => uofw.GetCreditCardRepository.Insert(It.IsAny<CreditCard>()));
            var service = new CreditCardService(mockUnitOfWork.Object);

            var data = service.Create(CreateData());

            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void ICreateBadRequestResult()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uofw => uofw.GetCreditCardRepository.Insert(It.IsAny<CreditCard>()));
            var controller = new CreditCardsController(mockUnitOfWork.Object);

            var data = controller.Create(InvalidData());

            Assert.IsType<BadRequestObjectResult>(data);
        }

       
        private CreditCard CreateData()
        {
            return new CreditCard
            {
                Bank="monobank",
                CardNumber="1111 1111 1111 1111",
                DateOfIssue=new DateTime(2020,3,3),
                DateOfExpire=new DateTime(2021,3,3),
                CVC=111,
                OwnerName="Rostyk Stakhiv",
                Id=1
                
            };
        }
        private CreditCard InvalidData()
        {
            return new CreditCard
            {
                Bank = "monbank",
                CardNumber = "111 1111 1111 1111",
                DateOfIssue = new DateTime(2022, 3, 3),
                DateOfExpire = new DateTime(2021, 3, 3),
                CVC = 1111,
                OwnerName = "Rosty@ Stakhiv",
                Id = 5

            };
        }
    }
}
