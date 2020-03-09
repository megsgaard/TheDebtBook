using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;
using TheDebtBook.Model;

namespace TheDebtBook.ViewModels
{
    public class AddWindowViewModel : BindableBase
    {

        public AddWindowViewModel(Debtor debtor)
        {
            CurrentDebtor = debtor;
        }

        private ICommand saveButtonCommand;
        public ICommand SaveButtonCommand
        {
            get
            {
                return saveButtonCommand ?? (saveButtonCommand = new DelegateCommand(SaveButtonExecute)
                  .ObservesProperty(() => CurrentDebtor.Name)
                  .ObservesProperty(() => CurrentDebtor.Balance));
            }
        }

        private Debtor currentDebtor;

        public Debtor CurrentDebtor
        {
            get { return currentDebtor; }
            set
            {
                SetProperty(ref currentDebtor, value);
            }
        }

        private void SaveButtonExecute()
        {

            CurrentDebtor.Transactions.Add(new Transaction
            {
                Amount = CurrentDebtor.Balance,
                Timestamp = DateTime.Now
            });
        }

        private bool SaveButtonCanExecute()
        {
            return true; // this is only needed if we implement validation
        }
    }
}
