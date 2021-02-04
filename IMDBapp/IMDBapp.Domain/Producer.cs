using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBapp.Domain
{
    public class Producer
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
    }

    public class ProducerToMovie
    {
        public string Movie { get; set; }
        public string Producer { get; set; }
        public DateTime DOB { get; set; }
    }

}
