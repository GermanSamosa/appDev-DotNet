using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Day05TodosEF
{
    public class Todo
    {
        //[Key] because it is an Id it knows it is PK
        public int Id { get; set; } //for database of course

        [Required] //not null
        [StringLength(100)] //nvarchar(100)
        public string Task { get; set; } // 1-100 characters, only letters, digits, space ./,;-+)(*! allowed
        public int Difficulty { get; set; } // 1-5 only front-end validation
        public DateTime DueDate { get; set; } //1900-2099 year required, format in GUI is whatever the OS is configured to use

        [EnumDataType(typeof(StatusEnum))]
        public StatusEnum Status { get; set; }
        public enum StatusEnum 
        {
            Pending, Done, Delegated
        };

        public static bool IsTaskValid(string task, out string error)
        {
            if(task.Length < 1 || task.Length > 100) //still must validate task to only letters, digits, space
            {
                error = "Task Input must be between 1 and 100 characters.";
                return false;
            }
            else
            {
                error = null;
                return true;
            }
        }
        public static bool IsDatePickerValid(DateTime dueDate, out string error)
        {
            int year = dueDate.Year;
        
            if(year < 1900 || year > 2099)
            {
                error = "Year must be between 1900 and 2099.";
                return false;
            }
            else
            {
                error = null;
                return true;
            }
            
        }
    }
}
