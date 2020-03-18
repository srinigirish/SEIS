﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEIS.Registration.Api.Enums;

namespace SEIS.Registration.Api.Models
{
    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public AddressType AddrType { get; set; }
        
    }
}
