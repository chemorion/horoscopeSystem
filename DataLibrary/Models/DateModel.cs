using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class DateModel
    {
        public  int Id { get; set; }
        public string Name { get; set; }

        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Horoscope { get; set; }

        public string prediction { get; set; }

    }
}
