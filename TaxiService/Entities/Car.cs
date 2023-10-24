using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
