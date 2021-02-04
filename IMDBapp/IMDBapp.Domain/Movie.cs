using System;
using System.Collections.Generic;

namespace IMDBapp.Domain
{
    public class Movie
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public string Plot { get; set; }
        public List<Actor> Actors { get; set; }
        public Producer Producer { get; set; }
    }
}
