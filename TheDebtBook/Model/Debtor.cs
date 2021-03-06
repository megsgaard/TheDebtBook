﻿using System.Collections.Generic;
using Prism.Mvvm;


namespace TheDebtBook.Model
{
    public class Debtor : BindableBase
    {
        private string name;
        private double balance;
        private List<Transaction> transactions;

        public string Name {
            get 
            {
                return name;
            }
            set 
            {
                SetProperty(ref name, value);
            } 
        }

        public double Balance
        {
            get
            {
                return balance;
            }
            set
            {
                SetProperty(ref balance, value);
            }
        }

        public List<Transaction> Transactions
        {
            get
            {
                return transactions;
            }
            set
            {
                SetProperty(ref transactions, value);
            }
        }


        public Debtor()
        {
            transactions = new List<Transaction>();
        }

        public Debtor Clone()
        {
            return this.MemberwiseClone() as Debtor;
        }
    }
}
