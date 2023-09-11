using ContactBook.Services;
using ContactBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
    public class AppViewModel : Observaible_object
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set => OnPropertyChanged(ref _currentView, value);
        }

        private BookViewModel _bookVM;
        public BookViewModel BookVM
        {
            get => _bookVM;
            set => OnPropertyChanged(ref _bookVM, value);
        }

        public AppViewModel()
        {
            var dataServices = new MockDataService();

            BookVM = new BookViewModel(dataServices);
            CurrentView = BookVM;
        }
    }
}
