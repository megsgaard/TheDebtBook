using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TheDebtBook.Model;

namespace TheDebtBook.ViewModels
{
    public class TransactionsWindowViewModel : BindableBase
    {
        public Debtor CurrentDebtor { get; set; }
        public ObservableCollection<Transaction> Transactions { get; private set; }
        public int Amount { get; set; }


        public TransactionsWindowViewModel(Debtor debtor)
        {
            Transactions = new ObservableCollection<Transaction>(debtor.Transactions);            
            CurrentDebtor = debtor;
        }

        private ICommand addValueCommand;
        public ICommand AddValueCommand
        {
            get
            {
                return addValueCommand ?? (addValueCommand = new DelegateCommand(AddValueExecute));
            }
        }

        private void AddValueExecute()
        {
            var transaction = new Transaction
            {
                Amount = Amount,
                Timestamp = DateTime.Now
            };

            Transactions.Add(transaction);
            CurrentDebtor.Transactions.Add(transaction);
        }
    }
}
