using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLITEDemo
{
    public static class Constants
    {
        //  The File Name we are going to store in device
        private const string DBFileName = "SQLite.db3"; 

        //  An enumeration type to specify what is going to be the behavior of the file
        //  How the Connection of file will be open
        public const SQLiteOpenFlags Flags = 
            SQLiteOpenFlags.ReadWrite | 
            SQLiteOpenFlags.Create | 
            SQLiteOpenFlags.SharedCache;

        //  Configuration of Database file Path
        public static string DatabasePath
        {
            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, DBFileName);
            }
        }
    }
}
