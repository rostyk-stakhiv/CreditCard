using CreditCardApi.Contracts;
using CreditCardApi.Controllers;
using CreditCardApi.DataProcessing;
using CreditCardApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CreditCardTests
{
    public class GetTest
    {
        [Fact]
        public void TestPagination()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uofw => uofw.GetCreditCardRepository.Find(It.IsAny<string>())).Returns(CreditCards);
            mockUnitOfWork.Setup(uofw => uofw.GetCreditCardRepository.Sort(It.IsAny<List<CreditCard>>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Sorted);
            mockUnitOfWork.Setup(uofw => uofw.GetCreditCardRepository.Paginate(It.IsAny<List<CreditCard>>(), It.IsAny<int>(), It.IsAny<int>())).Returns(CreditCards);

            var controller = new CreditCardsController(mockUnitOfWork.Object);

            var data = controller.Get(s:"1",sort_by:"bank",sort_type:"asc",offset:1,limit:2);

           Assert.IsType<OkObjectResult>(data);

        }
        [Fact]
        public void TestNotFoundResult()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uofw => uofw.GetCreditCardRepository.Paginate(It.IsAny<List<CreditCard>>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<CreditCard>());

            var controller = new CreditCardsController(mockUnitOfWork.Object);

            var data = controller.Get();

            Assert.IsType<NotFoundObjectResult>(data);
        }



        private IEnumerable<CreditCard> CreditCards()
        {
            return new List<CreditCard>
            {
                
            new CreditCard
            {
                Bank = "monobank",
                CardNumber = "1112 1111 1111 1111",
                DateOfIssue = new DateTime(2020, 3, 3),
                DateOfExpire = new DateTime(2021, 3, 3),
                CVC = 111,
                OwnerName = "Rostyk Stakhiv",
                Id = 2

            },
            new CreditCard
            {
                Bank = "alfabank",
                CardNumber = "1111 1111 1111 1111",
                DateOfIssue = new DateTime(2020, 3, 3),
                DateOfExpire = new DateTime(2021, 3, 3),
                CVC = 111,
                OwnerName = "Rostyk Stakhiv",
                Id = 1

            },
           new CreditCard
            {
                Bank = "monobank",
                CardNumber = "1113 1111 1111 1111",
                DateOfIssue = new DateTime(2020, 3, 3),
                DateOfExpire = new DateTime(2021, 3, 3),
                CVC = 111,
                OwnerName = "Rostyk Stakhiv",
                Id = 3

            }
            };
        }

        private IEnumerable<CreditCard> Sorted()
        {
            return new List<CreditCard>
            {
                new CreditCard
            {
                Bank = "alfabank",
                CardNumber = "1111 1111 1111 1111",
                DateOfIssue = new DateTime(2020, 3, 3),
                DateOfExpire = new DateTime(2021, 3, 3),
                CVC = 111,
                OwnerName = "Rostyk Stakhiv",
                Id = 1

            },
            new CreditCard
            {
                Bank = "monobank",
                CardNumber = "1112 1111 1111 1111",
                DateOfIssue = new DateTime(2020, 3, 3),
                DateOfExpire = new DateTime(2021, 3, 3),
                CVC = 111,
                OwnerName = "Rostyk Stakhiv",
                Id = 2

            },
           new CreditCard
            {
                Bank = "monobank",
                CardNumber = "1113 1111 1111 1111",
                DateOfIssue = new DateTime(2020, 3, 3),
                DateOfExpire = new DateTime(2021, 3, 3),
                CVC = 111,
                OwnerName = "Rostyk Stakhiv",
                Id = 3

            }
            };
        }

        private IEnumerable<CreditCard> Paginated()
        { 
            return new List<CreditCard>
            {
                
           new CreditCard
           {
               Bank = "monobank",
               CardNumber = "1113 1111 1111 1111",
               DateOfIssue = new DateTime(2020, 3, 3),
               DateOfExpire = new DateTime(2021, 3, 3),
               CVC = 111,
               OwnerName = "Rostyk Stakhiv",
               Id = 3

           }
            };
        }
    }
}