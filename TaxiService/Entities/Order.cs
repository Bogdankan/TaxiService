﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string TripBegin { get; set; }
        public string TripEnd { get; set; }
        public Car Car { get; set; }
    }
}
