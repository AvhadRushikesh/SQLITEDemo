using SQLITEDemo.Abstraction;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLITEDemo.MVVM.Models
{
    public class Passport : TableData
    {
        public DateTime ExpirationDate { get; set; }

        [ForeignKey(typeof(Customer))]
        public int CustomerId { get; set; }
    }
}