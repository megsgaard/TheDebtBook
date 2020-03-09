using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheDebtBook.Model;

namespace TheDebtBook.ViewModels
{
    public class AddWindowViewModel : BindableBase
    {
        //public DelegateCommand SaveButtonCommand { get; private set; }
        //public Debtor CurrentDebtor { get; private set; }

        public AddWindowViewModel(Debtor debtor)
        {
            //SaveButtonCommand = new DelegateCommand(SaveButtonExecute)
            //    .ObservesProperty(() => CurrentDebtor.Name)
            //    .ObservesProperty(() => CurrentDebtor.Balance);
            CurrentDebtor = debtor;
        }

        private ICommand saveButtonCommand;
        public ICommand SaveButtonCommand
        {
            get
            {
                return saveButtonCommand ?? (saveButtonCommand = new DelegateCommand(
                    SaveButtonExecute)
                  .ObservesProperty(() => CurrentDebtor.Name)
                  .ObservesProperty(() => CurrentDebtor.Balance));
            }
        }
        

        public Debtor CurrentDebtor { get; set; }

        //private Debtor currentDebtor;

        //public Debtor CurrentDebtor
        //{
        //    get { return currentDebtor; }
        //    set
        //    {
        //        SetProperty(ref currentDebtor, value);
        //    }
        //}

        private void SaveButtonExecute()
        {
            // Nothing needs to be done here
        }

        private bool SaveButtonCanExecute()
        {
            return true; // this is only needed if we implement validation
        }
    }
}
