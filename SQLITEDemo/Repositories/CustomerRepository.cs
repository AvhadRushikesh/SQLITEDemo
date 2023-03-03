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
        public void AddOrUpdate(Customer Customer)
        {
            int result = 0;
            try
            {
                if (Customer.ID != 0)
                {
                    result = connection.Update(Customer);   //  Update Record
                    StatusMessage = $"{result} Row(s) Updated";
                }
                else
                {
                    result = connection.Insert(Customer);    // Insert Record
                    StatusMessage =
                        $"{result} row(s) added";
                }
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

        //  Get Single Record
        public Customer Get(int id)
        {
            try
            {
                return connection.Table<Customer>()
                    .FirstOrDefault(x => x.ID == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        //  Executing SQL queries for Select Record
        public List<Customer> GetAll2()
        {
            try
            {
                return connection.Query<Customer>("SELECT * FROM Customers").ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        //  Delete Record / Customer
        public void Delete(int customerId)
        {
            try
            {
                var customer = Get(customerId);
                connection.Delete(customer);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
    }
}
