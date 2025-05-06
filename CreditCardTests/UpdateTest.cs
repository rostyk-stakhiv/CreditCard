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
    public class UpdateTest
    {
        [Fact]
        public void UpdateOkResult()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uofw => uofw.GetCreditCardRepository.Update(It.IsAny<CreditCard>()));

            var controller = new CreditCardsController(mockUnitOfWork.Object);

            controller.Create(UpdateData());
            var data = controller.Edit(1, UpdatedData());
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void UpdateBadRequestResult()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uofw => uofw.GetCreditCardRepository.Update(It.IsAny<CreditCard>())).Throws<ArgumentNullException>();

            var controller = new CreditCardsController(mockUnitOfWork.Object);

            var data = controller.Edit(0, null);

            Assert.IsType<BadRequestObjectResult>(data);
        }

        
    private CreditCard UpdateData()
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
    private CreditCard UpdatedData()
        {
            return new CreditCard
            {
                Bank = "alfabank",
                CardNumber = "1111 1111 1111 1111",
                DateOfIssue = new DateTime(2020, 3, 3),
                DateOfExpire = new DateTime(2021, 3, 3),
                CVC = 222,
                OwnerName = "Rostyk Stakhiv",
                Id = 1

            };
        }
    }
    
}
