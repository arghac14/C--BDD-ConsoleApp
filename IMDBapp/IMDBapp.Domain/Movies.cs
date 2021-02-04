using System;
using System.Collections.Generic;

namespace IMDBapp.Domain
{
    public class Movies
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public string Plot { get; set; }
        public List<Actors> Actors { get; set; }
        public Producers Producer { get; set; }

    }
}
