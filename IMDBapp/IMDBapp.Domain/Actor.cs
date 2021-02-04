using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBapp.Domain
{
    public class Actor
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
    }

    public class ActorToMovie
    {
        public string Movie { get; set; }
        public string Actor { get; set; }
        public DateTime DOB { get; set; }

    }

}
