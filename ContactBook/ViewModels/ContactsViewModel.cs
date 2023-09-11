using ContactBook.Models;
using ContactBook.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactBook.ViewModels
{
    public class ContactsViewModel : Observaible_object
    {
        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get => _selectedContact;
            set => OnPropertyChanged(ref _selectedContact, value); 
        }

        private bool _isEditMode;
        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                OnPropertyChanged(ref _isEditMode, value);
                OnPropertyChanged("IsDisplayMode");
            }
        }

        public bool IsDisplayMode
        {
            get => !_isEditMode;
        }

        private IEnumerable<Contact> _contacts;
        public ObservableCollection<Contact> Contacts { get; private set; }

        public ICommand EditCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }

        private IContactDataService _dataService;

        public ContactsViewModel(IContactDataService dataService)
        {
            _dataService = dataService;
            _contacts = dataService.GetContacts();

            EditCommand = new RelayCommand(Edit, CanEdit);
            SaveCommand = new RelayCommand(Save, IsEdit);
            UpdateCommand = new RelayCommand(Update);
        }

        public ContactsViewModel()
        {

        }

        private void Update() => _dataService.Save(_contacts);

        private void Save()
        {
            _dataService.Save(_contacts);
            IsEditMode = false;
            OnPropertyChanged("SelectedContact");
        }

        private bool IsEdit() => IsEditMode;

        private bool CanEdit()
        {
            if (SelectedContact == null)
                return false;

            return !IsEditMode;
        }

        private void Edit() => IsEditMode = true;

        public void LoadContacts(IEnumerable<Contact> contacts)
        {
            Contacts = new ObservableCollection<Contact>(contacts);
            OnPropertyChanged("Contacts");
        }
    }
}
