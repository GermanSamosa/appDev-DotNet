using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05FirstEF_WPF
{
    public class Person
    {
        //[key]
        public int Id { get; set; }

        [Required] // means not null
        [StringLength(50)] //nvarchar(50)

        public string Name { get; set; }

        [Required]
        [Index] //not unique means faster operation

        public int Age { get; set; }

        //[NotMapped] // in memory only, not db
        //public string Comment { get; set; } 

    }
}
