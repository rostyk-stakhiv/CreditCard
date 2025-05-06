﻿using CreditCardApi.Models;
using System.Collections.Generic;

namespace CreditCardApi.Contracts
{
    public interface ICreditCardService
    {
        CreditCard GetById(int id);
        int getBalance(string cardNumber);
        void Create(CreditCard card);
        void Update(CreditCard card);
        void Delete(int id);
        List<CreditCard> GetAll();

    }
}
