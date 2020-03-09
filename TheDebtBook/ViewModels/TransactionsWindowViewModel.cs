using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDebtBook.Model;

namespace TheDebtBook.ViewModels
{
    public class TransactionsWindowViewModel : BindableBase
    {
        public TransactionsWindowViewModel(Debtor debtor)
        {
            CurrentDebtor = debtor;
        }
        public Debtor CurrentDebtor { get; set; }

    }
}
