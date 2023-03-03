using SQLite;
using SQLITEDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLITEDemo.Repositories
{
    public class CustomerRepository
    {
        //  Create Connection for local database
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public CustomerRepository()
        {
            connection =
                new SQLiteConnection(Constants.DatabasePath,
                Constants.Flags);
            connection.CreateTable<Customer>();
        }

        // Insert Data
        public void Add(Customer newCustomer)
        {
            int result = 0;
            try
            {
                result = connection.Insert(newCustomer);    // This is the only required line for insertion
                StatusMessage =
                    $"{result} row(s) added";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        //  Select / Get Data
        public List<Customer> GetAll()
        {
            try
            {
                return connection.Table<Customer>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        // Get Single Record
        public Customer Get(int id)
        {
            try
            {
                return connection.Table<Customer>()
                    .FirstOrDefault(x => x.ID == id);
            }
            catch (Exception)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }
    }
}
