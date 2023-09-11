using ContactBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactBook.ViewModels
{
    public class BookViewModel : Observaible_object
    {
        private IContactDataService _dataService;

        private ContactsViewModel _contactsVM;
        public ContactsViewModel ContactsVM
        {
            get { return _contactsVM; }
            set { OnPropertyChanged(ref _contactsVM, value); }
        }

        public ICommand LoadContactsCommand { get; private set; }
        public ICommand LoadFavoritesCommand { get; private set; }

        public BookViewModel(IContactDataService dataService)
        {
            ContactsVM = new ContactsViewModel(dataService);

            _dataService = dataService;

            LoadContactsCommand = new RelayCommand(LoadContacts);
            LoadFavoritesCommand = new RelayCommand(LoadFavorites);
        }

        private void LoadContacts()
        {
            ContactsVM.LoadContacts(_dataService.GetContacts());
        }

        private void LoadFavorites()
        {
            var favorites = _dataService.GetContacts().Where(c => c.IsFavorite);
            ContactsVM.LoadContacts(favorites);
        }
    }
}
