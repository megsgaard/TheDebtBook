using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDebtBook.Model
{
    public class Transaction : BindableBase
    {
        private double amount;
        private DateTime timestamp;

        public double Amount
        {
            get
            {
                return amount;
            }
            set
            {
                SetProperty(ref amount, value);
            }
        }

        public DateTime Timestamp
        {
            get
            {
                return timestamp;
            }
            set
            {
                SetProperty(ref timestamp, value);
            }
        }

        public Transaction()
        {
        }
    }
}
