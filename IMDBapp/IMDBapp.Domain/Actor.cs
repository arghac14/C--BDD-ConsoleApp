using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBapp.Domain
{
    public class Actor : Person
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
    }
}
