using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using TheDebtBook.Data;
using TheDebtBook.Model;
using TheDebtBook.Views;

namespace TheDebtBook.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ObservableCollection<Debtor> Debtors { get; private set; }
        private string fileName = "debtbook.txt";

        public MainWindowViewModel()
        {
            
            FileHandling.ReadFile(fileName, out ObservableCollection<Debtor> tempDebtors);
            if (tempDebtors != null)
            {
                Debtors = tempDebtors;
            }
            else
            {
                Debtors = new ObservableCollection<Debtor>();
            }

            CurrentDebtor = null;

            
        }

        private int currentIndex = -1;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                SetProperty(ref currentIndex, value);
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

        private ICommand addNewDebtor;
        public ICommand AddNewDebtor
        {
            get
            {
                return addNewDebtor ?? (addNewDebtor = new DelegateCommand(() =>
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
                        FileHandling.SaveFile(fileName, Debtors);
                    }
                }));
            }
        }

        private ICommand editTransactions;

        public ICommand EditTransactions
        {
            get
            {
                return editTransactions ?? (editTransactions = new DelegateCommand(() =>
                {
                    var tempDebtor = CurrentDebtor.Clone();
                    var vm = new TransactionsWindowViewModel(tempDebtor);
                    TransactionsWindow transactionsWindow = new TransactionsWindow
                    {
                        DataContext = vm,
                        Owner = App.Current.MainWindow
                    };
                    if (transactionsWindow.ShowDialog() == true)
                    {
                        CurrentDebtor.Transactions = tempDebtor.Transactions;
                        FileHandling.SaveFile(fileName, Debtors);
                    }
                },
                () => {
                    return CurrentIndex >= 0;
                }
                ).ObservesProperty(() => CurrentIndex));
            }
        }

    }
}
