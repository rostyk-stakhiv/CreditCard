﻿using CreditCardApi.Helpers;

namespace CreditCardApi.Models
{
    public class BaseClass
    {
        private int id;

        public int Id
        {
            set
            {
                if (value.ToString().isNatural())
                {
                    id = value;
                }
                else
                {
                    id = 0;
                }
            }
            get => id;

        }
    }
}