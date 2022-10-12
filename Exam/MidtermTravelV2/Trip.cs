using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermTravelV2
{
    public class Trip
    {

        public int Id { get; set; }

        //[Required] //Database requirements I will have to create new db context and update my db entirely, if I have time, will do
        //[StringLength(30)]
        public string Destination { get; set; }

        //[Required]
        //[StringLength(30)]
        public string Name { get; set; }

        //[Required]
        //[StringLength(8)]
        public string PassportNo { get; set; } //two char Followed by 6 digits //front-end validat can insert two boxes, one for two chars another for only digits
        public DateTime Departure { get; set; }
        public DateTime Return { get; set; }

       

        //public string ToString(string str) //originally we wanted the gridview to enter the lines like this
        //{
        //        if (!string.IsNullOrEmpty(str))
        //        {
        //            return String.Format("{0}({1}) to {2} on {3} {4}, {5}",Name, PassportNo, Destination, Departure.Month, //Departure.Day, Departure.Year);
        //        }
        //    else
        //    {
        //        throw new ArgumentException("Invalid or Empty");
        //    }
        //}
    }
}
