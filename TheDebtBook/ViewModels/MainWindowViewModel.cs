using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TheDebtBook.Model;
using TheDebtBook.Views;

namespace TheDebtBook.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        //private ObservableCollection<Debtor> debtors;
        public ObservableCollection<Debtor> Debtors { get; private set; }

        public MainWindowViewModel()
        {
            Debtors = new ObservableCollection<Debtor>();
        }

        //public ObservableCollection<Debtor> Debtors
        //{
        //    get { return debtors; }
        //    set { SetProperty(ref debtors, value); }
        //}

        private Debtor currentDebtor;

        public Debtor CurrentDebtor
        {
            get { return currentDebtor; }
            set
            {
                SetProperty(ref currentDebtor, value);
            }
        }

        private ICommand _newCommand;
        public ICommand AddNewDebtor
        {
            get
            {
                return _newCommand ?? (_newCommand = new DelegateCommand(() =>
                {
                    var newDebtor = new Debtor();
                    var vm = new AddWindowViewModel(newDebtor);
                    AddWindow addWindow = new AddWindow
                    {
                        DataContext = vm
                    };
                    if (addWindow.ShowDialog() == true)
                    {
                        Debtors.Add(newDebtor);
                        CurrentDebtor = newDebtor;
                    }
                }));
            }
        }
    }
}
