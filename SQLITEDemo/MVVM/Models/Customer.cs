using SQLite;
using SQLITEDemo.Abstraction;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLITEDemo.MVVM.Models
{
    [Table("Customers")]
    public class Customer : TableData
    {

        [Column("name"), Indexed, NotNull]
        public string Name { get; set; }

        [Unique]
        public string Phone { get; set; }

        public int Age { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Ignore]
        public bool IsYoung =>
            Age > 50 ? true : false;

        [ForeignKey(typeof(Passport))]
        public int PassportId { get; set; }

        [OneToOne]
        public Passport Passport { get; set; }
    }
}
