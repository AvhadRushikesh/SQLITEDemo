using Bogus;
using SQLITEDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;

namespace SQLITEDemo.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel
    {
        public List<Customer> Customers { get; set; }

        public Customer CurrentCustomer { get; set; }

        // Create Command to Save Customer in local database
        public ICommand AddOrUpdateCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public MainPageViewModel()
        {
            var orders = App.OrdersRepo.GetItems();
            Refresh();
            GenerateNewCustomer();

            AddOrUpdateCommand = new Command(async () =>
            {
                App.CustomerRepo.SaveItem(CurrentCustomer);
                Console.WriteLine(App.CustomerRepo.StatusMessage);
                GenerateNewCustomer();
                Refresh();
            });

            DeleteCommand = new Command(() =>
            {
                App.CustomerRepo.DeleteItem(CurrentCustomer);
                Refresh();
            });
        }

        //  Get Fake Data in Entry Text using Bogus namespace - Adding New Customer
        private void GenerateNewCustomer()
        {
            CurrentCustomer = new Faker<Customer>()
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.Address, f => f.Person.Address.Street)
                .Generate();

            CurrentCustomer.Passport = new Passport
            {
                ExpirationDate = DateTime.Now.AddDays(30)
            };
        }

        private void Refresh()
        {
            Customers = App.CustomerRepo.GetItems();
            //Customers = App.CustomerRepo.get(x => x.Name.StartsWith("A"));
        }
    }
}
