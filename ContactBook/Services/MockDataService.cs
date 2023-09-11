using ContactBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Services
{
    public class MockDataService : IContactDataService
    {
        private IEnumerable<Contact> _contacts;

        public MockDataService()
        {
            _contacts = new List<Contact>()
            {
                new Contact
                {
                    Name = "John Doe",
                    PhoneNumbers = new string[]
                    {
                        "555-111-1111"
                    },
                    Emails = new string[]
                    {
                        "Aoba@mail.ru"
                    },
                    Locatons = new string[]
                    {
                        "7 Bimba street"
                    }
                },

                new Contact
                {
                    Name = "John Doe",
                    PhoneNumbers = new string[]
                    {
                        "555-111-1111"
                    },
                    Emails = new string[]
                    {
                        "Aoba@mail.ru"
                    },
                    Locatons = new string[]
                    {
                        "7 Bimba street"
                    }
                },

                new Contact
                {
                    Name = "John Doe",
                    PhoneNumbers = new string[]
                    {
                        "555-111-1111"
                    },
                    Emails = new string[]
                    {
                        "Aoba@mail.ru"
                    },
                    Locatons = new string[]
                    {
                        "7 Bimba street"
                    }
                }
            };
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _contacts;
        }

        public void Save(IEnumerable<Contact> contacts)
        {
            _contacts = contacts;
        }
    }
}
